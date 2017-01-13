using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChallengeGameManager : MonoBehaviour {

	public static bool isMusicGame;
	public MusicPlayer musicPlayer;

	public Text gameOverText;

	public GameObject greenFlashLight;
	public GameObject yellowFlashLight;
	//Result
	public GameObject resultPanel;
	public CanvasGroup flashLightButton;
	//fading
	public GameObject FadeAllImage;
	public Animator FadeAllImageAnim;

	bool isTimeScaleSetZero;

	void Start(){
		isMusicGame = true;
		musicPlayer.reset ();
	}

	public void Result(bool isWin){
		musicPlayer.StopCoroutine ("PlayMusic");
		flashLightButton.blocksRaycasts = false;
		gameOverText.text = isWin ? "VICTORY!" : "GAME OVER";
		if (isWin) {
			GameData.savings.diamonds += Challenges.ChallengeReward;
			GameData.savings.CurrentChallenge++;
			GameData.savings.Save();
		}
		Invoke ("DelaySetTimeScale", 0.2f);
	}

	void DelaySetTimeScale(){
		if (!isTimeScaleSetZero) {
			isTimeScaleSetZero = true;
			Time.timeScale = 0;
		}
		resultPanel.SetActive (true);
	}

	public void DisableFlashLightTouch(){
		flashLightButton.blocksRaycasts = false;
	}

	public void GoToOtherScene(string sceneName){
		Time.timeScale = 1;
		FadeAllImage.SetActive (true);
		FadeAllImageAnim.SetTrigger ("FadeTrig");
		StartCoroutine (GoToOtherSceneDelay(sceneName));
	}
	
	IEnumerator GoToOtherSceneDelay(string sceneName){
		yield return new WaitForSeconds(Constants.sceneFadingTime);
		Application.LoadLevel (sceneName);
	}


}
