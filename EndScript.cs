using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("This is the end !");
            SceneManager.LoadScene("sceneFinale");
        }
    }
}
