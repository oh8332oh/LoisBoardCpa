﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeleteNode : MonoBehaviour
{
  private Vector3 tempLoc;
  private bool gazedAt;
  private bool onetime;
  private Quaternion tempRot;
  private float Timer;
  private float gazeTime = 1f;
  private float nodecount;

  Vector3 startDirection;

  Vector3 parentPostion;


   //외부에서 접근하기 위한 싱글톤 구조
  public static DeleteNode Instance = null;
  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
  }//end of Awake()

  void Start()
  {
    tempLoc = transform.position;
    tempRot = transform.rotation;
    nodecount = 0;


    startDirection = transform.parent.position;

    parentPostion = transform.parent.position;

  }

  // Update is called once per frame
  void Update()
  {
    if (gazedAt)
    {
      Timer += Time.deltaTime;
    }

    //몇초동안 바라보면 => 버튼을 생성하게 한다
    //몇초동안 바라보면 포인터 다운 발동.
    if (Timer >= gazeTime && gazedAt && !onetime)
    {
      ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
      nodecount++;
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

  //포인터를 두고 클릭시
  public void PointerDown()
  {
    onetime = true;


		//삭제하는법
		//먼저 마이너스버튼에 달려 있는 노드를 탐색한다
		//그 노드에 리스트가 있는지 찾아본다.
		//리스트안에 있

		//1. 노드에 붙어 있는 리스트 확인한다.

		// List<GameObject> test = ChildList.Instance.childList;
		// print(test);

    for(int i = 0 ; i < ChildList.Instance.childList.Count; i++)
    {
      if(ChildList.Instance.childList[i] != null)
      {
        Destroy(ChildList.Instance.childList[i]);
      }
    }



		

  }




}