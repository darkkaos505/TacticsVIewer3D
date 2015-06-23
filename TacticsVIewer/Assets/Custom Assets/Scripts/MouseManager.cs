using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	// Use this for initialization


    ObjectAxisMove objectAxisMove;

    void Start ()
    {
	
	}
	
	// Update is called once per frame
    void Update()
    {

        HandelClicks();


    }

    void HandelClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray , out hitInfo)) 
            {                
                if( hitInfo.collider.CompareTag("MoveArrow") )
                {
                    objectAxisMove = hitInfo.collider.gameObject.GetComponent<ObjectAxisMove>();
                    objectAxisMove.StartMove();
                }
            }
        }


        if(Input.GetMouseButtonUp(0) )
        {

            if(objectAxisMove != null)
            {
                objectAxisMove.StopMove();
                objectAxisMove = null;     
            }
        }


    }
}
