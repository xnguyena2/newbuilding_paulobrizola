using UnityEngine;
using System.Collections;

public class HUDFPS : MonoBehaviour
{
	public float updateInterval = 0.5F;

	private float accum = 0; // FPS accumulated over the interval
	private int frames = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	
	private string _text;
	private Color _color;

	void Start()
	{
		timeleft = updateInterval;
	}

	void Update()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		++frames;

		// Interval ended - update GUI text and start new interval
		if (timeleft <= 0.0)
		{
			// display two fractional digits (f2 format)
			float fps = accum / frames;
			string format = System.String.Format("{0:F2} FPS", fps);
			_text = format;

			if (fps < 30)
				_color = Color.yellow;
			else
				if (fps < 10)
					_color = Color.red;
				else
					_color = Color.green;
			//  DebugConsole.Log(format,level);
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}
	}
	
	void OnGUI()
	{
		GUI.color = _color;
		GUI.depth = -10;
		GUI.Label(new Rect(Screen.width - 100.0f, 10.0f, 100.0f, 100.0f), _text);
	}
}