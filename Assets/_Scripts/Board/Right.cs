using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Right : MonoBehaviour {

	AudioSource audioRight;

	private bool gazedAt;      

	void Start () {
		audioRight = GetComponent<AudioSource>();

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
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.156, "y", 0.65, "easeType", "easeOutBack"));
        audioRight.Play();
	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{
		gazedAt = false;
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.12, "y", 0.5, "easeType", "easeOutBack"));

	}

	public void rotL(){
		CameraOb.Cam.transform.RotateAround (Vector3.zero, Vector3.up, 1f);
	}
}
