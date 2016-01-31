using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

	public void Play(int i){
		Application.LoadLevel(i);
	}
}
