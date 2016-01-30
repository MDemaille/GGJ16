﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform mainTarget;
	public float smoothing = 1.5f;

	Vector3 offset;

	void Start() {
		offset = transform.position - mainTarget.position;
	}

	void FixedUpdate() {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouse = new Vector3(mouse.x * 0.2f, mouse.y * 0.2f, mouse.z);

        Vector3 targetCamPos = mainTarget.position + mouse;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}