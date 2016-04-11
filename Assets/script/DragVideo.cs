using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.IO;

public class DragVideo : MonoBehaviour ,IBeginDragHandler,IDragHandler,IEndDragHandler{
	public static GameObject video;
	public ShowCrsVideo movieShow ;
	Vector3 postion;
	Vector3 ofset;
	int screenWidth;
	int screenHeigh;
	float offsetx,offsety;
	float officeVideoPosx, officeVideoPosy;
	
	void Start(){
		offsetx = 167f;
		offsety = 101f;
		screenWidth = Screen.width;
		screenHeigh = Screen.height;
		officeVideoPosx = transform.position.x - offsetx;
		officeVideoPosy = screenHeigh - transform.position.y - offsety;
		//Debug.Log (System.IO.Directory.GetCurrentDirectory());
		//StartCoroutine (loadvideo ());
	}
	
	public void loadVideoFromUrl(string url, System.Action callback){
		//return loadvideoPath ("C:\\Users\\Nguyen Phong\\Documents\\Visual Studio 2013\\Projects\\Admin Manager\\Server\\bin\\Release\\video\\a.avi", callback);
		StartCoroutine( loadvideoUrl (url, callback));
	}
	
	public void updateLocationVideo(float x, float y, Vector2 size){
		StartCoroutine (updatelocationVideo (x,y, size));
	}

	public void exitVideo(){
		movieShow.UnloadMovie ();
	}
	
	IEnumerator updatelocationVideo(float x, float y, Vector2 size){
		offsetx = x;
		offsety = y;
		movieShow.setRectVideo (transform.position.x - offsetx, screenHeigh - transform.position.y - offsety, size.x, size.y);
		yield return null;
	}
	
	IEnumerator loadvideoUrl (string url, System.Action callback)
	{
		if (movieShow.playVideoFromFile (url) > 0) {
			// download		
			offsetx = 167f;
			offsety = 101f;
		
			// load and play
			{
				ControlEvent.currentvideo = true;
				movieShow.setRectVideo (officeVideoPosx, officeVideoPosy, 332, 202);
				if (callback != null)
					callback ();
			}
		}
		yield return null;
	}
	
	
	IEnumerator loadvideoPath (string path, System.Action callback)
	{
		// download
		
		offsetx = 167f;
		offsety = 101f;
		if (System.IO.File.Exists (path)) {
			ControlEvent.currentvideo = true;
			movieShow.setRectVideo (officeVideoPosx, officeVideoPosy, 332, 202);
			if(callback != null) callback();
		}
		yield return null;
	}
	
	
	#region IBeginDragHandler implementation
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		video = gameObject;
		postion = transform.position;
		ofset = postion - Input.mousePosition;
		movieShow.setPostion (transform.position.x - offsetx, screenHeigh - transform.position.y - offsety);
	}
	
	#endregion
	
	
	
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition + ofset;
		movieShow.setPostion (transform.position.x - offsetx, screenHeigh - transform.position.y - offsety);
	}
	#endregion
	
	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)
	{
		
	}
	
	#endregion
}
