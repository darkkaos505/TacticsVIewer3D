using UnityEngine;
using System.Collections;

public class TimeLineObject : MonoBehaviour
{

    ArrayList keyframeList;
     
    TimelineKeyFrame prevKeyframe;
    TimelineKeyFrame nextKeyframe;

    public GameObject ghostPrefab;

    ArrayList ghostList;

    LineRenderer movementPath;

    // Use this for initialization
    void Start()
    {
        keyframeList = new ArrayList();
        ghostList = new ArrayList();

        int num = Random.Range(2, 5);

        for (int i = 0; i <= num; i ++)
        {
            float  t = i/(float)num;

            TimelineKeyFrame frame = new TimelineKeyFrame(t,
                new Vector3(Random.value * 100, Random.value * 100, Random.value * 100), 
                new Vector3(Random.value * 360, Random.value * 360, Random.value * 360)  );

            keyframeList.Add(frame);
        }


       // TimelineKeyFrame end = new TimelineKeyFrame(1,      new Vector3(0, 10, 20)     , Vector3.forward);
        ///TimelineKeyFrame mid = new TimelineKeyFrame(0.5f,   new Vector3(1, 15, 15)  , Vector3.forward);

         keyframeList.Sort();

        movementPath = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePrevNext();
        if (prevKeyframe != null && nextKeyframe != null)
        {
            float tLocalNotNormlised = Timeline.instance.GetT() - prevKeyframe.GetT();
            float tLocalMax = nextKeyframe.GetT() - prevKeyframe.GetT(); 
            tLocalMax = Mathf.Clamp01(tLocalMax);
            float tLocal = 1; 
            if(tLocalMax != 0)
            {
                tLocal = tLocalNotNormlised / tLocalMax;
            }        
            
            transform.position = Vector3.Lerp(prevKeyframe.GetPos(), nextKeyframe.GetPos(), tLocal);

            Vector3 angles =  Vector3.Lerp(prevKeyframe.GetDir(), nextKeyframe.GetDir(), tLocal);

            transform.rotation =   Quaternion.Euler(angles);


         }

    }


    void UpdatePrevNext()
    {
         float TimelineT = Timeline.instance.GetT();

        IEnumerator enumerator = keyframeList.GetEnumerator();

        TimelineKeyFrame lastKeyframe = null;


        while (enumerator.MoveNext())
        {
            TimelineKeyFrame aKeyframe = (TimelineKeyFrame) enumerator.Current;

            if ( aKeyframe.GetT() >= TimelineT)
            {
                // inital set both to the same incase this is the first;
                prevKeyframe = aKeyframe;
                nextKeyframe = aKeyframe;

                
                if (lastKeyframe != null) 
                {
                    prevKeyframe = lastKeyframe;
                }
                
                //leave the loop now we have both keyframes
                break;

            }
                           
              lastKeyframe = (TimelineKeyFrame)enumerator.Current;

        }

    }

    public ArrayList GetKeyframeList()
    {
        return keyframeList;
    }
    
    public  TimelineKeyFrame GetCurrentKeyframe()
    {
        // HACK
        // this is due to when t = 0 pre and next wont change need to think of beter way of doing it
        if (Timeline.instance.GetT() == 0)
        {
            return prevKeyframe;
        }


        return nextKeyframe;
    }

  public void ShowGhosts()
    {
        HideGhosts();

        int counter = 0;

        GameObject currentGhost;

        foreach (TimelineKeyFrame frame in keyframeList)
        {

            if (counter >= ghostList.Count)
            {
                currentGhost = Instantiate(ghostPrefab, transform.position, transform.rotation) as GameObject;
                ghostList.Add(currentGhost);
            }
            else
            {
                // by working from the back then add is put on the correct place. though this shoulkd not mater... 
                currentGhost = (GameObject)ghostList[(ghostList.Count - 1 ) - counter];
                currentGhost.SetActive(true);
            }


            currentGhost.transform.position = frame.GetPos();
            currentGhost.transform.rotation = Quaternion.LookRotation(transform.forward) * Quaternion.Euler(frame.GetDir().x, frame.GetDir().y, frame.GetDir().z);
         
            counter++;
        }

    }


 public void HideGhosts()
  {
      foreach (GameObject arrow in ghostList)
      {
          arrow.SetActive(false);
      }
  }

 public void ShowPath()
 {
     movementPath.enabled = true;

     movementPath.SetVertexCount(keyframeList.Count  );

     int counter = 0;
     foreach (TimelineKeyFrame frame in keyframeList)
     {
         movementPath.SetPosition(counter , frame.GetPos());
         counter++;
     }
 
 }


 public void HidePath()
 {
     movementPath.enabled = false;
 }


}
