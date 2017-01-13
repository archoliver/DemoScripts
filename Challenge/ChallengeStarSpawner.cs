using UnityEngine;
using System.Collections;

public class ChallengeStarSpawner : MonoBehaviour {

	public MusicPlayer musicPlayer;

	void Start () {
		Invoke ("StartSpawning", 1f);
	}
	
	void StartSpawning(){
		musicPlayer.StartCoroutine ("PlayMusic");
	}
	
	public void Spawn(){
		GameObject obj = NewStarPoolerInGame.current.GetPooledObject ();
		if (obj == null) return;
		obj.transform.position = transform.position;
		//obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
	}

}
