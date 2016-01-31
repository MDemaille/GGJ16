using UnityEngine;
using System.Collections;

public class LightAutel : MonoBehaviour {

    public Sprite lightAutelSprite;

    public void lightAutel()
    {
        GetComponent<SpriteRenderer>().sprite = lightAutelSprite;
    }
}
