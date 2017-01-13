using UnityEngine;
using System.Collections;

public class FlashLightBeam : MonoBehaviour {

	public static FlashLightBeam current;

	public GameObject redLightBeam;
	public GameObject blueLightBeam;
	public GameObject yellowLightBeam;
	public GameObject greenLightBeam;

	public bool IsRedOn{
		get{
			return redLightBeam.activeSelf;
		}
	}

	public bool IsBlueOn{
		get{
			return blueLightBeam.activeSelf;
		}
	}

	public bool IsYellowOn{
		get{
			return yellowLightBeam.activeSelf;
		}
	}

	public bool IsGreenOn{
		get{
			return greenLightBeam.activeSelf;
		}
	}

	void Awake(){
		current = this;
	}

	public void RedLightOn(){
		redLightBeam.SetActive (true);
		if(!ChallengeGameManager.isMusicGame) GameManager.recordings.flashedRedLight++;
	}

	public void BlueLightOn(){
		blueLightBeam.SetActive (true);
		if(!ChallengeGameManager.isMusicGame) GameManager.recordings.flashedBlueLight++;
	}

	public void YellowLightOn(){
		yellowLightBeam.SetActive (true);
		if(!ChallengeGameManager.isMusicGame) GameManager.recordings.flashedYellowLight++;
	}

	public void GreenLightOn(){
		greenLightBeam.SetActive (true);
		if(!ChallengeGameManager.isMusicGame) GameManager.recordings.flashedGreenLight++;
	}

	public void RedLightOff(){
		redLightBeam.SetActive (false);
	}
	
	public void BlueLightOff(){
		blueLightBeam.SetActive (false);
	}
	
	public void YellowLightOff(){
		yellowLightBeam.SetActive (false);
	}
	
	public void GreenLightOff(){
		greenLightBeam.SetActive (false);
	}

}
