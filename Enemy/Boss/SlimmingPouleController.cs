using UnityEngine;
using System.Collections;

public class SlimmingPouleController : MonoBehaviour {

    public int numberOfDivision = 5;
    public int currentDivision = 0;

    public void divide()
    {
        Vector3 decal = new Vector3(GetComponent<CircleCollider2D>().radius, 0, 0);
        GameObject baby1 = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
        GameObject baby2 = Instantiate(gameObject, transform.position + decal , Quaternion.identity) as GameObject;


        baby1.transform.localScale = gameObject.transform.localScale / 2;
        baby2.transform.localScale = gameObject.transform.localScale / 2;



        baby1.GetComponent<AgentLife>().startingLife = GetComponent<AgentLife>().startingLife / 2;
        baby2.GetComponent<AgentLife>().startingLife = GetComponent<AgentLife>().startingLife / 2;

        baby1.GetComponent<SlimmingPouleController>().currentDivision = GetComponent<SlimmingPouleController>().currentDivision + 1;
        baby2.GetComponent<SlimmingPouleController>().currentDivision = GetComponent<SlimmingPouleController>().currentDivision + 1;

        baby1.transform.parent = gameObject.transform.parent;
        baby2.transform.parent = gameObject.transform.parent;

        gameObject.transform.parent.GetComponent<SlimBossCount>().nbBoss += 2;

    }
}
