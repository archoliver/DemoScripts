using UnityEngine;
using System.Collections;

public class SoundFx : MonoBehaviour {

	AudioSource speaker;

	void Awake(){
		speaker = GetComponent<AudioSource> ();
	}

	public void PlayTwinkleSound(){
		if (!GameData.savings.isMute) speaker.Play ();
	}

}
