using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateChildNode : MonoBehaviour
{
  public Material linema;
  public Vector3 arrowInput1;
  public Vector3 arrowInput2;
  public GameObject Node;
  public GameObject CNode;
  private Vector3 tempLoc;
  private Vector2 Loc;
  private bool gazedAt;
  private bool onetime;
  private Quaternion tempRot;
  private float Timer;
  private float gazeTime = 1f;
  private float nodecount;
  public static Vector3 startDirectionY;
  public LineRenderer lineRenderer;
  private GameObject Line;
  //부딪쳤을 때 부딪친 노드를 바라보는 방향 벡터
  Vector3 startDirection;

  Vector3 parentPostion;


   //외부에서 접근하기 위한 싱글톤 구조
  public static CreateChildNode Instance = null;
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
    // gazedAt = true;
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
    //먼저 레이를 발생시켜서 검사가 되면 => 노드를 생성한다.

    //1. 오른쪽 한번만 탐색해서 아무것도 없으면 노드를 생성하고 있으면 위쪽방향으로 생성한다.

    //임시로 여부를 확인할 리턴값 생성
    // bool rightSearch = 		CameraRay.Instance.SearchRight();


    //레이를 사용한다.
    // bool switchOnX = CameraRay.Instance.SearchPosition(startDirection);

    //만약에 오른쪽에 박스가 있으면 
    //
    // if (CameraRay.Instance.SearchRight(startDirection))
    // {
    // 	//충돌이 있었다면 / 오른쪽에 박스가 있다면
    // 	//시작할 방향 변수를 전달해야 한다.


    onetime = true;


    //   //써칭한다.
    //   //그 지점에서 z축을 중심으로 회전하면서 써칭한다.
    //   //시작지점 값을 보낸다.
    // 	//시작 지점 값은 누른 플러스 버튼의 바로 오른쪽의 충돌 지점의 위쪽이다.
    //   if (CameraRay.Instance.SearchPosition(startDirectionY))
    //   {
    //     CreateChildY();
    //   }
    //   else
    //   {
    //     CreateChildY();
    //   }

    // }
    // else
    // {
    //   CreateChildX();
    // }





    /*--------------------------------------------------*/
    //다시 작성
    //먼저 부모 +버튼을 누른 녀석의 노드를 탐색한다.
    //부모 노드에 있는 리스트에 자식이 있는지 확인한다.




    /*--------------------------------------------------*/


    //보이지않는 충돌체를 일정한 규칙으로 이동시키면서
    //충돌하지 않을때 생성하도록 만든다.

    //한개의 콜라이더를 가지고 컨트롤 하여서 충돌을 체크한다. 

    //1. +버튼을 클릭하면 
    //2. 미리 만들어둔 콜라이더를 움직인다
    //3. 이것을 어떻게 움직이는 지가 핵심 => 자세한 행동은 나중에 생각을 더한다.
    //4. 먼저 기존의 방식대로 x => 기존의 방식일지라도 배열로 만드는 것은 아니고 충돌 여부를 체크한다.
    //5. 충돌 체크 했으면 있으면 더 이동시켜보고 없으면 그자리에 생성

    //구조
    //+버튼을 눌럿을 때 => 
    //움직이는 기능
    //충돌하는지를 알아보는 기능 =>
    //만드는 기능 =>


    //1. +버튼 누르면 => +버튼을 가지고 있는 노드의 포지션 값을 넘긴다.
    //2. 포지션 값을 받아서 정해둔 알고리즘으로 움직인다. 

    //+버튼을 눌러서 충돌체를 움직인다.
    SearchCollider.Instance.SetPosition(parentPostion);
    // SearchCollider.Instance.createSwitch = true;
    // SearchCollider.Instance.createSwitch = true;


    // CreateNode.Instance.CreateBox();



    int nodeCount = NodeList.childList.Count;

    if (true)
    {
      //   //리스트에 아무것도 없다면 리스트에 노드를 넣고 생성한다.
      //   //먼저 노드를 생성한다. 만든 곳에서 

      // NodeList.Instance.CreateList(testnode);




    }
    // else
    // {
    //   //리스트에 들어있다면
    //   //리스트의 숫자를 읽어서 각도로 활용한다.
    //   //먼저 마지막의 노드를 가져온다.
    //   GameObject testnode1 = Instantiate(Node);



    //   SetPosition(testnode1, nodeCount);
    //   NodeList.Instance.CreateList(testnode1);


    // }


    //+ 버튼을 누르면
    //눌러진 노드를 부모로하는 자식으로서 만들어진다.
    //+버튼이 눌려진 노드에 리스트가 존재한다.
    //1. 부모에게 리스트가 있는지 확인한다.
    //2. 없으면 리스트를 만들고
    //3. 있으면 리스트에 추가시킨다.

    //삭제할때 자식의자식은 어떻게 삭제할 것인가???
    //1. 자식 리스트의 각자 가지고 리스틀 가지고 있는지 전부 확인하면서
    //2. 없을 때까지 서칭한다.

    //--끝--


    //캔버스 문제 발생
    // 두번째 전략
    //신에서 계층구조로 만들어서 다 삭제한다.
    //노드를 생성할 때 +누른녀석 밑으로 들어가게 만든다.
    //나중에 지울때 그녀석 지우면 밑에 다날라감!

    //두번째가 편하지만
    // 나중에 어떻게 변할지 모른다.


    //첫번째 방식을 사용
    
    ChildList.Instance.CheckList(CNode);








  }

  //만드는 역할만 수행할 수 있게 한다. 
  public GameObject CreateChildX()
  {


    /*
		tempLoc.x = Mathf.Sin(Mathf.Deg2Rad*30f*GlobalV.number)*10f;
		tempLoc.y = 0;
		tempLoc.z = Mathf.Cos (Mathf.Deg2Rad*30f * GlobalV.number)*10f;
		*/

    //tempLoc += new Vector3 (5f, 0f, -5 * Mathf.Tan(Mathf.Deg2Rad * 15f));
    //*5/Mathf.Cos(Mathf.Deg2Rad*15f)
    //CNode.transform.TransformDirection(new Vector3(5,0,-5*Mathf.Tan(Mathf.Deg2Rad * 15f)));
    //CNode.transform.Translate(new Vector3(3.4f,0,-3.4f*Mathf.Tan(Mathf.Deg2Rad * 15f)),Space.Self);
    //CNode.transform.Rotate (new Vector3 (0, 30, 0));

    //int a = 1;
    //GlobalV.a++;
    //if(GlobalV.nodeLoc[a,GlobalV.b-1] == 1)
    //{
    CNode = Instantiate(Node);
    //CNode.transform.parent = gameObject.transform.parent.parent;
    // Vector3 a = transform.position - new Vector3(-1.7f,1.5f-3f*nodecount,0);
    // Vector3 b = transform.parent.position;


    //위치 보정
    // CNode.transform.Translate(new Vector3(-1.7f,1.5f-3f*nodecount,0));

    CNode.transform.position = transform.parent.position;
    CNode.transform.RotateAround(Vector3.zero, Vector3.up, 30f);
    // startDirectionY = CNode.transform.position;
    // CNode.transform.LookAt(Camera.main.transform.position);
    // CNode.transform.Rotate(Vector3.up, 180f);
    // CNode.name = "Node" + Loc.x + ", " + Loc.y;

    // GameObject poz = new GameObject ();
    // poz.transform.position = transform.parent.position + new Vector3 (-1.5f, 0f, 0f);;
    // poz.transform.RotateAround(Vector3.zero, Vector3.up, 30f);
    // poz.transform.LookAt(Camera.main.transform.position);
    // poz.transform.Rotate(Vector3.up, 180f);
    // linedraw (CNode,transform.position, poz.transform.position);
    // Destroy (poz);

    return CNode;
  }

  public void CreateChildY()
  {

    CNode = Instantiate(Node);
    //CNode.transform.parent = gameObject.transform.parent.parent;
    //충돌지점으로 노드를 둔다.
    CNode.transform.position = CameraRay.Instance.hitLocation;
    CNode.transform.RotateAround(Vector3.zero, Vector3.right, -30f);

    //카메라를 향하게 한다.
    CNode.transform.LookAt(Camera.main.transform.position);
    //180도 돌려서 정면을 바라보게 한다.
    CNode.transform.Rotate(Vector3.up, 180f);
    GameObject poz = new GameObject();
    poz.transform.position = CameraRay.Instance.hitLocation;
    poz.transform.position -= new Vector3(1.5f, 0, 0);
    poz.transform.RotateAround(Vector3.zero, Vector3.right, -30f);
    poz.transform.LookAt(Camera.main.transform.position);
    poz.transform.Rotate(Vector3.up, 180f);
    linedraw(CNode, transform.position, poz.transform.position);
    Destroy(poz);
  }

  public void linedraw(GameObject mother, Vector3 start, Vector3 End)
  {
    Line = new GameObject("Line");
    Line.transform.parent = CNode.transform;
    Line.AddComponent<LineRenderer>();
    Line.GetComponent<LineRenderer>().endWidth = 0.1f;
    Line.GetComponent<LineRenderer>().startWidth = 0.1f;
    //Line.GetComponent<LineRenderer> ().SetColors(color ,color);
    Line.GetComponent<LineRenderer>().SetPosition(0, start);
    Line.GetComponent<LineRenderer>().SetPosition(1, End);
    Line.GetComponent<LineRenderer>().material = linema;


    /*
		lineRenderer = Line.AddComponent<LineRenderer> ();
		lineRenderer.material = new Material (Shader.Find ("Particles/Additicve"));
		lineRenderer.SetColors (Color.grey, Color.grey);
		lineRenderer.SetWidth (0.2f, 0.2f);
		lineRenderer.SetVertexCount (2);
		*/
    Debug.Log(start + "and" + End);
  }


  public Transform setTreeStructure()
  {
    Transform parent = gameObject.transform.parent.parent;
    return parent;
  }



}
