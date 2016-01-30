using UnityEngine;
using System.Collections;

public class SpeUpgrade : MonoBehaviour {

    public int level = 1;

    void OnTriggerEnter2D(Collider2D other) {
        PlayerScript ps = other.GetComponent<PlayerScript>();
        if (ps != null) {
            if (ps.SpeUp < level) {
                ps.SpeUp = level;
                Free2DMovement f2dm = other.GetComponent<Free2DMovement>();
                switch (level) {
                    case 1:
                        f2dm.speed = 170;
                        break;
                    case 2:
                        f2dm.speed = 190;
                        break;
                    case 3:
                        f2dm.speed = 210;
                        break;
                }

            }
            Destroy(gameObject);
        }
    }
}
