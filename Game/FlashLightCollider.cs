using UnityEngine;
using System.Collections;

public class FlashLightCollider : MonoBehaviour {

	public GameManager gameManager;
	public ParticleSystem redParticleSystem;
	public ParticleSystem blueParticleSystem;
	public ParticleSystem greenParticleSystem;
	public ParticleSystem yellowParticleSystem;

	public GameObject redDiamondPlusOne;
	public GameObject blueDiamondPlusOne;
	public GameObject greenDiamondPlusOne;
	public GameObject yellowDiamondPlusOne;

	void Awake(){
		blueParticleSystem.Stop ();
		redParticleSystem.Stop ();
		greenParticleSystem.Stop ();
		yellowParticleSystem.Stop ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == Tags.Colors.tag_Blue && name == Names.FlashLightColliders.str_BlueFlashLightColl) {
			if(!ChallengeGameManager.isMusicGame) gameManager.CurrentScore++;
			other.gameObject.SetActive(false);
			blueParticleSystem.Play();
		}else if (other.tag == Tags.Colors.tag_Red && name == Names.FlashLightColliders.str_RedFlashLightColl){
			if(!ChallengeGameManager.isMusicGame) gameManager.CurrentScore++;
			other.gameObject.SetActive(false);
			redParticleSystem.Play();
		}else if (other.tag == Tags.Colors.tag_Green && name == Names.FlashLightColliders.str_GreenFlashLightColl){
			if(!ChallengeGameManager.isMusicGame) gameManager.CurrentScore++;
			other.gameObject.SetActive(false);
			greenParticleSystem.Play();
		}else if (other.tag == Tags.Colors.tag_Yellow && name == Names.FlashLightColliders.str_YellowFlashLightColl){
			if(!ChallengeGameManager.isMusicGame) gameManager.CurrentScore++;
			other.gameObject.SetActive(false);
			yellowParticleSystem.Play();
		}

		if (other.tag == Tags.tag_Diamond && !ChallengeGameManager.isMusicGame){
			if (name == Names.FlashLightColliders.str_RedFlashLightColl){
					redDiamondPlusOne.SetActive(true);
					GameManager.recordings.collectedRedDiamonds++;
			}else if (name == Names.FlashLightColliders.str_BlueFlashLightColl){
					blueDiamondPlusOne.SetActive(true);
					GameManager.recordings.collectedBlueDiamonds++;
			}else if (name == Names.FlashLightColliders.str_GreenFlashLightColl){
					greenDiamondPlusOne.SetActive(true);
					GameManager.recordings.collectedGreenDiamonds++;
			}else if (name == Names.FlashLightColliders.str_YellowFlashLightColl){
					yellowDiamondPlusOne.SetActive(true);
					GameManager.recordings.collectedYellowDiamonds++;
			}
		}
	}

}
