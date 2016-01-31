using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayGame : MonoBehaviour {

	public void PlayScene(int i){
		SceneManager.LoadScene(i);
	}
}
