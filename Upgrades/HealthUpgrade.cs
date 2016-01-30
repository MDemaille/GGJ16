﻿using UnityEngine;
using System.Collections;

public class HealthUpgrade : MonoBehaviour {

    public int level = 1;

    void OnTriggerEnter2D(Collider2D other) {
        PlayerScript ps = other.GetComponent<PlayerScript>();
        if (ps != null) {
            if (ps.LifeUp < level) {
                ps.LifeUp = level;

                AgentLife al = other.GetComponent<AgentLife>();
                al.currentLife += 20;
                switch (level) {
                    case 1:
                        al.startingLife = 120;
                        break;
                    case 2:
                        al.startingLife = 140;
                        break;
                    case 3:
                        al.startingLife = 160;
                        break;
                }

            }
            Destroy(gameObject);
        }
    }
}
