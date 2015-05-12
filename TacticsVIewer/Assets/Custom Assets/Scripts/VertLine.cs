using UnityEngine;
using System.Collections;


/// <summary>
///  This class is used for controling the vertical refcene lines which connect to the y = 0 plane 
/// </summary>

public class VertLine : MonoBehaviour 
{
    LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

	// Use this for initialization
	void Start ()
    {
        lineRenderer.useWorldSpace = true;
  
	}
	
	// Update is called once per frame
	void Update () 
    {
        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, new Vector3(transform.position.x, 0, transform.position.z));

	}
}
