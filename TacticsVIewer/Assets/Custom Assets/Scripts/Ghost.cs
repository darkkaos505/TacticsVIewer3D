using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

    TimelineKeyFrame timelineKeyFrame;
    TimeLineObject TimeLineObject;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Init(TimelineKeyFrame TimelineKeyFrameIN ,     TimeLineObject TimeLineObjectIN)
    {
        timelineKeyFrame = TimelineKeyFrameIN;
        TimeLineObject = TimeLineObjectIN;

        transform.position = timelineKeyFrame.GetPos();
        transform.rotation = Quaternion.LookRotation(transform.forward) * Quaternion.Euler(timelineKeyFrame.GetDir().x, timelineKeyFrame.GetDir().y, timelineKeyFrame.GetDir().z);
         
    }

    public void MovePossistion(Vector3 move)
    {
        timelineKeyFrame.Translate(move);
        transform.position = timelineKeyFrame.GetPos();

        TimeLineObject.ShowPath();
    }

 
}
