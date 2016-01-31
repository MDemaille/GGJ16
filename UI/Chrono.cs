using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Chrono : MonoBehaviour {

	public Text chronoText;

	float time = 0f;

	int hours;
	int minutes;
	int seconds;

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > 60f) {
			minutes = (int)time / 60;
			seconds = (int)time - (minutes * 60);
		} else {
			seconds = (int)time;
			minutes = 0;
			hours = 0;
		}
		if (minutes > 60) {
			hours = minutes / 60;
			minutes -= 60;
		}

		string hoursStr = (hours < 10) ? "0" + hours.ToString() : hours.ToString();
		string minutesStr = (minutes < 10) ? "0" + minutes.ToString() : minutes.ToString();
		string secondsStr = (seconds < 10) ? "0" + seconds.ToString() : seconds.ToString();

		chronoText.text = hoursStr + ":" + minutesStr + ":" + secondsStr;
	}

	/// <summary>
	/// Arrondi un float avec <precision> chiffre après la virgule
	/// </summary>
	public static float RoundValue(float num, float precision)
	{
		return Mathf.Floor(num * precision + 0.5f) / precision;
	}

}
