using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   

public class CreateChildNode : MonoBehaviour {

	public GameObject Node;
	public GameObject CNode;
	private Vector3 tempLoc;
	private Vector2 Loc;
	private bool gazedAt;      
	private bool onetime;
	private Quaternion tempRot;
	private float Timer;
	private float gazeTime = 1f;
	void Start () {
		tempLoc = transform.position;
		tempRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			Timer += Time.deltaTime;
		}
		if (Timer>=gazeTime&&gazedAt&&!onetime) {
			CreateChild ();
			onetime = true;	
		}
	}

	public void PointEnter()
	{
		gazedAt = true;
	}

	public void PointerExit()   // 커서가 오브젝트를 벗어나면 크기를 원상  복구 한다.
	{

		gazedAt = false;
		onetime = false;
		Timer = 0f;
	}

	public void CreateChild()
	{ 
		tempLoc.x = Mathf.Sin(Mathf.Deg2Rad*30f*GlobalV.number)*10f;
		tempLoc.y = 0;
		tempLoc.z = Mathf.Cos (Mathf.Deg2Rad*30f * GlobalV.number)*10f;
		CNode = Instantiate (Node,tempLoc,tempRot);
		CNode.transform.Rotate (new Vector3 (0, 30*GlobalV.number, 0));
		CNode.name = "Node" + Loc.x +", "+ Loc.y;
		GlobalV.number++;
		Debug.Log (GlobalV.number);
	}

}
