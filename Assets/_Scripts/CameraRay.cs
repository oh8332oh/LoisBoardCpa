using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{



  Vector3 start = Vector3.forward;

  public GameObject NodePrefab;


  public static CameraRay Instance = null;

  float distance = 11f;

  public Vector3 hitLocation = new Vector3(0, 0, 10);



  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
  }


  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  public bool SearchPosition(Vector3 startDirection)
  {

    //사용자의 위치 중심에서 순차적으로 광선으로 보내는 알고리즘
    //1. 카메라 위치 에서 ray를 만든다.

    //카메라의 위치값을 받아와서 변수에 넣는다.
    //임시. 새로운 값이 있으면 그것으로 바꿀것
    //z높이가 추가되면
    Vector3 sourcePoint = Vector3.zero;



    //y축을 중심으로 순차적으로 회전하며 방향을 잡는다.
    //방향을 의미하는 변수를 만든다.

    bool collideOn = false;

    //충돌에 따라서 분류
    //충돌하면

    RaycastHit hitInfo = new RaycastHit();



    for (int i = 0; i < 12; i++)
    {

      Quaternion v3Rotation = Quaternion.Euler(-30f * i, 0, 0);  // 회전각

      //초기 서칭 기준점은 플러스 버튼을 누른 부모의 오른쪽 한칸이어야 한다.



      Vector3 rayDirection = v3Rotation * startDirection;

      

      //확인하기 위한 라인 그리기
      float duration = 200.0f;
      Debug.DrawLine(sourcePoint, rayDirection, Color.red, duration);


      //중심점과 방향을 지정하여 ray생성
      Ray ray = new Ray(sourcePoint, rayDirection);

      if (Physics.Raycast(ray, out hitInfo, distance))
      {
        print("hit");

        collideOn = true;

      }
      else
      {

        //4. ray 가 에 부딪히지 않으면
        //  - 박스를 생성]

        print("nohit");




        collideOn = false;

        // Node = Instantiate(NodePrefab);


        break;
      }
      // GameObject hitobj=hitInfo.transform.gameObject;
      // hitLocation = hitobj.transform.position;

      hitLocation = hitInfo.point;
      print(hitLocation);


    }

    return collideOn;

  }//end of SearchPostion

  public bool SearchRight(Vector3 startDirection)
  {
    Vector3 sourcePoint = Vector3.zero;

    Quaternion v3Rotation = Quaternion.Euler(0, 30, 0);
    Vector3 rayDirection = v3Rotation * startDirection;


    //레이를 생성한다.
    Ray ray = new Ray(sourcePoint, rayDirection);
    RaycastHit hitInfo = new RaycastHit();



    bool collideOn =false;
    //레이 충돌에 따라서
    //충돌하면 
    if(Physics.Raycast(ray, out hitInfo, distance)){

      collideOn = true;
      print("hit");

      //충돌이 일어났으면 츙돌 위치 값을 전달한다.
      // CreateChildNode.startDirectionY = hitInfo.transform.position;
      
      // CreateChildNode.startDirectionY = 

      print(hitInfo.transform.position);

    }else{
      collideOn = false;
      print("nohit");
    }

     //확인하기 위한 라인 그리기
      float duration = 200.0f;
      Debug.DrawLine(sourcePoint, rayDirection, Color.green, duration);

    return collideOn;


  }








}
