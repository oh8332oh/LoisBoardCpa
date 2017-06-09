using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   
public class InputInterface : MonoBehaviour {
	public GameObject interfacePrefab;
	public GameObject button;
	private bool gazedAt;      
	private bool onetime;

	// Use this for initialization
	void Start () {
    		
	}
	
	// Update is called once per frame
	void Update () {
  
	  if (gazedAt&&!onetime) {
	     button = Instantiate (interfacePrefab);
			onetime = true;
	  }
	}
	public void PointerEnter()
	{
	  gazedAt = true;
	}	

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{
	  gazedAt = false;
	  onetime = false;
	  DestroyObject (button);
	}

}
