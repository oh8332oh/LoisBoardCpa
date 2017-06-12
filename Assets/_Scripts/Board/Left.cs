﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Left : MonoBehaviour {
	private bool gazedAt;      

	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (gazedAt&&(Camera.main.transform.position != Vector3.zero)) {
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
			//			Camera.main.transform.eulerAngles = Camera.main.transform.eulerAngles+new Vector3 (0f, 1f, 0);
			//			Debug.Log (Camera.main.transform.eulerAngles);
			//Camera.main.transform.Rotate (new Vector3 (0f, 1f, 0f));
		}
	}

	public void PointerEnter()
	{   
		gazedAt = true;
	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{
		gazedAt = false;
	}
	public void rotL(){
		CameraOb.Cam.transform.RotateAround (Vector3.zero, Vector3.up, -1f);
	}
}
