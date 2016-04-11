using UnityEngine;
using System.Collections;

public class cylinderarrow : MonoBehaviour {
	
	
	
	public float speed = 0.05f;
	Rigidbody rb;
	Vector3[] listPoint;
	Vector3 currentTarget;
	int index = 2;
	float oldD = 10000f;
	// Use this for initialization
	void Start () {
	}
	
	public void beginMove(Vector3[] LV){
		Vector3 be = LV [0];
		Vector3 en = LV [1];
		beginMove (be, en);
		currentTarget = en;
		listPoint = LV;
	}
	
	
	public void moveNext(){
		if(listPoint!=null)
		if (listPoint.Length > index) {
			Vector3 end = listPoint[index];
			beginMove (currentTarget, end);
			currentTarget = end;
			index++;
		}
	}
	
	public void beginMove(Vector3 start , Vector3 end){
		//Vector3 start = new Vector3(380.287f, 0.15f, 80.62f);
		//Vector3 end = new Vector3(373.287f, 0.2788003f, 64.50918f);
		this.transform.position = start;
		
		
		Vector3 _direction = (end - start).normalized;
		
		//create the rotation we need to be in to look at the target
		Quaternion  _lookRotation = Quaternion.LookRotation(_direction);
		
		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 1000f);
		
		//this.transform.rotation = Quaternion.Euler (anglex, angley, -anglez);
		
		
		
		rb = this.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.AddForce ((end - start).normalized * speed);
		
	}
	
	// Update is called once per frame
	void Update () {
		float dis = Vector3.Distance (this.transform.position, currentTarget);
		if (dis > oldD) {
			moveNext ();
			oldD = 100000f;
		} else {
			oldD = dis;
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "printpoint")
		{
			Destroy(this.gameObject);
		}
	}
}
