// public class CreateObj : MonoBehaviour {

//     public GameObject targObj;

//     public List<GameObject> childObj;

//     bool inputCheck;
     
//    // Use this for initialization
//    void Start () {
//         childObj = new List<GameObject>();
//         inputCheck = false;
//    }
   
//    // Update is called once per frame
//    void Update ()
//     {
//         if (Input.GetKeyDown("space"))
//         {
//             targObj = new GameObject();
//             //Instantiate(targObj, transform.position, Quaternion.identity, transform);
//             targObj.AddComponent<ListOnly>();
//             childObj.Add(targObj);

//             inputCheck = true;
//         }
//    }
// }