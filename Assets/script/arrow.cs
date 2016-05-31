using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class arrow : MonoBehaviour {


	
	public float speed = 0.05f;
	public Rigidbody rb;
	Vector3[] listPoint;
	Vector3 currentTarget;
	Vector3 StartPoint;
	int index = 2;
	float oldD = 10000f;
	public float distance = 3f;
	bool isend = false,firstCreate = true;

	// Use this for initialization
	void Start () {
	}

	public void beginMove(Vector3[] LV){
		StartPoint = LV [0];
		currentTarget = LV [1];
		beginMove (StartPoint, currentTarget);
		listPoint = LV;
	}

	public void beginMove(Vector3[] LV,Vector3 start, int index){
		StartPoint = LV [0];
		currentTarget = LV [index];
		beginMove (start, currentTarget);
		listPoint = LV;
		this.index = index + 1;
	}
	

	public void moveNext(){
		if (listPoint != null) {
			if (listPoint.Length > index) {
				Vector3 end = listPoint [index];
				beginMove (currentTarget, end);
				currentTarget = end;
				index++;
			}else Destroy(this.gameObject);
		}else Destroy(this.gameObject);
	}
	bool firstSet = true;
	public void beginMove(Vector3 start , Vector3 end){
		//this.transform.position = start;
		if (firstCreate) {
			this.transform.position = start;
			firstCreate = false;
		} else
			start = this.transform.position;


		Vector3 _direction = (end - start).normalized;


		/*
		 * 
		 * this part for rotation
		//create the rotation we need to be in to look at the target
		Quaternion  _lookRotation = Quaternion.LookRotation(_direction);
		
		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 1000f);

		//this.transform.rotation = Quaternion.Euler (anglex, angley, -anglez);

		 */

		rb.velocity = _direction * Vector3.Distance (rb.velocity, Vector3.zero);//Vector3.zero

		if (firstSet) 
		{
			rb.AddForce (_direction * speed);//alway run here
			firstSet=false;
		}

	}

	public void thisIsStartPoint(){
		isend = true;
	}
	
	// Update is called once per frame
	void Update () {
		float dis = Vector3.Distance (this.transform.position, currentTarget);
		if (dis > oldD || dis == 0.0f) {
			moveNext ();
			oldD = 100000f;
		} else {
			oldD = dis;
		}

		if (isend) {
			if (Vector3.Distance (this.transform.position, StartPoint) > distance){
				GameObject arrowss = GameObject.Find("arrow");
				if(arrowss == null)
					arrowss = Instantiate(Resources.Load("arrow", typeof(GameObject))) as GameObject;
				isend = false;
				GameObject ar = GameObject.Instantiate (arrowss) as GameObject;
				ar.name = "ball";
				arrow scri = ar.GetComponent<arrow> ();
				scri.beginMove (listPoint);
				scri.thisIsStartPoint();
				//Destroy(arrowss,60000);
			}
		}
	}

	void OnCollisionEnter (Collision col)
	{
		//if(col.gameObject.name == "printpoint")
		{
			Destroy(this.gameObject);
		}
	}
}