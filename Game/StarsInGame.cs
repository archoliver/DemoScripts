using UnityEngine;
using System.Collections;

public class StarsInGame : MonoBehaviour {

	GameManager gameManager;
	SoundFx soundFx;
	ChallengeGameManager challengeGameManager;
	MusicPlayer musicPlayer;
	Collider2D objectDetectorColl;
	Vector2 forceTravelToFlashLight;

	Animator StarAnim;

	void Awake(){
		if (!ChallengeGameManager.isMusicGame){
			gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
			soundFx = GameObject.Find("SoundFxPlayer").GetComponent<SoundFx>();
		}
		else{
			challengeGameManager = GameObject.Find("ChallengeGameManager").GetComponent<ChallengeGameManager>();
			musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
		}
		objectDetectorColl = GameObject.Find ("ObjectDetector").GetComponent<Collider2D>();
		StarAnim = GetComponent<Animator> ();
	}

	void Start(){
		if (tag == Tags.Colors.tag_Red) forceTravelToFlashLight = Constants.Forces.Stars.Red;
		else if (tag == Tags.Colors.tag_Blue)forceTravelToFlashLight =  Constants.Forces.Stars.Blue;
		else if (tag == Tags.Colors.tag_Green)forceTravelToFlashLight =  Constants.Forces.Stars.Green;
		else if (tag == Tags.Colors.tag_Yellow)forceTravelToFlashLight =  Constants.Forces.Stars.Yellow;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == Tags.tag_LoseDetector) {
			CancelInvoke ("Destroy");
			if (!ChallengeGameManager.isMusicGame)
				gameManager.DisableFlashLightTouch();
			else
				challengeGameManager.DisableFlashLightTouch();
			GetComponent<Rigidbody2D>().isKinematic = true;
			StarAnim.SetTrigger("LoseTrig");
		}

		if (other == objectDetectorColl) {
			if (FlashLightBeam.current.IsRedOn && tag==Tags.Colors.tag_Red){
				GoToFlashLight ();
				if(!ChallengeGameManager.isMusicGame) GameManager.recordings.collectedRedStars++;
			}else if (FlashLightBeam.current.IsBlueOn && tag==Tags.Colors.tag_Blue){
				GoToFlashLight ();
				if(!ChallengeGameManager.isMusicGame) GameManager.recordings.collectedBlueStars++;
			}else if (FlashLightBeam.current.IsGreenOn && tag==Tags.Colors.tag_Green){
				GoToFlashLight ();
				if(!ChallengeGameManager.isMusicGame) GameManager.recordings.collectedGreenStars++;
			}else if (FlashLightBeam.current.IsYellowOn && tag==Tags.Colors.tag_Yellow){
				GoToFlashLight ();
				if(!ChallengeGameManager.isMusicGame) GameManager.recordings.collectedYellowStars++;
			}
		}
	}

	public void LoseAfterAnim(){
		if (!ChallengeGameManager.isMusicGame) {
			gameManager.Result();
			Time.timeScale = 0f;
		}
		else challengeGameManager.Result(false);

	}

	void GoToFlashLight(){
		if (ChallengeGameManager.isMusicGame){
			musicPlayer.PlayOne ();
			if (musicPlayer.currentToneIndex >= musicPlayer.musics[musicPlayer.currentMusicIndex].Length){
				challengeGameManager.Result (true);
			}
		}else{
			soundFx.PlayTwinkleSound();
		}
		StarAnim.SetTrigger("StarShrinkTrig");
		GetComponent<Rigidbody2D>().AddForce(forceTravelToFlashLight);
	}

	void OnEnable(){
		GetComponent<Rigidbody2D>().AddTorque (Levels.RandomRotationForce);
		transform.localScale = new Vector3 (1f,1f,1f);
		Invoke ("Destroy", Constants.starsLifeTime);
	}
	
	void OnDisable(){
		CancelInvoke ("Destroy");
	}

	void Destroy(){
		this.gameObject.SetActive (false);
	}
}
