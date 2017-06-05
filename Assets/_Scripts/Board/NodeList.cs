using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeList : MonoBehaviour {

	public static List<GameObject> childList = new List<GameObject>();
	
	//외부에서 넘어온 노드 오브젝트를 직접 받아서 리스트에 넣는다.
  public void CreateList(GameObject Node)
  {
		childList.Add(Node);
  }



	//싱글톤 구조
	public static NodeList Instance = null;
	private void Awake()
	{
			if(Instance == null)
			{
				Instance = this;
			}
	}


}
