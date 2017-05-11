using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;   
public class Input : MonoBehaviour {
	public GameObject interfacePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject button = Instantiate (interfacePrefab); 


	}
}
