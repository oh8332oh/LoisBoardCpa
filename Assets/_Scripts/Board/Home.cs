using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Home : MonoBehaviour {

	AudioSource audioHome;

	//public static Scene MindMap;
	public static int Mindnum = 0; //의미없음
	// Use this for initialization
	private bool gazedAt;      
	private bool onetime;
	private float Timer;
	private float gazeTime = 1.0f;
	private float at;
	// Use this for initialization
	void Start () {
		Timer = 0f;
		audioHome = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			Timer += Time.deltaTime;
		}

		if (gazedAt&&Timer>=gazeTime&&!onetime) {
			//Mindnum = SceneManager.GetActiveScene();
			NewBoard.currentScene = SceneManager.GetActiveScene().buildIndex;  //노드에 데이터를 입려력하고 다시저장하려 했느는데 이방방법이 아닌듯.
			SceneManager.LoadScene ("MainScene", LoadSceneMode.Single);  // MainScene 이라는 이름을 가진 씬을 불른다. Single은 MainScene 이외의 씬은 없앤다는 뜻
			onetime = true;

			//ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
			//Debug.Log ("true");
		}
	}

	public void PointerEnter()
	{   
		gazedAt = true;
		Debug.Log ("point enter");
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.15, "y", 0.6, "easeType", "easeOutBack"));

		audioHome.Play();
	}	

	public void PointerExit()
	{
		gazedAt = false;
		onetime = false;
		Timer = 0f;
		Debug.Log ("exit");
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0.1, "y", 0.4, "easeType", "easeOutBack"));

	}

	public void destroy()
	{
		
	}
	public void PointerDown()
	{
		//MindMap[Mindnum] = SceneManager.CreateScene ("MindMap" + Mindnum);
		//Mindnum++;
		//Debug.Log ("Created??");
	}
}
