using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public string tagTarget = "Enemy";

    public int damage;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Environnement"))
        {
            Destroy(gameObject);
        }

        if (tagTarget.Equals("Enemy"))
        {
            if (other.tag.Equals(tagTarget) || other.tag.Equals("Boss"))
            {
                other.gameObject.GetComponent<AgentLife>().TakeDamage(damage, Color.red);
                Destroy(gameObject);
            }
        }

        if (other.tag.Equals(tagTarget))
        {
            other.gameObject.GetComponent<AgentLife>().TakeDamage(damage, Color.red);
            Destroy(gameObject);
        }
    }
}
