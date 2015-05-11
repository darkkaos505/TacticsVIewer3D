using UnityEngine;
using System.Collections;

public class KeyframeArrow : MonoBehaviour 
{
     float t = 0;


     public void ClickedArrow()
    {
        Timeline.instance.SetT(t);

    }

    public void SetT(float newValue)
    {
        t = newValue;
    }

}
