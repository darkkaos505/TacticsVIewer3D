using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VectorInput : MonoBehaviour {


    public GameObject xInput;
    public GameObject yInput;
    public GameObject zInput;

    Text xInputText;
    Text yInputText;
    Text zInputText;

    Vector3 value;

	// Use this for initialization
	void Start () 
    {
        xInputText = xInput.GetComponentInChildren<Text>();
        yInputText = yInput.GetComponentInChildren<Text>();
        zInputText = zInput.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
        

	}

    public Vector3 GetValue()
    {
        string stringValue = xInputText.text; 
        value.x = float.Parse(stringValue);

        stringValue = yInputText.text;
        value.y = float.Parse(stringValue);

        stringValue = zInputText.text;
        value.z = float.Parse(stringValue);

        return value;
    }

    public void SetVector(Vector3 inValue)
    {
        xInputText.text = inValue.x.ToString();
        yInputText.text = inValue.y.ToString();
        zInputText.text = inValue.z.ToString();

        value = inValue;


    }
}
