using UnityEngine;
using System.Collections;

public class ViewedObject : MonoBehaviour
{

    public GameObject timeLineObject;
 
 
    void Awake()
    {
 
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ZoomToObject()
    {

    }

    public void SetTimelineObject( GameObject objectTimeline)
    {
        timeLineObject = objectTimeline;
    }

    public void SelectObject()
    {
        if (timeLineObject != null)
        {

            KeyframeInfo.instance.SetSelectedObject(timeLineObject);
            Camera.main.transform.LookAt(timeLineObject.transform);
        }
        else
        {
            Debug.LogError("SelectedObject should never be null");
        }
    }
}
