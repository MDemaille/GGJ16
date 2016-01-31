using UnityEngine;
using System.Collections;


public class Clamp : MonoBehaviour {

    public Boundary boundaries;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(gameObject.name);
       transform.position = new Vector3
             (
                Mathf.Clamp(transform.position.x, boundaries.xMin, boundaries.xMax),
                Mathf.Clamp(transform.position.y, boundaries.yMin, boundaries.yMax),
                transform.position.z
            );
        
    }
}
