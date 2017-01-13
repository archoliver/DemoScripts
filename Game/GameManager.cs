using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	mStarRush mstarRush;

	public Text score;
	public GameObject greenFlashLight;
	public GameObject yellowFlashLight;
	//Result
	public GameObject scoreObject;
	public GameObject resultPanel;
	public Text resultScore;
	public CanvasGroup flashLightButton;
	public GameObject missionComplete;
	//fading
	public GameObject FadeAllImage;
	public Animator FadeAllImageAnim;

	int startingLevel = 0;
	public static int currentLevel;
	int startingScore = 0;
	int currentScore;

	public int CurrentScore{
		get{
			return currentScore;
		}
		set{
			currentScore = value;
			//set score to text
			score.text = CurrentScore.ToString ();
			//Prevent exceed Max Level
			if (currentScore >= Levels.advancedLevelScores[currentLevel] && currentLevel <Levels.maxLevel){
				currentLevel++;
				//Activate Green and Yellow
				if (Levels.IsFourColor){
					greenFlashLight.SetActive(true);
					yellowFlashLight.SetActive(true);
				}
			}
		}
	}

	public static Recordings recordings;

	void Awake(){
		mstarRush = GameObject.Find ("mStarRush").GetComponent<mStarRush>();
	}

	void Start(){
		//show banner
		mstarRush.ShowBanner ();
		ChallengeGameManager.isMusicGame = false;
		//Score
		currentScore = startingScore;
		score.text = currentScore.ToString ();
		//Level
		currentLevel = startingLevel;
		//play recordings
		recordings = new Recordings();
	}

	public void Result(){
		resultScore.text = CurrentScore.ToString ();
		scoreObject.SetActive (false);
		resultPanel.SetActive (true);
		GameData.savings.diamonds += (recordings.collectedRedDiamonds + recordings.collectedBlueDiamonds + recordings.collectedGreenDiamonds + recordings.collectedYellowDiamonds);
		GameData.savings.Best = CurrentScore;
		GameData.savings.totalStars += (recordings.collectedRedStars + recordings.collectedBlueStars + recordings.collectedGreenStars + recordings.collectedYellowStars);
		GameData.savings.totalDiamonds += (recordings.collectedRedDiamonds + recordings.collectedBlueDiamonds + recordings.collectedGreenDiamonds + recordings.collectedYellowDiamonds);
		GameData.savings.totalFlashLightIlluminate += (recordings.flashedRedLight + recordings.flashedBlueLight + recordings.flashedGreenLight + recordings.flashedYellowLight);
		CheckAchievementAndLeaderboard ();
		MissionChecking ();
		GameData.savings.Save ();
		//ads
		mstarRush.ShowInterstitial ();
	}

	void CheckAchievementAndLeaderboard(){
		GPGandGC.gpgAndGC.UnlockAchievements (GameData.savings.Best);
		GPGandGC.gpgAndGC.PostToLeaderboard (GameIds.Leaderboard.Best, GameData.savings.Best);
		GPGandGC.gpgAndGC.PostToLeaderboard (GameIds.Leaderboard.TotalStars, GameData.savings.totalStars);
		GPGandGC.gpgAndGC.PostToLeaderboard (GameIds.Leaderboard.TotalDiamonds, GameData.savings.totalDiamonds);
		GPGandGC.gpgAndGC.PostToLeaderboard (GameIds.Leaderboard.TotalFlashLightIlluminate, GameData.savings.totalFlashLightIlluminate);
	}

	public void DisableFlashLightTouch(){
		flashLightButton.blocksRaycasts = false;
	}

	void MissionComplete(){
		GameData.savings.currentMission++;
		GameData.savings.currentMissionProgress = 0;
		//Show Mission Complete
		missionComplete.SetActive (true);
		missionComplete.GetComponent<Text>().text = "Mission " + GameData.savings.currentMission + " Complete!!";
	}

	void MissionChecking(){
		if (Missions.missionContent[GameData.savings.currentMission].type1 == Missions.Type.total){
			if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.star){
				if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.red){
					if (GameData.savings.currentMissionProgress + recordings.collectedRedStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedRedStars;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.blue){
					if (GameData.savings.currentMissionProgress + recordings.collectedBlueStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedBlueStars;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.green){
					if (GameData.savings.currentMissionProgress + recordings.collectedGreenStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedGreenStars;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.yellow){
					if (GameData.savings.currentMissionProgress + recordings.collectedYellowStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedYellowStars;
					}
				}else{
					if (GameData.savings.currentMissionProgress + recordings.collectedRedStars + recordings.collectedBlueStars + recordings.collectedGreenStars + recordings.collectedYellowStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedRedStars + recordings.collectedBlueStars + recordings.collectedGreenStars + recordings.collectedYellowStars;
					}
				}
			}else if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.diamond){
				if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.red){
					if (GameData.savings.currentMissionProgress + recordings.collectedRedDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedRedDiamonds;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.blue){
					if (GameData.savings.currentMissionProgress + recordings.collectedBlueDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedBlueDiamonds;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.green){
					if (GameData.savings.currentMissionProgress + recordings.collectedGreenDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedGreenDiamonds;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.yellow){
					if (GameData.savings.currentMissionProgress + recordings.collectedYellowDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedYellowDiamonds;
					}
				}else{
					if (GameData.savings.currentMissionProgress + recordings.collectedRedDiamonds + recordings.collectedBlueDiamonds + recordings.collectedGreenDiamonds + recordings.collectedYellowDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.collectedRedDiamonds + recordings.collectedBlueDiamonds + recordings.collectedGreenDiamonds + recordings.collectedYellowDiamonds;
					}
				}
			}else if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.flashLight){
				if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.red){
					if (GameData.savings.currentMissionProgress + recordings.flashedRedLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.flashedRedLight;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.blue){
					if (GameData.savings.currentMissionProgress + recordings.flashedBlueLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.flashedBlueLight;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.green){
					if (GameData.savings.currentMissionProgress + recordings.flashedGreenLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.flashedGreenLight;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.yellow){
					if (GameData.savings.currentMissionProgress + recordings.flashedYellowLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.flashedYellowLight;
					}
				}else{
					if (GameData.savings.currentMissionProgress + recordings.flashedRedLight + recordings.flashedBlueLight + recordings.flashedGreenLight + recordings.flashedYellowLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress += recordings.flashedRedLight + recordings.flashedBlueLight + recordings.flashedGreenLight + recordings.flashedYellowLight;
					}
				}
			}else if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.score){
				if (GameData.savings.currentMissionProgress + CurrentScore >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
					MissionComplete();
				}else{
					GameData.savings.currentMissionProgress += CurrentScore;
				}
			}
		}else if (Missions.missionContent[GameData.savings.currentMission].type1 == Missions.Type.single){
			if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.star){
				if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.red){
					if (recordings.collectedRedStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedRedStars;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.blue){
					if (recordings.collectedBlueStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedBlueStars;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.green){
					if (recordings.collectedGreenStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedGreenStars;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.yellow){
					if (recordings.collectedYellowStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedYellowStars;
					}
				}else{
					if (recordings.collectedRedStars + recordings.collectedBlueStars + recordings.collectedGreenStars + recordings.collectedYellowStars >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedRedStars + recordings.collectedBlueStars + recordings.collectedGreenStars + recordings.collectedYellowStars;
					}
				}
			}else if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.diamond){
				if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.red){
					if (recordings.collectedRedDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedRedDiamonds;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.blue){
					if (recordings.collectedBlueDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedBlueDiamonds;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.green){
					if (recordings.collectedGreenDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedGreenDiamonds;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.yellow){
					if (recordings.collectedYellowDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedYellowDiamonds;
					}
				}else{
					if (recordings.collectedRedDiamonds + recordings.collectedBlueDiamonds + recordings.collectedGreenDiamonds + recordings.collectedYellowDiamonds >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.collectedRedDiamonds + recordings.collectedBlueDiamonds + recordings.collectedGreenDiamonds + recordings.collectedYellowDiamonds;
					}
				}
			}else if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.flashLight){
				if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.red){
					if (recordings.flashedRedLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.flashedRedLight;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.blue){
					if (recordings.flashedBlueLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.flashedBlueLight;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.green){
					if (recordings.flashedGreenLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.flashedGreenLight;
					}
				}else if (Missions.missionContent[GameData.savings.currentMission].color == Missions.Type.yellow){
					if (recordings.flashedYellowLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.flashedYellowLight;
					}
				}else{
					if (recordings.flashedRedLight + recordings.flashedBlueLight + recordings.flashedGreenLight + recordings.flashedYellowLight >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
						MissionComplete();
					}else{
						GameData.savings.currentMissionProgress = recordings.flashedRedLight + recordings.flashedBlueLight + recordings.flashedGreenLight + recordings.flashedYellowLight;
					}
				}
			}else if (Missions.missionContent[GameData.savings.currentMission].type2 == Missions.Type.score){
				if (CurrentScore >= Missions.missionContent[GameData.savings.currentMission].progressTotal){
					MissionComplete();
				}else{
					GameData.savings.currentMissionProgress = CurrentScore;
				}
			}
		}
	}

	public void GoToOtherScene(string sceneName){
		Time.timeScale = 1;
		FadeAllImage.SetActive (true);
		FadeAllImageAnim.SetTrigger ("FadeTrig");
		StartCoroutine (GoToOtherSceneDelay(sceneName));
	}
	
	IEnumerator GoToOtherSceneDelay(string sceneName){
		yield return new WaitForSeconds(Constants.sceneFadingTime);
		Application.LoadLevel (sceneName);
	}

}
