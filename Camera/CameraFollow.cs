﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform mainTarget;
    public float smoothing = 1.5f;


    void FixedUpdate()
    {

        if (mainTarget == null)
        {
            enabled = false;
            return;
        }

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouse = new Vector3((mouse.x - mainTarget.position.x) * 0.2f, (mouse.y - mainTarget.position.y) * 0.2f, mouse.z);

        Vector3 targetCamPos = mainTarget.position + mouse;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

    }
}
