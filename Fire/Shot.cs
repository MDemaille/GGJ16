using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public string tagTarget = "Enemy";

    public int damage;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals(tagTarget))
        {
            other.gameObject.GetComponent<AgentLife>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
