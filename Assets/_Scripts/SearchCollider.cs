using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    print(collisionCount);
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

      CreateBox();

    }
    else if (collisionCount == 1 && createSwitch)
    {
      rotateBox();
    }





    // if (createSwitch)
    // {

    // CreateNode.Instance.createPosition = transform.position;
    // print(currentPostion+"///"+currentTime);
    // print(transform.position);
    // print(CreateNode.Instance.createPosition);
    // CreateNode.Instance.createRotation = transform.rotation;

    // CreateNode.Instance.CreateBox(transform.position, transform.rotation);
    //   CreateBox();

    //   createSwitch = false;
    // }

    // if(test.isTrigger)
    // {
    //   print(test.isTrigger);
    // }




  }

  // IEnumerator CreateN()
  //   {
  //       while(createSwitch)
  //       {
  //          CreateNode.Instance.createPosition = transform.position;
  //     CreateNode.Instance.createRotation = transform.rotation;
  //     CreateNode.Instance.CreateBox();
  //           // yield return new WaitForSeconds(createTime);
  //           yield return null;
  //       }
  //   }

  //먼저1사분면에서의 행동만 만든다.
  //으론쪽 30도 돌아간 지점에서 위로 30도씩 돌리면 왠만한거 해결가능

  public void SetPosition(Vector3 nodeDirection)
  {
    //충돌체가 다음 검색 위치에 도달한다.
    print(nodeDirection);
    transform.position = nodeDirection;
    transform.RotateAround(Vector3.zero, Vector3.up, 30);


    //움직이고 나서
    //서칭한다.
    //충돌하면 돌아가고 충돌하지 않으면 생성
    // if (createCount == 0)
    // {
      StartCoroutine(checkCreation());
      
      // createSwitch = true;
    // }





    //충돌체크를 해야한다. => => 
    //충돌하면 이동 , 충돌 안하면 생성 / 이동x


    // CreateNode.Instance.createPosition = transform.position;
    // CreateNode.Instance.createRotation = transform.rotation;


    //물체가 있는지 없는지 확인한다.


    // createSwitch = true;




    // if(createSwitch){

    // CreateNode.Instance.CreateBox();
    // }




    // transform.RotateAround(Vector3.zero, Vector3.right, 30f);

  }

  void rotateBox()
  {
    //돌리는 축이 한번 돌아가고나서부터 시작

    print("sibal");
    // Quaternion v3Rotation = Quaternion.Euler(0, 30, 0);

    // transform.RotateAround(Vector3.zero, v3Rotation * Vector3.right, 30);
    transform.Translate(3*Vector3.up);

  


    // CreateNode.Instance.createPosition = transform.position;
    // CreateNode.Instance.createRotation = transform.rotation;


    rotnum++;
    print(rotnum);

  }

  /// <summary>
  /// OnTriggerEnter is called when the Collider other enters the trigger.
  /// </summary>
  /// <param name="other">The other Collider involved in this collision.</param>
  void OnTriggerEnter(Collider other)
  {


    if (other.gameObject.layer == LayerMask.NameToLayer("Box"))
    {
      collisionCount++;
      print("ent");

      // createSwitch = false;
      // searchSwitch = true;
      // rotateBox();

      // print(createSwitch);

    }



  }

  /// <summary>
  /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
  /// </summary>
  /// <param name="other">The other Collider involved in this collision.</param>
  void OnTriggerExit(Collider other)
  {
    

    if (other.gameObject.layer == LayerMask.NameToLayer("Box"))
    {

      collisionCount--;
      print("exi");
    }
  }


  public void CreateOn()
  {
    // createSwitch = true;
  }


  //충돌했는지 ??

  void CreateBox()
  {
    GameObject node = Instantiate(nodePrefab);
    node.transform.position = transform.position;
    createSwitch = false;

    //하위 구조로 생성
    node.transform.par

    createCount++;

    node.transform.LookAt(Camera.main.transform.position);
    node.transform.Rotate(Vector3.up, 180f);



  }

  IEnumerator checkCreation()
  {
    yield return new WaitForSeconds(0.2f);
    createSwitch = true;
  }




}
