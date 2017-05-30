using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Right : MonoBehaviour {
	private bool gazedAt;      
	private float Timer;
	private float gazeTime = 1.0f;
	private float at;
	private float cnt=0;
	// Use this for initialization
	void Start () {
		Timer = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		   

		  //  Camera.main.transform.eulerAngles = new Vector3 (0, cnt, 0);
			if (gazedAt&&(Camera.main.transform.position != Vector3.zero)) {
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
			//bar.transform.RotateAround (Camera.main.transform.position, Vector3.up, -0.5f);
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

	public void rotR(){
		Camera.main.transform.RotateAround (Vector3.zero, Vector3.up, 1f);
		Camera.main.transform.eulerAngles = new Vector3 (0, cnt, 0);
		cnt++;
	}

}
