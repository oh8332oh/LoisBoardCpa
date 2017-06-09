using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//의미없는 스크립트

public class Node : MonoBehaviour
{   
	public static List<NodeI> NodeIn = new List<NodeI> ();
	public static Node Instance = null;
	public GameObject Root;
	private void Awake()
	{
		if (Instance == null) {
			Instance = this;
		}
	}
	public class NodeI
	{    
		GameObject Node;
		NodeI MNode;
		NodeI[] CNode;
		public NodeI(GameObject nNode, NodeI nMNode){
			this.Node = nNode;
			this.MNode = nMNode;
		}
		public void CAdd(NodeI nNodeI, NodeI CNode){
			int i = 0;
			while(nNodeI.CNode[i].Node){
				i++;
			}
			nNodeI.CNode [i] = CNode;
		}
		public void Delete (NodeI nNodeI){
			Destroy(nNodeI.Node);
		}
		void update(){
			if (Node == null)
				for (int i = 0; i < CNode.Length; i++) {
					Destroy(CNode [i].Node);
				}
		}
	}

}