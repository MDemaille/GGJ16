using UnityEngine;
using System.Collections;

public class WeaponUpgrade : MonoBehaviour {

    public PlayerAttack.Weapon weapon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerAttack>().weapon = weapon;
            Destroy(gameObject);
        }
    }
    
}
