using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

/// <summary>
/// La classe CameraControl contient les fonctions de controles de caméra
/// </summary>
public class CameraControl : MonoBehaviour {

	


	/// <summary>
	/// Effectue un déplacement de caméra
	/// </summary>
	/// <param name="position">La position vers laquelle se déplace la caméra</param>
	/// <param name="size">La valeur de zoom de la caméra</param>
	/// <param name="duration">La durée du déplacement</param>
	/// <param name="enableControl">Si mis à <c>true</c> , active le controle du joueur à la fin du déplacement</param>
	public static IEnumerator BlendCameraTo(Vector3 position, float size, float duration, bool enableControl)
	{
        Camera.main.GetComponent<CameraFollow>().enabled = false;

		float progression = 0;
		float initialSize = Camera.main.orthographicSize;
		Vector3 initialPosition = Camera.main.transform.position;
		while (progression <= 1.0f) 
		{
			yield return new WaitForSeconds(Time.deltaTime);
			progression += (Time.deltaTime / duration);
			Camera.main.transform.position = Vector3.Lerp(initialPosition,position,progression);
			Camera.main.orthographicSize = initialSize + (size - initialSize)*progression;
		}

        Camera.main.GetComponent<CameraFollow>().enabled = enableControl;

	}

		
}
