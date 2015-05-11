using UnityEngine;
using System.Collections;

public class KeyframeArrowManager : MonoBehaviour
{
     TimeLineObject timeLineObject;

    ArrayList arrowList;

    public GameObject arrowPrefab;


    public RectTransform StartPoint;
    public RectTransform EndPoint;

    // Use this for initialization
    void Start()
    {


        arrowList = new ArrayList();
         
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetSelectedObject(GameObject selectedObject)
    {

        if (selectedObject != null)
        {
            timeLineObject = selectedObject.GetComponent<TimeLineObject>();
            SetUpArrows();
        }
        else
        {
            timeLineObject = null;
             ResetArrows();
        }
    }

    void SetUpArrows()
    {
        ResetArrows();

        ArrayList keyframeList = timeLineObject.GetKeyframeList();

        int counter = 0;

        GameObject currentArrow;

        foreach (TimelineKeyFrame frame in keyframeList)
        {

            if (counter >= arrowList.Count)
            {
                currentArrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
                arrowList.Add(currentArrow);
            }
            else
            {
                // by working from the back then add is put on the correct place. though this shoulkd not mater... 
                currentArrow = (GameObject)arrowList[(arrowList.Count-1) - counter];
                currentArrow.SetActive(true);
            }

            
            currentArrow.GetComponent<RectTransform>().position = Vector3.Lerp(StartPoint.transform.position , EndPoint.transform.position, frame.GetT());

            currentArrow.transform.SetParent(transform.parent);

            currentArrow.GetComponent<KeyframeArrow>().SetT(frame.GetT() );

            counter++;
        }

    }


    void ResetArrows()
    {
        if (arrowList.Count > 1)
        {
            foreach (GameObject arrow in arrowList)
            {
                arrow.SetActive(false);
            }
        }
    }
}
