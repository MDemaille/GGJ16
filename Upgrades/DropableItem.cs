using UnityEngine;
using System.Collections;

public abstract class DropableItem : MonoBehaviour {

    public int dropRate = 0;
    public abstract void OnTriggerEnter2D(Collider2D other);

}
