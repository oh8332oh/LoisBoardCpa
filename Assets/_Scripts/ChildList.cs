using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildList : MonoBehaviour {


	public List<GameObject> childList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ListAdd(GameObject node)
	{
		childList.Add(node);
	}

	//+버튼 가지고 있는 노드에 자손이 있는지 확인한다.
	//자손이
	public void CheckList(GameObject node)
	{
		if(childList.Count == 0)
		{
			ListAdd(node);
			// ListAdd();
		}

	}

	public static ChildList Instance = null;
	private void Awake()
	{
			if(Instance == null)
			{
				Instance = this;
			}
	}


}
