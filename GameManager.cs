using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Boundary generalBoundaries;
    public static int defaultSizeCamera;
    public Boundary publicBoundaries;

    public static GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        generalBoundaries.xMin = publicBoundaries.xMin;
        generalBoundaries.xMax = publicBoundaries.xMax;
        generalBoundaries.yMin = publicBoundaries.yMin;
        generalBoundaries.yMax = publicBoundaries.yMax;
        defaultSizeCamera = 7;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
