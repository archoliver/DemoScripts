using UnityEngine;
using System.Collections;

public class DiamondsInGame : MonoBehaviour {

	SoundFx soundFx;
	MusicPlayer musicPlayer;
	ChallengeGameManager challengeGameManager;
	Collider2D objectDetectorColl;
	Vector2 forceTravelToFlashLight;
	
	Animator DiamondAnim;

	bool isCollide;

	void Awake(){
		if (ChallengeGameManager.isMusicGame){
			challengeGameManager = GameObject.Find("ChallengeGameManager").GetComponent<ChallengeGameManager>();
			musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
		}else{
			soundFx = GameObject.Find("SoundFxPlayer").GetComponent<SoundFx>();
		}
		objectDetectorColl = GameObject.Find ("ObjectDetector").GetComponent<Collider2D>();
		DiamondAnim = GetComponent<Animator> ();
	}
	
	void Start(){
		if (tag == Tags.Colors.tag_Red) forceTravelToFlashLight = Constants.Forces.Diamonds.Red;
		else if (tag == Tags.Colors.tag_Blue)forceTravelToFlashLight = Constants.Forces.Diamonds.Blue;
		else if (tag == Tags.Colors.tag_Green)forceTravelToFlashLight = Constants.Forces.Diamonds.Green;
		else if (tag == Tags.Colors.tag_Yellow)forceTravelToFlashLight = Constants.Forces.Diamonds.Yellow;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == Tags.tag_LoseDetector && ChallengeGameManager.isMusicGame) {
			CancelInvoke ("Destroy");
			challengeGameManager.DisableFlashLightTouch();
			GetComponent<Rigidbody2D>().isKinematic = true;
			challengeGameManager.Result (false);
		}

		if (other == objectDetectorColl && !isCollide) {
			isCollide = true;
			if (FlashLightBeam.current.IsRedOn && tag==Tags.Colors.tag_Red){
				GoToFlashLight ();
			}else if (FlashLightBeam.current.IsBlueOn && tag==Tags.Colors.tag_Blue){
				GoToFlashLight ();
			}else if (FlashLightBeam.current.IsGreenOn && tag==Tags.Colors.tag_Green){
				GoToFlashLight ();
			}else if (FlashLightBeam.current.IsYellowOn && tag==Tags.Colors.tag_Yellow){
				GoToFlashLight ();
			}
		}
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
		DiamondAnim.SetTrigger("StarShrinkTrig");
		GetComponent<Rigidbody2D>().AddForce(forceTravelToFlashLight);
	}
	
	void OnEnable(){
		isCollide = false;
		transform.localScale = new Vector3 (1f,1f,1f);
		Invoke ("Destroy", Constants.starsLifeTime);
	}
	
	void OnDisable(){
		CancelInvoke ("Destroy");
	}
	
	void Destroy(){
		gameObject.SetActive (false);
	}

}
