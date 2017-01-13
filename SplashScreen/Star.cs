using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	public Animator BlackGroundAnim;
	public SplashScreen ss;

	public void Shake(){
		ss.ShakeInvoke ();
	}

	public void GoToMenuScene(){
		Application.LoadLevel("Menu");
	}

	public void BlackGoundTrigger(){
		BlackGroundAnim.SetTrigger ("BlackGroundTrig");
	}

}
