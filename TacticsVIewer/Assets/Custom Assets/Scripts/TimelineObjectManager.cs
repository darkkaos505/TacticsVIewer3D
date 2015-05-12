using UnityEngine;
using System.Collections;

public class TimelineObjectManager : MonoBehaviour
{

    ArrayList timeLineObjectList;

    public GameObject HornetPrefab;
    public GameObject HornetPreviewPrefab;
   
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        timeLineObjectList = new ArrayList();
    }
    // Use this for initialization
    void Start()
    {
        QualitySettings.antiAliasing = 8;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
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

    public void AddHornet()
    {
        GameObject hornetObjectGame = Instantiate(HornetPrefab, transform.position, transform.rotation) as GameObject;

        ObjectViewer.instance.AddObject(hornetObjectGame);

        timeLineObjectList.Add(hornetObjectGame.GetComponent<TimeLineObject>());

    }

    public void ShowAllPaths()
    {
        if (timeLineObjectList != null)
        {
            foreach (TimeLineObject obj in timeLineObjectList)
            {
                obj.ShowPath();
            }
        }
    }

    public void HideAllPaths()
    {
        if (timeLineObjectList != null)
        {
            foreach (TimeLineObject obj in timeLineObjectList)
            {
                obj.HidePath();
            }
        }
    }
}
