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

        //+버튼을 누르면 생성이나 마찬가지므로
        //리스트에 담을 준비를한다.


        GameObject tempC;

        string buttonName;

        if(transform.position.x > 0)
        {
            buttonName = "forChild";
        }
        else
        {
            buttonName = "forParent";
        }


        tempC = transform.root.gameObject.transform.FindChild(buttonName).gameObject;
        Vector3 StartP = tempC.transform.position;
		Vector3 tem = gameObject.transform.root.transform.right * 0.2f;
		StartP = StartP - tem;
        SearchCollider.Instance.lineStartPosition = StartP;





        SearchCollider.Instance.currentManager = transform.root.GetComponent<ChildListManager>();

        //+버튼을 눌러서 충돌체를 움직인다.

        Vector3 currentPosition = transform.position;
        SearchCollider.Instance.SetPosition(parentPostion, currentPosition);


        //좌표값을 넘겨 준다. 
        //여기에서 좌표값을 잡는다.




        // Vector3 EndP;
        // GameObject temp;
        // temp = SearchCollider.Instance.Nd;
        // EndP = temp.transform.FindChild("forParent").gameObject.transform.position;
        // linedraw(temp, StartP, EndP);
        // Debug.Log(StartP + "  " + EndP);



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

    }


    public Transform setTreeStructure()
    {
        Transform parent = gameObject.transform.parent.parent;
        return parent;
    }


    //+버튼을 누르면
    //매니저를 만들어서
    //리스트를 관리한다.
    //+버튼에 붙은 부모 노드에 접근해서
    //리스트를 컨트롤한다.




}
