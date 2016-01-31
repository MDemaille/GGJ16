using UnityEngine;
using System.Collections;

public class FireBomb : MonoBehaviour {

    public int life = 3;
    public GameObject explosion;
    public GameObject boss;

    public float radius;

    Mover mover;

    void Start()
    {
        mover = GetComponent<Mover>();
        boss = GameObject.Find("KingKamikaze");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Environnement") || other.tag.Equals("Player"))
        {
            explode();
        }
        else if(other.tag.Equals("Boss") && life <= 0)
        {
            explode();
        }

        if (other.tag.Equals("Shot"))
        {
            life--;
            if (life == 0)
            {
                mover.direction = other.gameObject.GetComponent<Mover>().direction;
                GetComponent<Rigidbody2D>().velocity = mover.direction.normalized*mover.speed*2;

                float angle = Mathf.Atan2(mover.direction.y, mover.direction.x) * Mathf.Rad2Deg - 90;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.localRotation = q;

            }
        }


    }

    void explode()
    {

        if (GameManager.player == null || boss == null)
            return;

        //Instantiate(explosion, transform.position, Quaternion.identity);
        if (Vector2.Distance(transform.position, boss.transform.position) < radius)
        {
            boss.GetComponent<AgentLife>().TakeDamage(100, Color.red);
        }

        if (Vector2.Distance(transform.position, GameManager.player.transform.position) < radius)
        {
            GameManager.player.GetComponent<AgentLife>().TakeDamage(10, Color.red);
        }

        Destroy(gameObject);

    }

}
