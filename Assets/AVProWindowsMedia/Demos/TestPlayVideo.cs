using UnityEngine;
using System.Collections;

public class TestPlayVideo : FullScreenMovie 
{
	private float _position;
		
	public new void Start()
	{
		Application.runInBackground = true;
		base.Start();
	}
	
	
	static public int focusedWindow
	{
		get
		{
			System.Reflection.FieldInfo field =	typeof(GUI).GetField("focusedWindow", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
			return (int)field.GetValue(null);
		}
	}	
	
	public new void OnGUI()
	{
		base.OnGUI();

		GUI.color = new Color(1f, 1f, 1f, 1f);
		/*if (focusedWindow != 0)
			GUI.color = new Color(1f, 1f, 1f, 0.25f);*/

		GUI.Window(0, new Rect(0, 0, 540, 210), ControlWindow, "Controls");
	}
	
	public void ControlWindow(int id)
	{		
		GUILayout.BeginVertical();
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("File: ", GUILayout.Width(30));
		_filename = GUILayout.TextField(_filename, 128, GUILayout.Width(400));
		if (GUILayout.Button("Load File", GUILayout.Width(75)))
		{
			LoadMovie(true);
		}
		GUILayout.EndHorizontal();
		
		GUILayout.Label("Resolution: " + _moviePlayer.Width + "x" + _moviePlayer.Height);
		
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Volume ", GUILayout.Width(80));
		float volume = _moviePlayer.Volume;
		float newVolume = GUILayout.HorizontalSlider(volume, 0.0f, 1.0f, GUILayout.Width(200));
		if (volume != newVolume)
		{
			_moviePlayer.Volume = newVolume;
		}
		GUILayout.Label(_moviePlayer.Volume.ToString("F1"));
		GUILayout.EndHorizontal();
		
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Balance ", GUILayout.Width(80));
		float balance = _moviePlayer.AudioBalance;
		float newBalance = GUILayout.HorizontalSlider(balance, -1.0f, 1.0f, GUILayout.Width(200));
		if (balance != newBalance)
		{
			_moviePlayer.AudioBalance = newBalance;
		}
		GUILayout.Label(_moviePlayer.AudioBalance.ToString("F1"));
		GUILayout.EndHorizontal();

		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Time ", GUILayout.Width(80));
		_position = _moviePlayer.PositionSeconds;
		float newPosition = GUILayout.HorizontalSlider(_position, 0.0f, _moviePlayer.DurationSeconds, GUILayout.Width(200));
		if (_position != newPosition)
		{
			_moviePlayer.PositionSeconds = newPosition;
			_moviePlayer.Play();
			_moviePlayer.Update(true);
		}
		GUILayout.Label(_moviePlayer.PositionSeconds.ToString("F1") + " / " + _moviePlayer.DurationSeconds.ToString("F1") + "s");
		
		if (GUILayout.Button("Play"))
		{
			_moviePlayer.Play();
		}
		if (GUILayout.Button("Pause"))
		{
			_moviePlayer.Pause();
		}
		GUILayout.EndHorizontal();

		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Rate: " + _moviePlayer.PlaybackRate.ToString("F2") + "x");
		if (GUILayout.Button("-", GUILayout.Width(50)))
		{
			_moviePlayer.PlaybackRate = _moviePlayer.PlaybackRate * 0.5f;
		}
		
		if (GUILayout.Button("+", GUILayout.Width(50)))
		{
			_moviePlayer.PlaybackRate = _moviePlayer.PlaybackRate * 2.0f;
		}
		GUILayout.EndHorizontal();
		
		
		GUILayout.Space(10.0f);
		if (GUILayout.Button("Quit"))
		{
			Application.Quit();
		}

		GUILayout.EndVertical();
	}
}
