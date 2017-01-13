using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public AudioSource soundFx;

	public Camera cam;
	float shake = 0.25f;
	float shakeAmount = 8.7f;
	float decreaseFactor = 1.0f;

	public void ShakeInvoke(){
		GameData.savings.Load ();
		if (!GameData.savings.isMute) soundFx.Play ();
		InvokeRepeating ("Shake", 0.01f, 0.05f);
	}

	void Shake(){
		if (shake > 0f) {
			cam.transform.localPosition = Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
			
		} else {
			shake = 0.0f;
		}
	}
}
