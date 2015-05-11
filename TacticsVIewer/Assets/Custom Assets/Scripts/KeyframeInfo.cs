using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyframeInfo : MonoBehaviour 
{

     TimeLineObject timeLineObject;

    public GameObject posIntputObj;
    VectorInput posIntput;


    public GameObject dirIntputObj;
    VectorInput dirIntput;


    public GameObject titleGameobject ;
    Text titleText;

     Animator animator;

     public Camera mainCamera;

     public GameObject TimeLineSlider;
     KeyframeArrowManager keyframeArrowManager;

     //Here is a private reference only this class can access
     private static KeyframeInfo _instance;

     //This is the public reference that other classes will use
     public static KeyframeInfo instance
     {
         get
         {
             //If _instance hasn't been set yet, we grab it from the scene!
             //This will only happen the first time this reference is used.
             if (_instance == null)
                 _instance = GameObject.FindObjectOfType<KeyframeInfo>();
             return _instance;
         }
     }



	// Use this for initialization
	void Awake ()  
    {
        posIntput = posIntputObj.GetComponent<VectorInput>();
        dirIntput = dirIntputObj.GetComponent<VectorInput>();

        titleText = titleGameobject.GetComponent<Text>();

        animator = GetComponent<Animator>();

        keyframeArrowManager = TimeLineSlider.GetComponent<KeyframeArrowManager>();
    }

	
	// Update is called once per frame
	void Update () 
    {
        if ( timeLineObject != null)
        {
           
            UpdateVectors();
            titleText.text = "Key Frame at t = " + timeLineObject.GetCurrentKeyframe().GetT() + "  Current T = : " + Timeline.instance.GetT().ToString() ;
        }

        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if ( Input.GetMouseButtonDown(0) && (Physics.Raycast(ray , out hit))) 
        {
            if(hit.collider.CompareTag("TimeLineObject"))
            {
                SetSelectedObject(hit.collider.gameObject);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetSelectedObject(null);

        }
            
	}

    void UpdateVectors()
    {
        posIntput.SetVector(timeLineObject.GetCurrentKeyframe().GetPos() ) ;

        dirIntput.SetVector(timeLineObject.GetCurrentKeyframe().GetDir() );

    }

    void ShowGhosts()
    {
        if (   timeLineObject != null)
        {
            timeLineObject.ShowGhosts();
        }
    }


    void HideGhosts()
    {
        if (  timeLineObject != null)
        {
            timeLineObject.HideGhosts();
        }
    }

    void ShowPath()
    {
        if (  timeLineObject != null)
        {
            timeLineObject.ShowPath();
        }
    }


    void HidePath()
    {
        if ( timeLineObject != null)
        {
            timeLineObject.HidePath();
        }
     }


    public void SetSelectedObject( GameObject SelectedObject)
    {
        keyframeArrowManager.SetSelectedObject(SelectedObject);


        if(SelectedObject  != null)
        {
            timeLineObject = SelectedObject.GetComponent<TimeLineObject>();
            animator.ResetTrigger("Hide");
            animator.SetTrigger("Show");            
        }
        else
        {
            animator.ResetTrigger("Show");
            animator.SetTrigger("Hide");
        }
    }     
    
}


