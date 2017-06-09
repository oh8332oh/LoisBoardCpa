using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movbar : MonoBehaviour {


	public	GameObject movingBar;
	//CNode.transform.RotateAround(new Vector3(0f,0f,0f), Vector3.up, 30f);
	private bool mov;
	private float LastEuler;  // Last가 들어가는 것은 움직임에 대한 델타값을 얻기위함
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
			movingBar.transform.RotateAround(Camera.main.transform.position, Vector3.up, angle); //카메라가 회전하는 델타값을 무빙바에 주어 회전을 같이 하게한다.
		}

		LastEuler = Camera.main.transform.eulerAngles.y;
		Vector3 movtemp = Camera.main.transform.eulerAngles;

		if (movtemp.x > 26f) {  //카메라가 x축 (보는 시야를 아래로) 26도 이상이 된다면 무빙바는 움직이지 않는다.
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
<<<<<<< HEAD
		movingBar.transform.RotateAround(Camera.main.transform.position, Vector3.up, -(temp.y-temp1.y));// 의미없는듯 하다 (사실 제가 적은건데 기억이..)
=======
		movingBar.transform.RotateAround(Camera.main.transform.position, Vector3.up, -(temp.y-temp1.y));  //의미없는듯 하다 (사실 제가 적은건데 기억이..)
>>>>>>> a7540dda478a61836cbfd07fc60a48beda095a06
	}
}
