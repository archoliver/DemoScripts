using UnityEngine;
using System.Collections;

public class StarSpawn : MonoBehaviour {

	public float spawnTime;

	void Start(){
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn(){
		GameObject obj = NewStarPooler.current.GetPooledObject ();
		if (obj == null) return;
		obj.transform.position = transform.position;
		//obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
	}
}
