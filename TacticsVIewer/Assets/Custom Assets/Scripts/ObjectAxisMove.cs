using UnityEngine;
using System.Collections;

public class ObjectAxisMove : MonoBehaviour
{

    public Transform ObjectToMove;


    enum MoveStateEnum { stoped , moving };

    MoveStateEnum moveState = MoveStateEnum.stoped;

    float horizontalSpeed = 1;
    float verticalSpeed = 1;


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
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            ObjectToMove.Translate(direction * h);
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
