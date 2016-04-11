using UnityEngine;
using System.Text;
using System.Runtime.InteropServices;

//-----------------------------------------------------------------------------

public class AVProWindowsMedia
{
	[DllImport("AVProWindowsMedia")]
	private static extern bool Init();

	[DllImport("AVProWindowsMedia")]
	private static extern void Deinit();

	[DllImport("AVProWindowsMedia")]
	private static extern int GetInstanceHandle();

	[DllImport("AVProWindowsMedia")]
	private static extern void FreeInstanceHandle(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern bool LoadMovie(int handle, System.IntPtr filename, bool loop, bool allowNativeFormat);

	[DllImport("AVProWindowsMedia")]
	private static extern bool LoadAudio(int handle, System.IntPtr filename, bool loop);

	[DllImport("AVProWindowsMedia")]
	private static extern void Play(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern void Pause(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern void Stop(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern void SeekUnit(int handle, float position);

	[DllImport("AVProWindowsMedia")]
	private static extern void SeekSeconds(int handle, float position);

	[DllImport("AVProWindowsMedia")]
	private static extern void SetVolume(int handle, float volume);

	[DllImport("AVProWindowsMedia")]
	private static extern void SetLooping(int handle, bool loop);

	[DllImport("AVProWindowsMedia")]
	private static extern void SetPlaybackRate(int handle, float rate);
	
	[DllImport("AVProWindowsMedia")]
	private static extern void SetAudioBalance(int handle, float balance);
		
	
	[DllImport("AVProWindowsMedia")]
	private static extern bool Update(int handle);


	[DllImport("AVProWindowsMedia")]
	private static extern int GetWidth(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern int GetHeight(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern int GetFormat(int handle);
	
	[DllImport("AVProWindowsMedia")]
	private static extern float GetDurationSeconds(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern float GetCurrentPositionSeconds(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern bool IsFinishedPlaying(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern bool IsOrientedTopDown(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern bool IsLooping(int handle);
	
	[DllImport("AVProWindowsMedia")]
	private static extern float GetPlaybackRate(int handle);
	
	[DllImport("AVProWindowsMedia")]
	private static extern float GetAudioBalance(int handle);

	
	[DllImport("AVProWindowsMedia")]
	private static extern bool IsNextFrameReadyForGrab(int handle);

	[DllImport("AVProWindowsMedia")]
	private static extern bool UpdateTextureGL(int handle, int textureID);

	[DllImport("AVProWindowsMedia")]
	private static extern bool GetFramePixels(int handle, System.IntPtr data, int bufferWidth, int bufferHeight);

	//-----------------------------------------------------------------------------

	private bool _firstInstance = false;
	private static bool _isInitialised = false;
	private static bool _isOpenGL = false;

	// For DirectX texture updates
	private GCHandle _frameHandle;
	private Color32[] _frameData;
	
	// Video properties
	private string _filename;
	private int _videoWidth, _videoHeight, _videoFormat;
	private bool _isPow2;
	private float _durationSeconds;

	// Format conversion and texture outputs
	private Texture2D _texture;
	private RenderTexture _target;
	private bool _flipX = false;
	private bool _flipY = true;
	private VideoFrameFormat _sourceFormat;
	private Material _conversionMaterial;
	
	private static Material _materialBGRA32;
	private static Material _materialYUY2;
	private static Material _materialUYVY;
	private static Material _materialYVYU;
	private static Material _materialHDYC;
	private static Shader _shaderBGRA32;
	private static Shader _shaderYUY2;
	private static Shader _shaderUYVY;
	private static Shader _shaderYVYU;
	private static Shader _shaderHDYC;
	
	private enum VideoFrameFormat
	{
		RAW_BGRA32,
		YUV_422_YUY2,
		YUV_422_UYVY,
		YUV_422_YVYU,
		YUV_422_HDYC,
	}

	// State
	private int _handle = -1;
	private bool _loop;
	private bool _allowNativeFormat;
	private bool _playing = false;
	private float _volume = 1.0f;
	
	//-----------------------------------------------------------------------------
	
	public float Volume 
	{
		set { _volume = value; SetVolume(_handle, _volume); }
		get { return _volume; }
	}

	public float AudioBalance
	{
		set { SetAudioBalance(_handle, value); }
		get { return GetAudioBalance(_handle); }
	}

	public float PlaybackRate 
	{
		set { SetPlaybackRate(_handle, value); }
		get { return GetPlaybackRate(_handle); }
	}		

	public string Filename
	{
		get { return _filename; }
	}

	public Texture OutputTexture
	{
		get { return _target; }
	}
	
	public float AspectRatio
	{
		get { return (_videoWidth / (float)_videoHeight); }
	}
	
	public int Width
	{
		get { return _videoWidth; }
	}
	
	public int Height
	{
		get { return _videoHeight; }
	}

	public float DurationSeconds
	{
		get { return _durationSeconds; }
	}

	public float PositionSeconds
	{
		get { return GetCurrentPositionSeconds(_handle); }
		set { SeekSeconds(_handle, value); }
	}
	
	//-------------------------------------------------------------------------

	private bool Start(string filename, bool loop)
	{
		if (!_isInitialised)
		{
			if (!InitGlobal())
			{
				Close();
				return false;
			}
			
			_firstInstance = true;
		}

		_filename = filename;
		_loop = loop;
		if (!string.IsNullOrEmpty(_filename))
		{
			if (_handle < 0)
				_handle = GetInstanceHandle();
		}
		else
		{
			Debug.LogWarning("No movie file specified");
			Close();
		}
		
		return _handle >= 0;
	}

	public bool StartVideo(string filename, bool loop, bool allowNativeFormat)
	{
		if (!Start(filename, loop))
			return false;	
		
		_allowNativeFormat = allowNativeFormat;

		// Note: we're marshaling the string to IntPtr as the pointer of type wchar_t 
		System.IntPtr filenamePtr = Marshal.StringToHGlobalUni(_filename);
		if (LoadMovie(_handle, filenamePtr, _loop, _allowNativeFormat))
		{
			SetVolume(_handle, _volume);
			
			_videoWidth = GetWidth(_handle);
			_videoHeight = GetHeight(_handle);
			_isPow2 = (IsPower2(_videoWidth) && IsPower2(_videoHeight));
			_durationSeconds = GetDurationSeconds(_handle);
			_flipY = IsOrientedTopDown(_handle);
			_sourceFormat = (VideoFrameFormat)(GetFormat(_handle));
			
			_conversionMaterial = null;
			switch (_sourceFormat)
			{
			case VideoFrameFormat.YUV_422_YUY2:
				_conversionMaterial = _materialYUY2;
				break;
			case VideoFrameFormat.YUV_422_UYVY:
				_conversionMaterial = _materialUYVY;
				break;
			case VideoFrameFormat.YUV_422_YVYU:
				_conversionMaterial = _materialYVYU;
				break;
			case VideoFrameFormat.YUV_422_HDYC:
				_conversionMaterial = _materialHDYC;
				break;
			case VideoFrameFormat.RAW_BGRA32:
				_conversionMaterial= _materialBGRA32;
				break;
			default:
				Debug.LogError("Unknown video format '" + _sourceFormat + "' in " + _filename);
				Close();
				break;
			}
			
			if (_conversionMaterial != null)
			{
				Debug.Log("loaded video " + _filename + "[" + _videoWidth + "x" + _videoHeight + " " + GetDurationSeconds(_handle) + " sec  format:" + _sourceFormat.ToString());
				
				if (_videoWidth > 0 && _videoWidth <= 4096 && _videoHeight > 0 && _videoHeight <= 4096)
				{
					int texWidth = _videoWidth;
					int texHeight = _videoHeight;
					if (_sourceFormat != AVProWindowsMedia.VideoFrameFormat.RAW_BGRA32)
						texWidth /= 2;
					
					if (!_isPow2 && (!_isOpenGL || _sourceFormat != AVProWindowsMedia.VideoFrameFormat.RAW_BGRA32))
					{
						// We use a power of 2 texture as Unity is MUCH faster at updating these
						texWidth = RoundUpToNearestPow2(texWidth);
						texHeight = RoundUpToNearestPow2(texHeight);
						Debug.Log("using texture " + texWidth + "x" + texHeight + " for video " + _videoWidth + "x" + _videoHeight);
					}
					
					// Create texture that captures video frames	
					// If there is already a texture, only destroy it if it isn't of desired size
					if (_texture != null)
					{
						if (_texture.width != texWidth || _texture.height != texHeight)
						{
							Texture2D.Destroy(_texture);
							_texture = null;
						}
					}					
					if (_texture == null)
					{
						_texture = new Texture2D(texWidth, texHeight, TextureFormat.ARGB32, false);
						_texture.hideFlags = HideFlags.HideAndDontSave;
						_texture.wrapMode = TextureWrapMode.Clamp;
						_texture.filterMode = FilterMode.Point;
						_texture.Apply(false);
					}
					_texture.name = _filename;
					
					// Create rendertexture for post transformed frames
					// If there is already a renderTexture, only destroy it if it isn of desired size
					if (_target != null)
					{
						if (_target.width != _videoWidth || _target.height != _videoHeight)
						{
							_target.Release();
							RenderTexture.Destroy(_target);
							_target = null;
						}
					}
					if (_target == null)
					{
						_target = new RenderTexture(_videoWidth, _videoHeight, 0);
						_target.wrapMode = TextureWrapMode.Clamp;
						_target.useMipMap = false;
						_target.hideFlags = HideFlags.HideAndDontSave;
						_target.format = RenderTextureFormat.ARGB32;
						_target.filterMode = FilterMode.Bilinear;
						_target.Create();
					}
					_target.name = _filename;

					if (!_isOpenGL)
					{
						if (_frameHandle.IsAllocated && _frameData != null)
						{
							if (_frameData.Length < _texture.width * _texture.height)
							{
								_frameHandle.Free();
								_frameData = null;
							}
						}
						if (_frameData == null)
						{
							// Allocate buffer for non-opengl updates
							_frameData = new Color32[_texture.width * _texture.height];
							_frameHandle = GCHandle.Alloc(_frameData, GCHandleType.Pinned);
						}	
					}
				}
			}
		}
		else
		{
			Debug.LogWarning("Movie failed to load");
			Close();
		}
		Marshal.FreeHGlobal(filenamePtr);
		
		return _handle >= 0;
	}
	
	public bool StartAudio(string filename, bool loop)
	{
		if (!Start(filename, loop))
			return false;

		// Note: we're marshaling the string to IntPtr as the pointer of type wchar_t 
		System.IntPtr filenamePtr = Marshal.StringToHGlobalUni(_filename);
		if (LoadAudio(_handle, filenamePtr, _loop))
		{
			Debug.Log("loaded audio " + _filename + " " + GetDurationSeconds(_handle) + " sec");
				
			SetVolume(_handle, _volume);
				
			_durationSeconds = GetDurationSeconds(_handle);				
		}
		else
		{
			Debug.LogWarning("Movie failed to load");
			Close();
		}
		Marshal.FreeHGlobal(filenamePtr);
		
		return _handle >= 0;
	}
	
	private static bool InitGlobal()
	{
		if (!Init())
		{
			Debug.LogError("AVProWindowsMedia failed to initialise.");
			return false;
		}
		if (!LoadShader("Hidden/CompositeBGRA2RGBA", out _shaderBGRA32))
		{
			return false;
		}
		if (!LoadShader("Hidden/CompositeYUY22RGBA", out _shaderYUY2))
		{
			return false;
		}
		if (!LoadShader("Hidden/CompositeUYVY2RGBA", out _shaderUYVY))
		{
			return false;
		}
		if (!LoadShader("Hidden/CompositeYVYU2RGBA", out _shaderYVYU))
		{
			return false;
		}
		if (!LoadShader("Hidden/CompositeHDYC2RGBA", out _shaderHDYC))
		{
			return false;
		}
		
		_materialYUY2 = new Material(_shaderYUY2);
		_materialUYVY = new Material(_shaderUYVY);
		_materialYVYU = new Material(_shaderYVYU);
		_materialHDYC = new Material(_shaderHDYC);
		_materialBGRA32 = new Material(_shaderBGRA32);

		_isInitialised = true;
		_isOpenGL = SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL");
		
		/*
		bool _supportsNativeDirectXTextures = false;
		string[] versionParts = Application.unityVersion.Split('.');
		float versionMajor;
		if (float.TryParse(versionParts[0], out versionMajor))
		{
			if (versionMajor == 3.0f)
			{
				float versionMinor;
				if (float.TryParse(versionParts[1], out versionMinor))
				{
					if (versionMinor >= 5.0f)
					{
						_supportsNativeDirectXTextures = true;
						Debug.Log("Supports native directx textures!");
					}
				}	
			}
		}*/
		
		return true;
	}	

	public void Update(bool force)
	{
		if (_handle >= 0 && _playing)
		{
			bool ready = IsNextFrameReadyForGrab(_handle);
			if (ready || force)
			{
				Update(_handle);
				
				// Our media might not be graphical so check width and height
				if (_videoWidth > 0 && _videoHeight > 0)
				{
					if (UpdateTexture())
					{
						DoFormatConversion();
					}
				}
			}
		}
	}

	private bool UpdateTexture()
	{
		bool result = false;
		if (_isOpenGL)
		{
			UpdateTextureGL(_handle, _texture.GetNativeTextureID());
			GL.InvalidateState();
			result = true;
		}
		else
		{
			result = GetFramePixels(_handle, _frameHandle.AddrOfPinnedObject(), _texture.width, _texture.height);
			
			if (result)
			{
				_texture.SetPixels32(_frameData);
				_texture.Apply();
			}
		}
		
		return result;
	}

	private void DoFormatConversion()
	{
		RenderTexture.active = _target;

		if (_texture != null)
		{
			if (_sourceFormat != AVProWindowsMedia.VideoFrameFormat.RAW_BGRA32)
			{
				_conversionMaterial.SetFloat("_TextureWidth", _texture.width);
			}
			
			_conversionMaterial.SetTexture("_MainTex", _texture);
			_conversionMaterial.SetPass(0);

			GL.PushMatrix();
			GL.LoadOrtho();
			DrawQuad(_flipX, _flipY);
			GL.PopMatrix();
		}

		RenderTexture.active = null;
	}

	public void Play()
	{
		if (_handle >= 0)
		{
			Play(_handle);
			_playing = true;
		}
	}
	
	public void Pause()
	{
		if (_handle >= 0)
		{
			Pause(_handle);
			_playing = false;
		}
	}
	
	public void Stop()
	{
		if (_handle >= 0)
		{
			Stop(_handle);
			_playing = false;
		}
	}

	public void Close()
	{
		Stop();
		
		_videoWidth = _videoHeight = 0;

		if (_target != null)
		{
			_target.Release();
			RenderTexture.Destroy(_target);
			_target = null;
		}
		
		if (_texture != null)
		{
			Texture2D.Destroy(_texture);
			_texture = null;
		}
		
		if (_frameHandle.IsAllocated)
		{
			_frameHandle.Free();
			_frameData = null;
		}
				
		if (_handle >= 0)
		{
			FreeInstanceHandle(_handle);
			_handle = -1;
		}

		_conversionMaterial = null;

		if (_firstInstance)
		{
			Deinit();
			
			Material.Destroy(_materialYUY2);
			Material.Destroy(_materialUYVY);
			Material.Destroy(_materialYVYU);
			Material.Destroy(_materialHDYC);
			Material.Destroy(_materialBGRA32);
			_materialYUY2 = null;
			_materialUYVY = null;
			_materialYVYU = null;
			_materialHDYC = null;
			_materialBGRA32 = null;
			_shaderBGRA32 = null;
			_shaderYUY2 = null;
			_shaderUYVY = null;
			_shaderYVYU = null;
			_shaderHDYC = null;
			_isInitialised = false;
			_firstInstance = false;
		}
	}

	private void DrawQuad(bool invertX, bool invertY)
	{
		GL.Begin(GL.QUADS);
		float x1, x2;
		float y1, y2;
		if (invertX)
		{
			x1 = 1.0f; x2 = 0.0f;
		}
		else
		{
			x1 = 0.0f; x2 = 1.0f;
		}
		if (invertY)
		{
			y1 = 1.0f; y2 = 0.0f;
		}
		else
		{
			y1 = 0.0f; y2 = 1.0f;
		}
		
		if (_videoWidth != _texture.width)
		{
			float xd = _videoWidth / (float)_texture.width;
			x1 *= xd; x2 *= xd;
		}
		if (_videoHeight != _texture.height)
		{
			float yd = _videoHeight / (float)_texture.height;
			y1 *= yd; y2 *= yd;
		}

		GL.TexCoord2(x1, y1); GL.Vertex3(0.0f, 0.0f, 0.1f);
		GL.TexCoord2(x2, y1); GL.Vertex3(1.0f, 0.0f, 0.1f);
		GL.TexCoord2(x2, y2); GL.Vertex3(1.0f, 1.0f, 0.1f);
		GL.TexCoord2(x1, y2); GL.Vertex3(0.0f, 1.0f, 0.1f);
		GL.End();
	}

	//-----------------------------------------------------------------------------

	private static bool IsPower2(int n) 
	{
		if ( (n & (n - 1)) == 0) return true;
		else return false;
	}

	private static int RoundUpToNearestPow2(int num)
	{
		int n = num > 0 ? num - 1 : 0;

		n |= n >> 1;
		n |= n >> 2;
		n |= n >> 4;
		n |= n >> 8;
		n |= n >> 16;
		n++;

		return n;
	}
	
	private static bool LoadShader(string name, out Shader result)
	{
		result = Shader.Find(name);
		if (!result || !result.isSupported)
		{
			result = null;
			Debug.LogError("AVProWindowsMedia - shader '" + name + "' not found or supported");
		}
		
		return (result != null);
	}
}