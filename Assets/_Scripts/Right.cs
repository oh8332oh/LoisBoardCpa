using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Right : MonoBehaviour {
	private bool gazedAt;      
	private float Timer;
	private float gazeTime = 1.0f;
	private float at;
	// Use this for initialization
	void Start () {
		Timer = 1.0f;
	}

	// Update is called once per frame
	void Update () {
			if (gazedAt&&(Camera.main.transform.position != Vector3.zero)) {
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
		}
	}

	public void PointerEnter()
	{   
		gazedAt = true;
	}	

	public void PointerExit()
	{
		gazedAt = false;
		Timer = 0f;
	}

	public void rot(){
		GameObject[] Node = GameObject.FindGameObjectsWithTag ("Node");
		for (int i = 0; i < Node.Length; i++) {
			Node [i].transform.RotateAround (Vector3.zero, Vector3.up, -1f);
		}

	}
}
