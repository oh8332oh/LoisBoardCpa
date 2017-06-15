using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NewBoard : MonoBehaviour {

	AudioSource audioHover;

	
	public static Scene MindMap; //의미없음
	public static int Mindnum = 1;  // 새로운 마인드맵들에게 넘버링하려고 시도할려했던것
	public static int currentScene; //현재의 씬을 저장하려는 변수
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
			SceneManager.LoadScene (1); //1에 저장된 씬을 로드한다. -> 1은 빌드셋팅에 윗부분에 있ㅏ.

			//EditorApplication.SaveScene ("Assets.unity");
			//SceneManager.UnloadScene (1);

			currentScene = Mindnum; // 의미없음
			Mindnum++;  //의미없음
			onetime = true;

			//ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
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
	/*
	public void UnLoadScene (int scene)
	{
		StartCoroutine(Unload (scene));
	}
	IEnumerator Unload(int scene)
	{
		yield return null;
		SceneManager.UnloadScene (scene);
	}
	*/
}
