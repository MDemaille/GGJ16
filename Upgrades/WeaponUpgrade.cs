using UnityEngine;
using System.Collections;

public class WeaponUpgrade : MonoBehaviour {

    public PlayerAttack.Weapon weapon;
    public GameObject UI;

    public GameObject basicEggItem;
    public GameObject goldEggItem;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            UI.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (other.gameObject.GetComponent<PlayerAttack>().weapon == PlayerAttack.Weapon.BASICEGG)
                    Instantiate(basicEggItem, transform.position, Quaternion.identity);

                if (other.gameObject.GetComponent<PlayerAttack>().weapon == PlayerAttack.Weapon.GOLDENEGG)
                    Instantiate(goldEggItem, transform.position, Quaternion.identity);


                other.gameObject.GetComponent<PlayerAttack>().weapon = weapon;
                Destroy(gameObject);

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            UI.SetActive(false);
        }
    }

}
