using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject pausePanel;

	bool onPause = false;

	void Start(){
		pausePanel.transform.localScale = Vector3.zero;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			SwitchPause ();
		}
	}

	public void SwitchPause(){
		onPause = !onPause;

		if (onPause) {
			Time.timeScale = 0f;
			iTween.ScaleTo (pausePanel, iTween.Hash ("scale", Vector3.one, "time", 1f, "easetype", iTween.EaseType.easeOutBack, "ignoretimescale", true));
		} else {
			Time.timeScale = 1f;
			iTween.ScaleTo (pausePanel, iTween.Hash ("scale", Vector3.zero, "time", 1f, "easetype", iTween.EaseType.easeInBack, "ignoretimescale", true));
		}
	}

	public void Quit(){
		if (Application.isEditor) {
			Debug.Break ();
		} else {
			Application.Quit ();
		}
	}
}
