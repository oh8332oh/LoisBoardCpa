using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ExistBoard : MonoBehaviour {

	AudioSource audioHover;

	private Scene exist;
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
		audioHover = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			Timer += Time.deltaTime;
		}

		if (gazedAt&&Timer>=gazeTime&&!onetime) {
			SceneManager.LoadSceneAsync (NewBoard.currentScene);  // Home 에서 저장한 노드에 데이터가 입력된 씬을 부르려 했으나 실패
			//	Mindnum++;
			onetime = true;
			//ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
			//Debug.Log ("true");
		}
	}

	public void PointerEnter()
	{   
		gazedAt = true;
		Debug.Log ("point enter");
		iTween.ScaleTo(gameObject, iTween.Hash("x", 3.6, "y", 2.4, "easeType", "easeOutBack"));
        audioHover.Play();
	}	

	public void PointerExit()
	{
		gazedAt = false;
		onetime = false;
		Timer = 0f;
		Debug.Log ("exit");
		iTween.ScaleTo(gameObject, iTween.Hash("x", 3, "y", 2, "easeType", "easeOutBack"));

	}
	public void PointerDown()
	{
		//MindMap[Mindnum] = SceneManager.CreateScene ("MindMap" + Mindnum);
		//Mindnum++;
		//Debug.Log ("Created??");
	}
}
