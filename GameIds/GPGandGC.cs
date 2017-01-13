using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
#elif UNITY_ANDROID
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
#elif UNITY_IOS
using UnityEngine.SocialPlatforms.GameCenter;
#endif


public class GPGandGC : MonoBehaviour {

	public static GPGandGC gpgAndGC;

	void Awake(){
		if (gpgAndGC==null){
			DontDestroyOnLoad (gameObject);
			gpgAndGC = this;
		}else if (gpgAndGC!=this) Destroy(gameObject);
	}

	void Start(){
		Authenticate ();
	}

	bool mAuthenticating = false;
	
	// list of achievements we know we have unlocked (to avoid making repeated calls to the API)
	Dictionary<string,bool> mUnlockedAchievements = new Dictionary<string, bool>();

	void Authenticate() {
		if (Authenticated || mAuthenticating) {
			//Debug.LogWarning("Ignoring repeated call to Authenticate().");
			return;
		}

		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		PlayGamesPlatform.DebugLogEnabled = false;
		PlayGamesPlatform.Activate();
		#elif UNITY_IOS
		GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
		#endif

		// Set the default leaderboard for the leaderboards UI
		//((PlayGamesPlatform) Social.Active).SetDefaultLeaderboardForUI(GameIds.Leaderboard.Best);
		
		// Sign in
		mAuthenticating = true;
		Social.localUser.Authenticate((bool success) => {
			mAuthenticating = false;
			/*
			if (success){
				Debug.Log("Authenticate success");
			}else{
				Debug.Log("Authenticate failed");
			}
			*/
		});
	}

//	void Authenticate() {
//		mAuthenticating = false;
//	}

	public void UnlockAchievements(int totalScore) {
		#if UNITY_EDITOR
		#elif (UNITY_ANDROID || UNITY_IOS)
		int i;
		for (i = 0; i < GameIds.Achievements.BestScore.Length; i++) {
			int scoreRequired = GameIds.Achievements.BestRequired[i];
			if (totalScore >= scoreRequired) {
				UnlockAchievement(GameIds.Achievements.BestScore[i]);
			}
		}
		#endif
	}
	
	void UnlockAchievement(string achId) {
		#if UNITY_EDITOR
		#elif (UNITY_ANDROID || UNITY_IOS)
		if (Authenticated && !mUnlockedAchievements.ContainsKey(achId)) {
			Social.ReportProgress(achId, 100.0f, (bool success) => {});
			mUnlockedAchievements[achId] = true;

		}
		#endif
	}
	
	bool Authenticated {
		get {
			return Social.Active.localUser.authenticated;
		}
	}
	
	public void ShowLeaderboardUI() {
		if (Authenticated) {
			Social.ShowLeaderboardUI();
		}
	}
	
	public void ShowAchievementsUI() {
		if (Authenticated) {
			Social.ShowAchievementsUI();
		}
	}
	
	public void PostToLeaderboard(string leadId, int score) {
		#if UNITY_EDITOR
		#elif (UNITY_ANDROID || UNITY_IOS)
		if (Authenticated) {
			// post score to the leaderboard
			Social.ReportScore(score, leadId, (bool success) => {
				/*
				if (success){
					Debug.Log("post score success");
				}else{
					Debug.Log("post score failed");
				}
				*/
			});
		}
		#endif
	}
}
