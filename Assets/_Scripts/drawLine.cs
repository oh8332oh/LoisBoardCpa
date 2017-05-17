using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   

public class drawLine{
	
	private Vector3 input1;
	private Vector3 input2;
	private LineRenderer lineRenderer;
	private float counter;
	private float dist;
	public float lineDrawSpeed = 6f;
	// Use this for initialization
	void Start () {
		input1 = GameObject.Find ("plus").GetComponent<CreateChildNode> ().arrowInput1;
		input2 = GameObject.Find ("plus").GetComponent<CreateChildNode> ().arrowInput2;
		lineRenderer.SetPosition (0, input1);
		dist = Vector3.Distance (input1, input2);
	}
	
	// Update is called once per frame
	void Update () {
		if (counter < dist) {
			counter += 0.1f / lineDrawSpeed;
			float x = Mathf.Lerp (0, dist, counter);

			Vector3 pointA = input1;
			Vector3 pointB = input2;

			Vector3 pointAlongline = x * Vector3.Normalize (pointB - pointA) + pointA;
			lineRenderer.SetPosition (1, pointAlongline);
		}		
	}
}
