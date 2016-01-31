using UnityEngine;
using System.Collections;

public class KingPouleSansTeteController : MonoBehaviour {

    public FireCircle patternCircle;
    public FireCone patternCone;

    public float timeWait;
    public float timeCircle;
    public float timeCone;
   

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(patterns());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator patterns()
    {

        while (true)
        {
            int chose = Random.Range(0, 2);
            if (chose == 0)
            {
                Debug.Log("Circle!");
                patternCircle.enabled = true;
                yield return new WaitForSeconds(Random.Range(2, 6));
                patternCircle.enabled = false;
                yield return new WaitForSeconds(1.0f);
            }
            else if (chose == 1)
            {
                Debug.Log("Cone!");
                patternCone.enabled = true;
                yield return new WaitForSeconds(Random.Range(2,6));
                patternCone.enabled = false;
                yield return new WaitForSeconds(1.0f);
            }
        
        }

    }
}
