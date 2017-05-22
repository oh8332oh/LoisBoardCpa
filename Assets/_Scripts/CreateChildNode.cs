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


  void Start()
  {
    tempLoc = transform.position;
    tempRot = transform.rotation;
    nodecount = 0;


    startDirection = transform.parent.position;
	


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

  //포인터 다운이 발동 되면
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
    if (CameraRay.Instance.SearchRight(startDirection))
    {
			//충돌이 있었다면 / 오른쪽에 박스가 있다면
			//시작할 방향 변수를 전달해야 한다.
			
			
			


      //써칭한다.
      //그 지점에서 z축을 중심으로 회전하면서 써칭한다.
      //시작지점 값을 보낸다.
			//시작 지점 값은 누른 플러스 버튼의 바로 오른쪽의 충돌 지점의 위쪽이다.
      if (CameraRay.Instance.SearchPosition(startDirectionY))
      {
        CreateChildY();
      }
      else
      {
        CreateChildY();
      }

    }
    else
    {
      CreateChildX();
    }


    // if(switchOnX){
    // //노드 생성하는 함수를 켠다.
    // CreateChild ();
    // }else{


    // }




    onetime = true;



  }

  //만드는 역할만 수행할 수 있게 한다. 
  public void CreateChildX()
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
    startDirectionY = CNode.transform.position;
    CNode.transform.LookAt(Camera.main.transform.position);
    CNode.transform.Rotate(Vector3.up, 180f);
    CNode.name = "Node" + Loc.x + ", " + Loc.y;
    // Debug.Log (GlobalV.number);

		GameObject poz = new GameObject ();
		poz.transform.position = transform.parent.position + new Vector3 (-1.5f, 0f, 0f);;
		poz.transform.RotateAround(Vector3.zero, Vector3.up, 30f);
		poz.transform.LookAt(Camera.main.transform.position);
		poz.transform.Rotate(Vector3.up, 180f);
		linedraw (CNode,transform.position, poz.transform.position);
		Destroy (poz);
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
		GameObject poz = new GameObject ();
		poz.transform.position = CameraRay.Instance.hitLocation;
		poz.transform.position -= new Vector3 (1.5f, 0, 0);
		poz.transform.RotateAround(Vector3.zero, Vector3.right, -30f);
		poz.transform.LookAt(Camera.main.transform.position);
		poz.transform.Rotate(Vector3.up, 180f);
		linedraw (CNode,transform.position, poz.transform.position);
		Destroy (poz);
  }

	public void linedraw(GameObject mother, Vector3 start,Vector3 End)
	{
		Line = new GameObject ("Line");
		Line.transform.parent = CNode.transform;
		Line.AddComponent<LineRenderer> ();
		Line.GetComponent<LineRenderer> ().endWidth = 0.1f;
		Line.GetComponent<LineRenderer> ().startWidth = 0.1f;
		//Line.GetComponent<LineRenderer> ().SetColors(color ,color);
		Line.GetComponent<LineRenderer> ().SetPosition (0, start);
		Line.GetComponent<LineRenderer> ().SetPosition (1, End);
		Line.GetComponent<LineRenderer> ().material = linema;


		/*
		lineRenderer = Line.AddComponent<LineRenderer> ();
		lineRenderer.material = new Material (Shader.Find ("Particles/Additicve"));
		lineRenderer.SetColors (Color.grey, Color.grey);
		lineRenderer.SetWidth (0.2f, 0.2f);
		lineRenderer.SetVertexCount (2);
		*/
		Debug.Log (start + "and" + End);
	}

}
