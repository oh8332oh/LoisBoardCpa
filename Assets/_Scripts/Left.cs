using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour {
	private bool gazedAt;      
	private float Timer;
	private float gazeTime = 1.0f;
	// Use this for initialization
	void Start () {
		Timer = 1.0f;
	}

	// Update is called once per frame
	void Update () {

		if (gazedAt) {
			Timer += Time.deltaTime;
		}
		if (Timer>=gazeTime&&gazedAt&&(Camera.main.transform.position != Vector3.zero)) {
			Camera.main.transform.RotateAround (Vector3.zero, Vector3.up, -1f);
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
		Timer = 0f;
	}
}
