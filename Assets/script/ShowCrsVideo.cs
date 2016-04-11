using UnityEngine;
using System.Collections;

public class ShowCrsVideo : FullScreenMovie {

	// Use this for initialization
	void Start () {
		//base.Start ();
		_width = 384;
		_height = 218;
	}
	
	public float _x = 0.0f;
	public float _y = 0.0f;
	public float _width = 1.0f;
	public float _height = 1.0f;
	
	//-------------------------------------------------------------------------

	public void setRectVideo(float x, float y, float width, float height){
		_x = x;
		_y = y;
		_width = width;
		_height = height;
	}

	public void setPostion(float x, float y){
		_x = x;
		_y = y;
	}

	public void setRectSize(float width, float height){
		_width = width;
		_height = height;
	}

	public float playVideoFromFile(string fileName){
		this.UnloadMovie ();
		this._filename = fileName;
		this.LoadMovie (true);
		if (this._moviePlayer == null)
			return 0;
		else
			return this._moviePlayer.DurationSeconds;
	}
	
	public new void OnGUI()
	{
		/*_x = Mathf.Clamp01(_x);
		_y = Mathf.Clamp01(_y);
		_width = Mathf.Clamp01(_width);
		_height = Mathf.Clamp01(_height);*/
		if (_moviePlayer != null && _moviePlayer.OutputTexture)
		{
			int prevDepth = GUI.depth;
			GUI.depth = _depth;
			
			Rect rect = new Rect(_x, _y, _width, _height);
			GUI.DrawTexture(rect, _moviePlayer.OutputTexture, _scaleMode, _alphaBlend);
			
			GUI.depth = prevDepth;
			//Debug.Log (_moviePlayer.DurationSeconds);
		}
	}
}
