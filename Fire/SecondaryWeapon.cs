using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SecondaryWeapon : MonoBehaviour {

	public float timeToLoad = 30f;

	public static float time = 0f;
	public static Image jauge;
	public static bool secondaryWeaponReady = false;

	void Start(){
		jauge = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		secondaryWeaponReady = !(time < timeToLoad);

		if (!secondaryWeaponReady) {
			jauge.fillAmount = time / timeToLoad;
		} else {
			jauge.fillAmount = 1f;
		}

	}

	public static void Reset(){
		time = 0f;
		jauge.fillAmount = 0f;
		secondaryWeaponReady = false;
	}
}
