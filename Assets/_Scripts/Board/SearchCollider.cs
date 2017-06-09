using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//충돌을 관리하는 스크립트
//한개만 존재한다.
//스태틱으로 메모리에 올린다.
public class SearchCollider : MonoBehaviour
{


  float currentTime;
  bool searchSwitch = false;
  //충돌여부에 따라서 노드를 만들지 안말들지 정하는 변수
  public bool createSwitch = false;

  //만들 노드프리펩을 넣는다
  public GameObject nodePrefab;

  int rotnum;

  public float createTime = 1f;

  Vector3 currentPostion;
  
  int count = 0;

  int collisionCount = 0;

  int createCount;
  int createCountMax = 11;

  //+버튼을 누르면
  //+버튼의 부모노드의 리스트를 받아온다.
  public ChildListManager currentManager;
  public Vector3 Posz;

  private GameObject Line;
  private GameObject CNode;
  public Material linema;
	public GameObject Nd;


  //외부에서 접근하기 위한 싱글톤 구조
  public static SearchCollider Instance = null;
  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
  }//end of Awake()



  Collider test;

  // Use this for initialization
  void Start()
  {





  }

  // Update is called once per frame
  void Update()
  {

    print(createSwitch);
    //currentPostion = transform.position;
    //print("addd" +transform.position);
    //currentTime+=Time.deltaTime;

    // print(createSwitch);
    // CreateNode.Instance.createPosition = transform.position;
    // print(transform.position);
    //충돌이 없으면 만든다.

    if (collisionCount == 0 && createSwitch)
    {
      createSwitch = false;
      CreateBox();

    }
    else if (collisionCount == 1 && createSwitch)
    {
      rotateBox();
    }
  }


  //먼저1사분면에서의 행동만 만든다.
  //으론쪽 30도 돌아간 지점에서 위로 30도씩 돌리면 왠만한거 해결가능

  public void SetPosition(Vector3 nodeDirection)
  {
    //충돌체가 다음 검색 위치에 도달한다.
    print(nodeDirection);
    transform.position = nodeDirection;
    transform.RotateAround(Vector3.zero, Vector3.up, 30);

    //충돌을 빠쟈나오고나서
    //코루틴이 실행되게 한다.
    StartCoroutine(checkCreation());
  }

  void rotateBox()
  {
    //돌리는 축이 한번 돌아가고나서부터 시작
    transform.Translate(3 * Vector3.up);

    rotnum++;
    print("rotation"+rotnum);

  }

  //충돌이 일어날 때 트리거
  void OnTriggerEnter(Collider other)
  {
    //부딪친 물체의 레이아웃이 box이면
    if (other.gameObject.layer == LayerMask.NameToLayer("Box"))
    {
      //충돌 카운트를 올린다.
      collisionCount++;
    }
  }
  //충돌상태에서 벗어날 때 트리거
  void OnTriggerExit(Collider other)
  {
    //충돌상태에서 벗어난 물체의 레이아웃이 box이면
    if (other.gameObject.layer == LayerMask.NameToLayer("Box"))
    {
      collisionCount--;
      print("exi");
    }
  }

  //충돌했는지 ??
  void CreateBox()
  {
    
    //노드생성
    //리스트에서 가져오는게 자연스러울듯?

    //리스트에서 마지막에 있는 노드를 가져오기위해 
    //길이 변수를 불러올 때마다 만든다.

    // print("length" + listLength);
    //리스트에서 불러와서 새로 담는다.
    // node.SetActive(true);

    // GameObject nodetest = Instantiate(nodePrefab);
    // ChildList.Instance.ListAdd(nodetest);

    //현재 리스트 매니저있는지 확인??


    //+버튼의 트랜스폼을 받아온다.
    
    // currentManager 
    // ChildList.Instance.ListAdd();

    currentManager.ListAdd();

    int listLength = currentManager.childList.Count;
    GameObject node = currentManager.childList[listLength - 1];

    
    //만든 노드를 리스트에 기록한다.
    // ChildList.Instance.CheckList(node);

	
    node.transform.position = transform.position;


    //하위 구조로 생성
    // node.transform.SetParent(CreateChildNode.Instance.setTreeStructure(), true);

    createCount++;

    node.transform.LookAt(Camera.main.transform.position);
    node.transform.Rotate(Vector3.up, 180f);

		Nd = node;
		Debug.Log ("쉣더퍽" + Posz);
		
  } 

  //코루틴 구문.
  IEnumerator checkCreation()
  {
    yield return new WaitForSeconds(0.1f);
    createSwitch = true;
  }
}
