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

		Camera.main.transform.LookAt(Vector3.zero);
	}

	public void PointerEnter()
	{   
		gazedAt = true;
		// Camera.main.transform.LookAt(Vector3.zero);
		
	}	

	public void PointerExit()
	{
		gazedAt = false;
		Timer = 0f;
	}

	public void rotR(){
		Camera.main.transform.RotateAround (Vector3.zero, Vector3.up, 1f); // 카메메라를 중심으로 무빙바를 회저전한다.
		Camera.main.transform.eulerAngles = new Vector3 (0, cnt, 0);  // 카메라의 시점을바꾸는함수인 줄 알았으나 실패 하지만 이런 형식으로 해야될것 같다.
		cnt++;
	}

}
