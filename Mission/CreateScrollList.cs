using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateScrollList : MonoBehaviour {

	public GameObject sampleMission;

	public Transform contentPanel;
	public RectTransform contentPanelRect;

	Color disableColor = new Color(255f, 255f, 255f, 0f);
	Color enableColor = new Color(255f, 255f, 255f, 255f);

	void Start () {
		GameData.savings.Load ();
		PopulateList ();
		contentPanelRect.anchoredPosition = new Vector2 (0f, GameData.savings.currentMission * Missions.missionPanelHeightPlusSpacing);
	}

	void PopulateList(){
		int missionNum = 0;
		foreach (var mission in Missions.missionContent) {
			GameObject newMission = Instantiate (sampleMission) as GameObject;
			SampleMission sMission = newMission.GetComponent<SampleMission>();
			//Title
			sMission.title.text = "Mission " + (missionNum+1).ToString();

			if (GameData.savings.currentMission < missionNum){
				//--Lock
				//Content
				sMission.content.color = disableColor;
				//Progress Bar
				sMission.progressBar.color = disableColor;
				sMission.progressTotal.color = disableColor;
				//Finish(Green) Progress Bar
				sMission.finishedProgres.fillAmount = 0;
				//Lock
				sMission.imagelock.color = enableColor;
			}else if (GameData.savings.currentMission > missionNum){
				//--Complete
				//Content
				sMission.content.text = mission.content;
				//Progress Bar
				sMission.progressTotal.text = "Complete";
				//Finish(Green) Progress Bar
				sMission.finishedProgres.fillAmount = 1f;
				//Lock
				sMission.imagelock.color = disableColor;
			}else if (GameData.savings.currentMission == missionNum){
				//--Current
				//Content
				sMission.content.text = mission.content;
				//Progress Bar
				sMission.progressTotal.text = GameData.savings.currentMissionProgress.ToString() + "/" + mission.progressTotal;
				//Finish(Green) Progress Bar
				sMission.finishedProgres.fillAmount = GameData.savings.currentMissionProgress / (float)mission.progressTotal;
				//Lock
				sMission.imagelock.color = disableColor;
			}
			//set parent to content panel
			newMission.transform.SetParent(contentPanel);
			newMission.GetComponent<RectTransform>().localScale = new Vector2(1f,1f);
			missionNum++;
		}
	}

}
