using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//노드를 만드는 기능
//
public class CreateNode : MonoBehaviour
{

  public GameObject nodePrefab;

	//생성할 때의 위치기록
	public Vector3 createPosition;
	public Quaternion createRotation;

  //외부에서 접근하기 위한 싱글톤 구조
  public static CreateNode Instance = null;
  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
  }//end of Awake()




  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void CreateBox(Vector3 position, Quaternion rotation)
  {
    GameObject node = Instantiate(nodePrefab);
    print(createPosition+"man");
		node.transform.position = position;
		node.transform.rotation = rotation;
  }


}
