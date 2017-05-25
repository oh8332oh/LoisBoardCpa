using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movbar : MonoBehaviour {


	public	GameObject movingBar;
	//CNode.transform.RotateAround(new Vector3(0f,0f,0f), Vector3.up, 30f);
	private bool mov;
	private float LastEuler;
	private Vector3 Lastpos;
	// Use this for initialization
	void Start () {
		mov = true;
		LastEuler = Camera.main.transform.eulerAngles.y;
		Lastpos = Camera.main.transform.position;
	}

	// Update is called once per frame
	void Update () {

		float angle = Camera.main.transform.eulerAngles.y - LastEuler;
		Vector3 pos = Camera.main.transform.position - Lastpos;
		movingBar.transform.position += pos;
		Lastpos = Camera.main.transform.position;
		if (mov) {
			movingBar.transform.RotateAround(Camera.main.transform.position, Vector3.up, angle);
		}

		LastEuler = Camera.main.transform.eulerAngles.y;
		Vector3 movtemp = Camera.main.transform.eulerAngles;

		if (movtemp.x > 26f) {
			stop ();
		} else {
			move ();
		}
	}



	public void stop(){
		mov = false;
	}

	public void move(){
		mov = true;
		Vector3 temp = movingBar.transform.eulerAngles;
		Vector3 temp1 = Camera.main.transform.eulerAngles;
		movingBar.transform.RotateAround(Camera.main.transform.position, Vector3.up, -(temp.y-temp1.y));
	}
}
