using UnityEngine;
using System.Collections;

public class BossFocus : MonoBehaviour {

    public GameObject autel;

    public Vector3 cameraPosition;
    public float sizeCamera;

    public Boundary boundaries;

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(CameraControl.BlendCameraTo(cameraPosition, sizeCamera, 0.5f, false));
            other.gameObject.GetComponent<Clamp>().boundaries = boundaries;
            GetComponent<BoxCollider2D>().enabled = false;
        }

        
    }

    public void Unfocus()
    {
        StartCoroutine(CameraControl.BlendCameraTo(cameraPosition, GameManager.defaultSizeCamera, 0.5f, true));
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<Clamp>().boundaries = Camera.main.gameObject.GetComponent<GameManager>().publicBoundaries;
        }

        autel.GetComponent<LightAutel>().lightAutel();
    }

}
