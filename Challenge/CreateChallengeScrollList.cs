using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CreateChallengeScrollList : MonoBehaviour {

	[System.Serializable]
	public class Challenge{
		public string name;
		public Button.ButtonClickedEvent clickEvent;
	}

	public GameObject sampleChallenge;
	public List<Challenge> challengeList;

	public Transform contentPanel;

	Color enableColor = new Color(255f, 255f, 255f, 255f);

	void Start () {
		GameData.savings.Load ();
		PopulateList ();
	}

	void PopulateList() {
		int challengeNum = 0;
		foreach (var challenge in challengeList){
			GameObject newSampleChallenge = Instantiate (sampleChallenge) as GameObject;
			SampleChallenge newChallenge = newSampleChallenge.GetComponent<SampleChallenge>();

			if (challengeNum < GameData.savings.currentChallenge){
				//Unlocked Challenge
				newChallenge.songName.text = challenge.name;
				newChallenge.diamond.SetActive(false);
				newChallenge.complete.color = enableColor;
				newChallenge.button.onClick = challenge.clickEvent;
			}else if (challengeNum > GameData.savings.currentChallenge){
				//Locked Challenge
				newChallenge.songName.text = "Locked";
				newChallenge.amount.text = "+" + Challenges.challengeReward[challengeNum].ToString();
				newChallenge.button.interactable = false;
			}else{
				//current Challenge
				newChallenge.songName.text = challenge.name;
				newChallenge.amount.text = "+" + Challenges.challengeReward[challengeNum].ToString();
				newChallenge.button.onClick = challenge.clickEvent;
			}

			newSampleChallenge.transform.SetParent(contentPanel);
			newSampleChallenge.GetComponent<RectTransform>().localScale = new Vector2(1f,1f);
			challengeNum++;
		}
	}

}
