using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLi : MonoBehaviour {

	public static List<NodeI> NodeIn = new List<NodeI>();
	//public static int[,] nodeLoc = new int[12, 20];
	public static NodeLi Instance = null;
	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
	}

	public sealed class NodeI {
		GameObject Node;
		NodeI MNode;
		NodeI[] CNode;

		public void DestroyChild(){
			for (int i = 0; i < CNode.Length; i++) {
				Destroy (CNode [i].Node);
			}
		}

	}



}

