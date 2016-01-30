using UnityEngine;
using System.Collections;

/// <summary>
/// Script attaché aux agents dont on ne veut pas modifier la rotation en fonction des déplacements
/// </summary>
public class ResetRotation : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
	}
}
