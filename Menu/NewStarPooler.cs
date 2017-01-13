using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewStarPooler : MonoBehaviour {

	public static NewStarPooler current;
	//Add different style stars - "Red, Blue, Green, Yellow"
	int amountOfStarStyle = 46;
	//0
	public GameObject[] normalStars;
	//1
	public GameObject[] item1;
	public GameObject[] item2;
	public GameObject[] item3;
	public GameObject[] item4;
	public GameObject[] item5;
	public GameObject[] item6;
	public GameObject[] item7;
	public GameObject[] item8;
	public GameObject[] item9;
	public GameObject[] item10;
	//11
	public GameObject[] item11;
	public GameObject[] item12;
	public GameObject[] item13;
	public GameObject[] item14;
	public GameObject[] item15;
	public GameObject[] item16;
	public GameObject[] item17;
	public GameObject[] item18;
	public GameObject[] item19;
	public GameObject[] item20;
	//21
	public GameObject[] item21;
	public GameObject[] item22;
	public GameObject[] item23;
	public GameObject[] item24;
	public GameObject[] item25;
	public GameObject[] item26;
	public GameObject[] item27;
	public GameObject[] item28;
	public GameObject[] item29;
	public GameObject[] item30;
	//31
	public GameObject[] item31;
	public GameObject[] item32;
	public GameObject[] item33;
	public GameObject[] item34;
	public GameObject[] item35;
	public GameObject[] item36;
	public GameObject[] item37;
	public GameObject[] item38;
	public GameObject[] item39;
	public GameObject[] item40;
	//41
	public GameObject[] item41;
	public GameObject[] item42;
	public GameObject[] item43;
	public GameObject[] item44;
	public GameObject[] item45;
	//----
	public Star[] stars;
	public List<GameObject> star_selection_pool;
	
	int pool_total = 0;
	GameObject[][] pooledObjects;
	
	void Awake(){
		current = this;
	}
	
	void Start () {
		pooledObjects = new GameObject[amountOfStarStyle][];
		//Add different style stars array to pooledObjects
		//0
		pooledObjects[0] = normalStars;
		//1
		pooledObjects[1] = item1;
		pooledObjects[2] = item2;
		pooledObjects[3] = item3;
		pooledObjects[4] = item4;
		pooledObjects[5] = item5;
		pooledObjects[6] = item6;
		pooledObjects[7] = item7;
		pooledObjects[8] = item8;
		pooledObjects[9] = item9;
		pooledObjects[10] = item10;
		//11
		pooledObjects[11] = item11;
		pooledObjects[12] = item12;
		pooledObjects[13] = item13;
		pooledObjects[14] = item14;
		pooledObjects[15] = item15;
		pooledObjects[16] = item16;
		pooledObjects[17] = item17;
		pooledObjects[18] = item18;
		pooledObjects[19] = item19;
		pooledObjects[20] = item20;
		//21
		pooledObjects[21] = item21;
		pooledObjects[22] = item22;
		pooledObjects[23] = item23;
		pooledObjects[24] = item24;
		pooledObjects[25] = item25;
		pooledObjects[26] = item26;
		pooledObjects[27] = item27;
		pooledObjects[28] = item28;
		pooledObjects[29] = item29;
		pooledObjects[30] = item30;
		//31
		pooledObjects[31] = item31;
		pooledObjects[32] = item32;
		pooledObjects[33] = item33;
		pooledObjects[34] = item34;
		pooledObjects[35] = item35;
		pooledObjects[36] = item36;
		pooledObjects[37] = item37;
		pooledObjects[38] = item38;
		pooledObjects[39] = item39;
		pooledObjects[40] = item40;
		//41
		pooledObjects[41] = item41;
		pooledObjects[42] = item42;
		pooledObjects[43] = item43;
		pooledObjects[44] = item44;
		pooledObjects[45] = item45;
		//----
		stars = new Star[2];//only two colors
		for (int i=0;i<stars.Length;i++){
			stars [i] = new Star (pooledObjects [GameData.savings.currentItem][i], Levels.spawnWeight[0][i]);
		}
		BuildPool ();
	}
	
	void BuildPool(){
		foreach(Star star in stars) {
			pool_total+=star.weight;
		}
		star_selection_pool = new List<GameObject>();
		
		int i = 0;
		for (int m = 0; m < stars.Length; m += 1) {
			for (int p = 0; p < stars[m].weight; p += 1) {
				GameObject obj = (GameObject)Instantiate(stars[m].obj);
				obj.SetActive(false);
				star_selection_pool.Add(obj);
				i++;
			}
		}
	}
	
	public GameObject GetPooledObject(){
		if (GameManager.currentLevel <= 3){
			for(int i=Random.Range(0,star_selection_pool.Count);i<star_selection_pool.Count;i++){
				if(!star_selection_pool[i].activeInHierarchy) return star_selection_pool[i];
			}
			for(int i=Random.Range(0,star_selection_pool.Count);i<star_selection_pool.Count;i++){
				if(!star_selection_pool[i].activeInHierarchy) return star_selection_pool[i];
			}
		}
		return null;
	}
	
	public class Star
	{
		public GameObject obj;
		public int weight;
		
		public Star(GameObject o,int w)
		{
			obj = o;
			weight = w;
		}
	}
}
