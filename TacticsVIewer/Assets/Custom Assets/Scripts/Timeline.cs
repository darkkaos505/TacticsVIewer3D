using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{

    public GameObject TimeSliderObj;

    Slider timeSlider;

     //Here is a private reference only this class can access
    private static Timeline _instance;
 
    //This is the public reference that other classes will use
    public static Timeline instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Timeline>();
            }

            return _instance;
        }
    }
    
    void Awake()
    {
         timeSlider = TimeSliderObj.GetComponent<Slider>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetT()
    {
        if (timeSlider != null )
        {
            return timeSlider.value;
        }
        else
        {
            timeSlider = TimeSliderObj.GetComponent<Slider>();

            return timeSlider.value;

        }
    }


    public void SetT(float newValue)
    {

        if (timeSlider != null)
        {
            timeSlider.value = newValue;
        }
        else
        {
            timeSlider = TimeSliderObj.GetComponent<Slider>();
              timeSlider.value = newValue;
        }
    }
}
