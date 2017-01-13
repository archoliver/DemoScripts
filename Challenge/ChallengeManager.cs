using UnityEngine;
using System.Collections;

public class ChallengeManager : MonoBehaviour {

	public GameObject FadeAllImage;
	public Animator FadeAllImageAnim;

	public static int musicIndex;

	void Update(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				GoToOtherScene("Menu");
				return;
			}
		}
		#elif UNITY_IOS
		#endif
	}

	public void GoToOtherScene(string sceneName){
		FadeAllImage.SetActive (true);
		FadeAllImageAnim.SetTrigger ("FadeTrig");
		StartCoroutine (GoToOtherSceneDelay(sceneName));
	}
	
	IEnumerator GoToOtherSceneDelay(string sceneName){
		yield return new WaitForSeconds(Constants.sceneFadingTime);
		Application.LoadLevel (sceneName);
	}

	public void ChangeMusicIndex(int _musicIndex){
		musicIndex = _musicIndex;
	}

}