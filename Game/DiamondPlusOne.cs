using UnityEngine;
using System.Collections;

public class DiamondPlusOne : MonoBehaviour {

	void OnEnable(){
		Invoke ("Destroy", Constants.diamondPlusOneLifeTime);
	}

	void OnDisable(){
		CancelInvoke ("Destroy");
	}

	void Destroy(){
		gameObject.SetActive (false);
	}
}
