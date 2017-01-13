using UnityEngine;
using System.Collections;

public class ObjectDetector : MonoBehaviour {

	public GameObject blueLightBeam;
	public GameObject redLightBeam;

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Star_Blue(Clone)" && !MenuManager.isScreenFading){
			blueLightBeam.SetActive(true);
		}
		else if (other.name == "Star_Red(Clone)" && !MenuManager.isScreenFading){
			redLightBeam.SetActive(true);
		}
	}
}
