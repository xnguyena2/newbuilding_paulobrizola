using UnityEngine;
using System.Collections;

[AddComponentMenu("AV Pro Windows Media/ScreenMovie")]
public class ScreenMovie : FullScreenMovie
{
	public float _x = 0.0f;
	public float _y = 0.0f;
	public float _width = 1.0f;
	public float _height = 1.0f;
	
	//-------------------------------------------------------------------------
	
	public new void OnGUI()
	{
		_x = Mathf.Clamp01(_x);
		_y = Mathf.Clamp01(_y);
		_width = Mathf.Clamp01(_width);
		_height = Mathf.Clamp01(_height);
		if (_moviePlayer != null && _moviePlayer.OutputTexture)
		{
			int prevDepth = GUI.depth;
			GUI.depth = _depth;
			
			Rect rect = new Rect(_x * (Screen.width-1), _y * (Screen.height-1), _width * Screen.width, _height * Screen.height);
			GUI.DrawTexture(rect, _moviePlayer.OutputTexture, _scaleMode, _alphaBlend);
			
			GUI.depth = prevDepth;
		}
	}
}