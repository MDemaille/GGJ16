using UnityEngine;
using System.Collections;

public class DmgUpgrade : MonoBehaviour {

    public int level = 1;

    void OnTriggerEnter2D(Collider2D other) {
        PlayerScript ps = other.GetComponent<PlayerScript>();
        if(ps != null) {
            if (ps.DmgUp < level) {
                ps.DmgUp = level;

                PlayerAttack pa = other.GetComponent<PlayerAttack>();
                switch (level)
                {
                    case 1:
                        pa.damageUp = 5;
                        break;
                    case 2:
                        pa.damageUp = 10;
                        break;
                    case 3:
                        pa.damageUp = 15;
                        break;
                }
            }
            Destroy(gameObject);
        }
    }
}
