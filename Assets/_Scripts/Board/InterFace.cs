using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   
public class InterFace : MonoBehaviour {

    AudioSource audioNode;

	private GameObject interfacePre;
	private bool gazedAt;      
	private bool onetime;
	private Vector3 tempLoc;
	private Quaternion tempRot;
	private float Timer;
	private float gazeTime = 0.5f;
	// Use this for initialization
	void Start () {

        audioNode = GetComponent<AudioSource>();


		tempLoc = gameObject.transform.position;
		tempRot = gameObject.transform.rotation;
		Timer = 0f;
		interfacePre = gameObject.transform.FindChild ("Interface").gameObject;
		interfacePre.SetActive (false);
		interfacePre.transform.position = tempLoc;
		interfacePre.transform.rotation = tempRot;
	}

	// Update is called once per frame
	void Update () {
		
		if (gazedAt) {
			Timer += Time.deltaTime;
		}

		if (Timer>=gazeTime&&gazedAt&&!onetime) {
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
		}

	}

	public void PointerEnter()
	{   
		gazedAt = true;
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.0048, "y", 0.006, "easeType", "easeOutBack"));
		interfacePre.SetActive (true);
        audioNode.Play();

	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{
		
		gazedAt = false;
		onetime = false;
		interfacePre.SetActive (false);
		Timer = 0f;
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.004, "y", 0.005, "easeType", "easeOutBack"));

	}

	public void PointerDown()
	{
		
	}
}
