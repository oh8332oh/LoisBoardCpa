using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo
{    
	public Vector2 parent;
	public Vector2 location;
	public GameObject node;

	public NodeInfo(GameObject newnode, Vector2 newparent, Vector2 newlocation){
		this.node = newnode;
		this.location = newlocation;
		this.parent = newparent;
	}
}
