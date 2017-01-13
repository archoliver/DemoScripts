using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MusicPlayer : MonoBehaviour {

	public ChallengeStarSpawner challengeStarSpawner;
	public ChallengeGameManager challengeGameManager;

	[SerializeField]
	public string numberOfSongs = "1";

	[SerializeField]
	[HideInInspector]
	public string[] songsName = {
		"","","","","","","","","","",
		"","","","","","","","","","",
		"","","","","","","","","",""
	};

	[SerializeField]
	[HideInInspector]
	public string[] musicNote = {
		"","","","","","","","","","",
		"","","","","","","","","","",
		"","","","","","","","","",""
	};
	[SerializeField]
	[HideInInspector]
	public string[] musicInterval = {
		"","","","","","","","","","",
		"","","","","","","","","","",
		"","","","","","","","","",""
	};

	[SerializeField]
	[HideInInspector]
	public string[] musicTempo = {
		"","","","","","","","","","",
		"","","","","","","","","","",
		"","","","","","","","","",""
	};
	
	//----
	AudioSource[] speakers;
	
	Dictionary<string,AudioClip> tones;

	public List<string[][]> musics;
	public int currentMusicIndex;
	int currentStarIndex;
	public int currentToneIndex;
	List<tempo> tempos;
	List<float[]> intervals;
	
	AudioClip loseClip;
	
	void Awake () {
		speakers = GetComponents<AudioSource> ();
		
		tones = new Dictionary<string, AudioClip> ();
		tones["A"] = Resources.Load ("Sounds/A3") as AudioClip;
		tones["A#"] = Resources.Load ("Sounds/Bb3") as AudioClip;
		tones["A'"] = Resources.Load ("Sounds/A4") as AudioClip;
		tones["A'#"] = Resources.Load ("Sounds/Bb4") as AudioClip;
		tones["B."] = Resources.Load ("Sounds/B2") as AudioClip;
		tones["B"] = Resources.Load ("Sounds/B3") as AudioClip;
		tones["B'"] = Resources.Load ("Sounds/B4") as AudioClip;
		tones["C"] = Resources.Load ("Sounds/C3") as AudioClip;
		tones["C#"] = Resources.Load ("Sounds/Db3") as AudioClip;
		tones["C'"] = Resources.Load ("Sounds/C4") as AudioClip;
		tones["C'#"] = Resources.Load ("Sounds/Db4") as AudioClip;
		tones["C''"] = Resources.Load ("Sounds/C5") as AudioClip;
		tones["C''#"] = Resources.Load ("Sounds/Db5") as AudioClip;
		tones["D"] = Resources.Load ("Sounds/D3") as AudioClip;
		tones["D#"] = Resources.Load ("Sounds/Eb3") as AudioClip;
		tones["D'"] = Resources.Load ("Sounds/D4") as AudioClip;
		tones["D'#"] = Resources.Load ("Sounds/Eb4") as AudioClip;
		tones["D''"] = Resources.Load ("Sounds/D5") as AudioClip;
		tones["D''#"] = Resources.Load ("Sounds/Eb5") as AudioClip;
		tones["D'''"] = Resources.Load ("Sounds/D6") as AudioClip;
		tones["E"] = Resources.Load ("Sounds/E3") as AudioClip;
		tones["E'"] = Resources.Load ("Sounds/E4") as AudioClip;
		tones["E''"] = Resources.Load ("Sounds/E5") as AudioClip;
		tones["F"] = Resources.Load ("Sounds/F3") as AudioClip;
		tones["F#"] = Resources.Load ("Sounds/Gb3") as AudioClip;
		tones["F'"] = Resources.Load ("Sounds/F4") as AudioClip;
		tones["F'#"] = Resources.Load ("Sounds/Gb4") as AudioClip;
		tones["F''#"] = Resources.Load ("Sounds/Gb5") as AudioClip;
		tones["G"] = Resources.Load ("Sounds/G3") as AudioClip;
		tones["G#"] = Resources.Load ("Sounds/Ab3") as AudioClip;
		tones["G'"] = Resources.Load ("Sounds/G4") as AudioClip;
		tones["G'#"] = Resources.Load ("Sounds/Ab4") as AudioClip;
		tones["G''"] = Resources.Load ("Sounds/G5") as AudioClip;
		
		musics = new List<string[][]> ();
		tempos = new List<tempo> ();
		intervals = new List<float[]> ();

		AddMusic();

	}

	void Start(){
		currentMusicIndex = ChallengeManager.musicIndex;
	}

	void AddMusic(){
		//music note
		for(int i=0;i<int.Parse(numberOfSongs);i++){
			string[] musicNoteSplit1 = musicNote[i].Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			string[][] musicNoteSplit2 = new string[musicNoteSplit1.Length][];
			for(int j=0;j<musicNoteSplit1.Length;j++){
				musicNoteSplit2[j] = musicNoteSplit1[j].Split(',');
			}
			musics.Add(musicNoteSplit2);
		}
		//Intervals
		for(int i=0;i<int.Parse(numberOfSongs);i++){
			string[] musicIntervalSplit1 = musicInterval[i].Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			float[] musicIntervalSplit2 = new float[musicIntervalSplit1.Length];
			for(int j=0;j<musicIntervalSplit1.Length;j++){
				if (musicIntervalSplit1[j].IndexOf('/') == -1)
					musicIntervalSplit2[j] = float.Parse(musicIntervalSplit1[j]);
				else{
					musicIntervalSplit2[j] = 
						float.Parse(musicIntervalSplit1[j].Substring(0, musicIntervalSplit1[j].IndexOf('/'))) / 
							float.Parse(musicIntervalSplit1[j].Substring(musicIntervalSplit1[j].IndexOf('/')+1));
				}
			}
			intervals.Add(musicIntervalSplit2);
		}
		//Tempos
		for(int i=0;i<int.Parse (numberOfSongs);i++){
			string[] musicTempoSplit = musicTempo[i].Split(',');
			tempos.Add (new tempo (float.Parse(musicTempoSplit[0]), float.Parse(musicTempoSplit[1])));
		}
	}
	
	public void PlayOne () {
		if (!GameData.savings.isMute){
			try {
				for (int i=0; i<musics [currentMusicIndex][currentToneIndex].Length; i++) {
					speakers[i].PlayOneShot (tones[musics[currentMusicIndex][currentToneIndex][i]]);
				}
			} catch {
			}
		}
		currentToneIndex++;
//		if (currentToneIndex >= musics[currentMusicIndex].Length) {
//			reset();
//		}
	}

//	public void PlayTone (string[] tone) {
//		try {
//			for (int i=0; i<tone.Length; i++) {
//				speakers[i].PlayOneShot (tones[tone[i]]);
//			}
//		} catch {
//		}
//	}

	public IEnumerator PlayMusic () {
		while (true) {
//			try {
//				for (int i=0; i<musics [currentMusicIndex][currentStarIndex].Length; i++) {
//
//					//speakers [i].PlayOneShot (tones [musics [currentMusicIndex] [currentToneIndex] [i]]);
//				}
//			} catch {}
			challengeStarSpawner.Spawn();
			yield return new WaitForSeconds ( (1 / intervals [currentMusicIndex] [currentStarIndex]) * tempos [currentMusicIndex].IntervalTime);
			currentStarIndex++;
			if (currentStarIndex >= musics [currentMusicIndex].Length) {
				//yield return new WaitForSeconds(2f);
				//reset ();
				StopCoroutine("PlayMusic");
				yield return 0;
			}
		}
	}

//	public void PlayLoseSound () {
//		try {
//			speakers[0].PlayOneShot(loseClip);
//		} catch {}
//	}
	
	public void reset () {
		//currentMusicIndex = UnityEngine.Random.Range (0, musics.Count);
		currentToneIndex = 0;
	}
}
