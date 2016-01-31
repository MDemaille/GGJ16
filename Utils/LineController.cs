using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {

	public float time;

	public Transform start;
	public Transform end;

	LineRenderer lineRenderer;

	void Start(){
		lineRenderer = GetComponent<LineRenderer> ();

		lineRenderer.SetPosition (0, start.position);
		lineRenderer.SetPosition (1, end.position);

		StartCoroutine (AnimLine ());
	}

	IEnumerator AnimLine(){
		lineRenderer.SetPosition (1, start.position);

		Vector3 v;
		float elapsedTime = 0f;
		while (elapsedTime < time) {
			v = Vector3.Lerp(start.position, end.position, elapsedTime / time);
			lineRenderer.SetPosition (1, v);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		lineRenderer.SetPosition (1, end.position);
	}
}
