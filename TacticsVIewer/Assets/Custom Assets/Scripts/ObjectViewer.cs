using UnityEngine;
using System.Collections;

public class ObjectViewer : MonoBehaviour
{

    Animator animator;

    public GameObject objectViewedPrefab;
    public RectTransform startPoint;



    ArrayList viewedObjectList;
    //Here is a private reference only this class can access
    private static ObjectViewer _instance;

    //This is the public reference that other classes will use
    public static ObjectViewer instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<ObjectViewer>();
            return _instance;
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        viewedObjectList = new ArrayList();
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Show");
            animator.ResetTrigger("Hide");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Hide");
            animator.ResetTrigger("Show");
        }
    }

    public void AddObject(GameObject timeLineObjectGame)
    {
        viewedObjectList.Add(timeLineObjectGame);

        GameObject viewedObjectGame = Instantiate(objectViewedPrefab, transform.position, transform.rotation) as GameObject;
        ViewedObject viewedObject = viewedObjectGame.GetComponent<ViewedObject>();

        viewedObject.SetTimelineObject(timeLineObjectGame);

        RectTransform rectTransform = viewedObject.GetComponent<RectTransform>();
        rectTransform.position = startPoint.position - Vector3.up * rectTransform.rect.width*( viewedObjectList.Count-1);
        

        rectTransform.SetParent(GetComponent<RectTransform>());

    }
}
