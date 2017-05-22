using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   

public class drawLine : MonoBehaviour{

	public Color corLaser = Color.green;
	public int disLaser = 50;
	public float width = 0.02f, final = 0.1f;
	private GameObject laser;
	private Vector3 position;

	void start()
	{
		laser = new GameObject ();
		laser.AddComponent<Light> ();
		laser.GetComponent<Light> ().intensity = 8;
		laser.GetComponent<Light> ().bounceIntensity = 8;
		laser.GetComponent<Light> ().range = final*2;
		laser.GetComponent<Light> ().color = corLaser;
		position = new Vector3 (0, 0, final);
		//
		LineRenderer lineRenderer = laser.AddComponent<LineRenderer>();
		lineRenderer.material = new Material (Shader.Find ("Particles/Additive"));
		lineRenderer.SetColors (corLaser, corLaser);
		lineRenderer.SetWidth (width, final);
		lineRenderer.SetVertexCount (2);

	}
	 
	void update()
	{
		Vector3 point = laser.transform.position + laser.transform.forward * disLaser;
		RaycastHit raycas;
		if(Physics.Raycast(laser.transform.position, laser.transform.forward, out raycas,disLaser)){
			GetComponent<LineRenderer>().SetPosition(0,transform.position);
			GetComponent<LineRenderer>().SetPosition(1,raycas.point);
			laser.transform.position = raycas.point - point;
			}
			else{
			GetComponent<LineRenderer>().SetPosition(0,laser.transform.position);
			GetComponent<LineRenderer>().SetPosition(1,raycas.point);	
			laser.transform.position = point;
			}
	}
/*
	public void draw(Vector3 input1, Vector3 input2)
	{
		lineRenderer.SetPosition (0, input1);
		lineRenderer.SetPosition (1, input2);
	//	dist = Vector3.Distance (input1, input2);
	}
*/


	/*
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
	*/
}
