using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   
public class InterFaceN : MonoBehaviour {
	public GameObject interfacePrefab;
	private GameObject button;
	private bool gazedAt;      
	private bool onetime;
	private Vector3 tempLoc;
	private Quaternion tempRot;
	private float Timer;
	private float gazeTime = 1.0f;

	// Use this for initialization
	void Start () {
		tempLoc = transform.localPosition;
		tempRot = transform.localRotation;
		Timer = 0f;
	}

	// Update is called once per frame
	void Update () {


		if (gazedAt) {
			Timer += Time.deltaTime;
		}
		if (Timer>=gazeTime&&gazedAt&&!onetime) {
			button = Instantiate (interfacePrefab,tempLoc,tempRot);
			button.transform.parent = gameObject.transform;
			onetime = true;	
		}
		//gameObject.transform.RotateAround (Vector3.zero, Vector3.up, 30f*Time.deltaTime);
	}
	public void PointerEnter()
	{   
		gazedAt = true;
	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{

		gazedAt = false;
		onetime = false;
		Destroy (button);
		Timer = 0f;
	}
}
