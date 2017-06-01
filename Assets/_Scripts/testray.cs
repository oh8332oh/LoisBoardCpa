using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		



	}
	
	// Update is called once per frame
	void Update () {

		Vector3 source = new Vector3(0,0,0);
		// Vector3 source = Vector3.zero;

		Vector3 raydirection = Vector3.right	;
		
		Ray ray = new Ray(source, raydirection);


		float duration = 200;
		Debug.DrawLine(source, raydirection, Color.red, duration);



	}
}
