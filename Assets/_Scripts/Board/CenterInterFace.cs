using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   
public class CenterInterFace : MonoBehaviour {
	public GameObject interfacePrefab;
	private GameObject button;
	private GameObject interfacePre;
	private bool gazedAt;      
	private bool onetime;
	private Vector3 tempLoc;
	private Quaternion tempRot;
	private float Timer;
	private float gazeTime = 0.0f;
	// Use this for initialization
	void Start () {
		tempLoc = gameObject.transform.position;
		tempRot = gameObject.transform.rotation;
		Timer = 0f;
		interfacePre = gameObject.transform.FindChild ("CenterInterface").gameObject;
		interfacePre.SetActive (false);
		interfacePre.transform.position = tempLoc;
		interfacePre.transform.rotation = tempRot;
	}

	// Update is called once per frame
	void Update () {
		


		if (gazedAt) {
			Timer += Time.deltaTime;
		}

		//바라보게 되면 
		if (Timer>=gazeTime&&gazedAt&&!onetime) {


			//노드를 생성한다.
		//	button = Instantiate (interfacePrefab,tempLoc,tempRot);
		//	button.transform.parent = gameObject.transform;
			//onetime = true;	
		//	print("on");
		}
		//gameObject.transform.RotateAround (Vector3.zero, Vector3.up, 30f*Time.deltaTime);
	
	
	}

	public void PointerEnter()
	{   
		gazedAt = true;
		interfacePre.SetActive (true);
	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{
		
		gazedAt = false;
		onetime = false;

		print(gazedAt);
	    print(onetime);
		interfacePre.SetActive (false);
		// gameObject.SetActive(button);
		//Destroy (button);
		Timer = 0f;
	}
	
}
