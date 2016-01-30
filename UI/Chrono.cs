using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Chrono : MonoBehaviour {

	public Text chronoText;

	float time = 0f;

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		chronoText.text = time.ToString();
	}

	/// <summary>
	/// Arrondi un float avec <precision> chiffre après la virgule
	/// </summary>
	public static float RoundValue(float num, float precision)
	{
		return Mathf.Floor(num * precision + 0.5f) / precision;
	}

}
