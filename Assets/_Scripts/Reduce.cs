using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reduce : MonoBehaviour {
	private bool gazedAt;      
	private float Timer;
	private float gazeTime = 1.0f;
	private bool move;
	private bool onetime;
	private Vector3 deltamov;
	void Start () {
		Timer = 0f;
	}
	void Update () {
		
		if (gazedAt) {
			Timer += Time.deltaTime;
		}
		if (!onetime&&gazedAt) {
			deltamov = Vector3.zero - Camera.main.transform.position;
			onetime = true;
		}
		if (Timer>=gazeTime&&gazedAt) {
			Camera.main.transform.position += deltamov/100f;
			if (Vector3.Distance (Vector3.zero, Camera.main.transform.position) <0.1f) {
				move = false;
				Camera.main.transform.position = Vector3.zero;
			} 
		}
	}

	public void PointerEnter()
	{   
		gazedAt = true;
		move = true;
	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{
		gazedAt = false;
		move = false;
		onetime = false;
		Timer = 0f;
	}
}
