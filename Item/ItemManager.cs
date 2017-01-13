using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemManager : MonoBehaviour {

	public Text diamonds;

	public GameObject FadeAllImage;
	public Animator FadeAllImageAnim;

	public CreateItemScrollList createItemScrollList;
	
	void Awake(){
		createItemScrollList = GetComponent<CreateItemScrollList> ();
		GameData.savings.Load ();
	}

	void Start(){
		diamonds.text = GameData.savings.diamonds.ToString();
	}

	void Update(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				GoToOtherScene("Menu");
				return;
			}
		}
		#elif UNITY_IOS
		#endif
	}

	public void GoToOtherScene(string sceneName){
		FadeAllImage.SetActive (true);
		FadeAllImageAnim.SetTrigger ("FadeTrig");
		StartCoroutine (GoToOtherSceneDelay(sceneName));
	}
	
	IEnumerator GoToOtherSceneDelay(string sceneName){
		yield return new WaitForSeconds(Constants.sceneFadingTime);
		Application.LoadLevel (sceneName);
	}

	public void BuyOrSetCurrentItem(int itemNumber){
		if (itemNumber == 0) {
			//Default Star
			GameData.savings.currentItem = itemNumber;
			GameData.savings.Save ();
			GoToOtherScene("Menu");
		}else{
			if (GameData.savings.isItemBought[itemNumber]){
				//is Bought
				GameData.savings.currentItem = itemNumber;
				GameData.savings.Save ();
				GoToOtherScene("Menu");
			}else {
				//not Bought
				if (itemNumber <= 10){
					//Finish Mission to Unlock
					if (itemNumber*5 <= GameData.savings.currentMission){
						//unlock item ( change button UI )
						createItemScrollList.scrollingList[itemNumber].amount.color = createItemScrollList.disableColor;
						createItemScrollList.scrollingList[itemNumber].type.color = createItemScrollList.disableColor;
						createItemScrollList.scrollingList[itemNumber].itemImage.gameObject.SetActive(true);
						createItemScrollList.scrollingList[itemNumber].panel.color = createItemScrollList.isBoughtColor;
						GameData.savings.isItemBought[itemNumber] = true;
						GameData.savings.Save();
					}else{
						//TODO - cannot buy because mission not finished
					}
				}else{
					//Diamonds to Unlock
					if (int.Parse(createItemScrollList.scrollingList[itemNumber].amount.text) <= GameData.savings.diamonds){
						//enough diamonds - unlock item( change button UI & use diamonds )
						createItemScrollList.scrollingList[itemNumber].amount.color = createItemScrollList.disableColor;
						createItemScrollList.scrollingList[itemNumber].type.color = createItemScrollList.disableColor;
						createItemScrollList.scrollingList[itemNumber].itemImage.gameObject.SetActive(true);
						createItemScrollList.scrollingList[itemNumber].panel.color = createItemScrollList.isBoughtColor;
						GameData.savings.diamonds -= int.Parse(createItemScrollList.scrollingList[itemNumber].amount.text);
						GameData.savings.isItemBought[itemNumber] = true;
						GameData.savings.Save();
					}else{
						//not enough diamonds
						//TODO - cannot buy because not enough diamonds
					}
				}
			}
		}
	}

}
