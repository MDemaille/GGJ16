using UnityEngine;
using System.Collections;

public class RateUpgrade : DropableItem {

    public int level = 1;

    override
    public void OnTriggerEnter2D(Collider2D other) {
        PlayerScript ps = other.GetComponent<PlayerScript>();

   

        if (ps != null) {
   
            if (ps.RateUp < level) {
                ps.RateUp = level;
                PlayerAttack pa = other.GetComponent<PlayerAttack>();

                switch(level) {
                    case 1:
                        pa.fireRate = 0.25f;
                        break;
                    case 2:
                        pa.fireRate = 0.2f;
                        break;
                    case 3:
                        pa.fireRate = 0.15f;
                        break;
                }

            }
            Destroy(gameObject);
        }
    }
}
