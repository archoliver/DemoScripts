using UnityEngine;
using System.Collections;
using System;
//using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameData : MonoBehaviour {

	#if UNITY_EDITOR
	[MenuItem("Tools/Clear Save")]
	private static void NewMenuOption()
	{
		File.Delete (Application.persistentDataPath + "/StarRushGamedataa.dat");
	}

	[MenuItem("Tools/Save")]
	private static void SaveOption()
	{
		GameData.savings.Save ();
	}

	#endif

	public static GameData savings;
	
	private string DataPath;
	
	int best;
	public int Best{
		get{
			return best;
		}
		set{
			if (value > best) best = value;
		}
	}
	public int totalStars;
	public int totalDiamonds;
	public int totalFlashLightIlluminate;

	public int diamonds;
	public bool isMute;

	public int currentMission;
	public int currentMissionProgress;

	public int currentChallenge;
	public int CurrentChallenge{
		get{
			return currentChallenge;
		}
		set{
			if (ChallengeManager.musicIndex == currentChallenge) currentChallenge = value;
		}
	}

	public int currentItem;
	public bool[] isItemBought;

	void OnLevelWasLoaded(){
		Application.targetFrameRate = Constants.FrameRate;
	}

	void Awake () {
		if (savings==null){
			DontDestroyOnLoad (gameObject);
			savings = this;
		}else if (savings!=this) Destroy(gameObject);
		
		DataPath = Application.persistentDataPath + "/StarRushGamedataa.dat";
		Load ();
	}
	
	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(DataPath);
		//Stream cryptoStream = new CryptoStream (file, HolaLib.Sec.getEncryptor (), CryptoStreamMode.Write);

		Data data = new Data();
		//----------
		data.best = (float)best;
		data.totalStars = (float)totalStars;
		data.totalDiamonds = (float)totalDiamonds;
		data.totalFlashLightIlluminate = (float)totalFlashLightIlluminate;;
		data.diamonds = (float)diamonds;
		data.isMute = isMute;
		data.currentMissionProgress = (float)currentMissionProgress;
		data.currentMission = (float)currentMission;
		data.currentChallenge = (float)currentChallenge;
		data.currentItem = (float)currentItem;
		data.isItemBought = isItemBought;
		//----------
		//bf.Serialize (cryptoStream, data);
		//cryptoStream.Close ();
		bf.Serialize (file, data);
		file.Close();
	}
	public void Load(){
		if (File.Exists (DataPath)) {
			//Debug.Log(File.ReadAllText(DataPath));
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(DataPath, FileMode.Open);
			//Stream cryptoStream = new CryptoStream (file, HolaLib.Sec.getDecryptor (), CryptoStreamMode.Read);
			//Data data = (Data)bf.Deserialize(cryptoStream);
			//cryptoStream.Close();
			Data data = (Data)bf.Deserialize(file);
			file.Close();
			//----------
			best = (int)data.best;
			totalStars = (int)data.totalStars;
			totalDiamonds = (int)data.totalDiamonds;
			totalFlashLightIlluminate = (int)data.totalFlashLightIlluminate;;
			diamonds = (int)data.diamonds;
			isMute = data.isMute;
			currentMissionProgress = (int)data.currentMissionProgress;
			currentMission = (int)data.currentMission;
			currentChallenge = (int)data.currentChallenge;
			currentItem = (int)data.currentItem;
			isItemBought = data.isItemBought;
			//----------
		}else {
			//init Saving
			isItemBought = new bool[46];
			Save ();
		}
	}
}

[Serializable]
class Data{
	public float best;
	public float totalStars;
	public float totalDiamonds;
	public float totalFlashLightIlluminate;

	public float diamonds;
	public bool isMute;

	public float currentMission;
	public float currentMissionProgress;

	public float currentChallenge;

	public float currentItem;
	public bool[] isItemBought;
}