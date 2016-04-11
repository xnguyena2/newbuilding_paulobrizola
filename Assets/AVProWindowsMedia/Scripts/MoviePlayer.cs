using UnityEngine;
using System.Collections;
using System;

public class MoviePlayer : MonoBehaviour
{
	protected AVProWindowsMedia _moviePlayer;
	public string _filename;
	public bool _loop;
	public bool _useNativeFormat = true;
	public bool _playOnStart = true;
	public bool _forceUpdate = false;
	protected float _volume = 1.0f;
	
	public float Volume 
	{
		get { return _volume; }
		set { _volume = Mathf.Clamp01(value); if (_moviePlayer != null) _moviePlayer.Volume = _volume; }
	}
	
	public Texture OutputTexture  
	{
		get { if (_moviePlayer != null) return _moviePlayer.OutputTexture; return null; }
	}
	
	public AVProWindowsMedia MovieInstance
	{
		get { return _moviePlayer; }
	}	

	public void Start()
	{
		LoadMovie(_playOnStart);
	}
	
	public void LoadMovie(bool autoPlay)
	{
		if (_moviePlayer == null)
			_moviePlayer = new AVProWindowsMedia();
		if (_moviePlayer.StartVideo(_filename, _loop, _useNativeFormat))
		{
			_moviePlayer.Volume = _volume;
			if (autoPlay)
			{
				_moviePlayer.Play();
			}
		}
		else
		{
			Debug.LogWarning("Couldn't load movie " + _filename);
			UnloadMovie();
		}	
	}
		
	public void UnloadMovie()
	{
		if (_moviePlayer != null)
		{
			_moviePlayer.Close();
			_moviePlayer = null;
		}			
	}
	
	public void Update()
	{
		if (_moviePlayer != null)
			_moviePlayer.Update(_forceUpdate);	
	}
	
	public void OnDestroy()
	{
		UnloadMovie();
	}

	public static Rect GetFitRect(Rect targetRect, float sourceWidth, float sourceHeight, ScaleMode scale)
	{
		float x = targetRect.x;
		float y = targetRect.y;
		float w = targetRect.width;
		float h = targetRect.height;
		switch (scale)
		{
		case ScaleMode.StretchToFill:
			break;
		case ScaleMode.ScaleToFit:
			{
				float ratioX = targetRect.width / sourceWidth;
				float ratioY = targetRect.height / sourceHeight;
				float ratio = Math.Min(ratioX, ratioY);
				
				w = sourceWidth * ratio;
				h = sourceHeight * ratio;
				x = targetRect.x + (targetRect.width - (sourceWidth * ratio)) * 0.5f;
				y = targetRect.y + (targetRect.height - (sourceHeight * ratio)) * 0.5f;
			}
			break;
		case ScaleMode.ScaleAndCrop:		// "ScaleAndCrop" = "zoom" on most TVs
			{
				float ratioX = targetRect.width / sourceWidth;
				float ratioY = targetRect.height / sourceHeight;
				float ratio = Math.Max(ratioX, ratioY);
				
				w = sourceWidth * ratio;
				h = sourceHeight * ratio;
				x = targetRect.x + (targetRect.width - (sourceWidth * ratio)) * 0.5f;
				y = targetRect.y + (targetRect.height - (sourceHeight * ratio)) * 0.5f;
			}
			break;
		}
		
		return new Rect(x, y, w, h);
	}
}