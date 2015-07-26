using UnityEngine;
using System.Collections;

public class ObjectAxisMove : MonoBehaviour
{

 

   public  Ghost ObjectToMove;

    enum MoveStateEnum { stoped , moving };

    MoveStateEnum moveState = MoveStateEnum.stoped;


      float speed = 0.1f;
    public Vector3 direction = Vector3.forward;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (moveState == MoveStateEnum.moving)
        {
            float h = Input.GetAxis("Mouse X");
            float v =  Input.GetAxis("Mouse Y");


            Vector3 dir = transform.root.TransformDirection(direction); 

            Vector3 screenDir = -Camera.main.WorldToScreenPoint(dir);


            float horzComponet = h * Vector2.Dot(Vector2.right, screenDir);
            float vertComponet = v * Vector2.Dot(Vector2.up, screenDir);

            float scaler = horzComponet + vertComponet;

            ObjectToMove.MovePossistion( dir * scaler * speed * Time.deltaTime);

        }
    }


    public void StartMove()
    {
        moveState = MoveStateEnum.moving;
    }

    public void StopMove()
    {
        moveState = MoveStateEnum.stoped;
    }

}
