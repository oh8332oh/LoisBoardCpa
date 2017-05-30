using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Home : MonoBehaviour {

	public static Scene MindMap;
	public static int Mindnum = 0;
	// Use this for initialization
	private bool gazedAt;      
	private bool onetime;
	private float Timer;
	private float gazeTime = 1.0f;
	private float at;
	// Use this for initialization
	void Start () {
		Timer = 0f;
	}

	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			Timer += Time.deltaTime;
		}

		if (gazedAt&&Timer>=gazeTime&&!onetime) {
			MindMap = SceneManager.GetActiveScene();
			SceneManager.LoadScene ("MainScene", LoadSceneMode.Single);

			//Mindnum++;
			onetime = true;

			//ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
			//Debug.Log ("true");
		}
	}

	public void PointerEnter()
	{   
		gazedAt = true;
		Debug.Log ("point enter");
	}	

	public void PointerExit()
	{
		gazedAt = false;
		onetime = false;
		Timer = 0f;
		Debug.Log ("exit");
	}
	public void PointerDown()
	{
		//MindMap[Mindnum] = SceneManager.CreateScene ("MindMap" + Mindnum);
		//Mindnum++;
		//Debug.Log ("Created??");
	}
}
