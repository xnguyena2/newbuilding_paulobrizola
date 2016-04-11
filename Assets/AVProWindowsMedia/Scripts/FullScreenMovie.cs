using UnityEngine;
using System.Collections;

[AddComponentMenu("AV Pro Windows Media/FullScreenMovie")]
public class FullScreenMovie : MoviePlayer
{
	public ScaleMode _scaleMode = ScaleMode.ScaleToFit;
	public bool _alphaBlend = false;
	public int  _depth = 0;
	
	//-------------------------------------------------------------------------
	
	public void OnGUI()
	{
		if (_moviePlayer != null && _moviePlayer.OutputTexture != null)
		{
			int prevDepth = GUI.depth;
			
			GUI.depth = _depth;
			GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), _moviePlayer.OutputTexture, _scaleMode, _alphaBlend);
			
			GUI.depth = prevDepth;
		}
	}	
}