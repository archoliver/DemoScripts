using UnityEngine;
using System.Collections;

public class HolaSplashScreen : MonoBehaviour {

	void Awake(){
		Application.targetFrameRate = Constants.FrameRate;
	}

	public void GoToGameLogoScene(){
		Application.LoadLevel("SplashScreen");
	}

}
