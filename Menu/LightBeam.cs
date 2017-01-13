using UnityEngine;
using System.Collections;

public class LightBeam : MonoBehaviour {

	void OnEnable(){
		Invoke ("Disable", 0.5f);
	}

	void Disable(){
		this.gameObject.SetActive (false);
	}
}
