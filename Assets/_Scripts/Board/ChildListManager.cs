using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildListManager : MonoBehaviour
{

    public GameObject leftNodePrefab;
    public GameObject righttNodePrefab;

    public List<GameObject> childList;


    void Start()
    {
        childList = new List<GameObject>();
    }



    //리스트에 노드를 추가시킨다. 
    //오버라이드를 사용

    public void ListAdd(float choiceVal)
    {
        GameObject node;

        if (choiceVal > 0)
        {
            node = Instantiate(righttNodePrefab);
        }
        else
        {
            node = Instantiate(leftNodePrefab);
        }


        // node.SetActive(false);
        // node.transform.position = 

        childList.Add(node);

    }

    //+버튼 가지고 있는 노드에 자손이 있는지 확인한다.
    //자손이
    public void CheckList(GameObject node)
    {
        if (childList.Count == 0)
        {

            // ListAdd(node);
            // ListAdd();

        }
    }



}

//삭제 누르면
//삭제 누른녀석의 자손리스트를 확인한다.
//리스트 있으면 그 리스트 리스트 자손의 자손이 리스트를 가지고 있는지 전부 조사 끝까지
//있으면 다 삭제하고
//+누른 노드 삭제.


