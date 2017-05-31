using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;
public class NewBoard : MonoBehaviour {
	
	public static Scene MindMap;
	public static int Mindnum = 1;
	public static int currentScene;
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
			SceneManager.LoadScene (1);

			//EditorApplication.SaveScene ("Assets.unity");
			//SceneManager.UnloadScene (1);

			currentScene = Mindnum;
			Mindnum++;
			onetime = true;

			//ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
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
