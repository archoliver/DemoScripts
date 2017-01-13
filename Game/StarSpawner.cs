using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour {

	void Start () {
		//InvokeRepeating ("Spawn", 1f, Levels.spawningSpeed[GameManager.currentLevel]);
		StartCoroutine (SpawnStarsCoroutine());
	}

	IEnumerator SpawnStarsCoroutine (){
		while (true) {
			yield return new WaitForSeconds(Levels.SpawningSpeed);
			Spawn();
		}
	}
	
	void Spawn(){
		GameObject obj = NewStarPoolerInGame.current.GetPooledObject ();
		if (obj == null) return;
		obj.transform.position = transform.position;
		//obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
	}
}
