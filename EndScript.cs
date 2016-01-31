using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public static int  NbBossKilled = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(NbBossKilled + " boss killed");
        if (other.tag.Equals("Player") && NbBossKilled >= 5)
        {
            Debug.Log( "This is the end !");
            SceneManager.LoadScene("sceneFinale");
        }
    }
}
