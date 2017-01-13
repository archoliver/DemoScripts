using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CreateItemScrollList : MonoBehaviour {

	[System.Serializable]
	public class Item{
		public Sprite itemImage;
		public string amount;
		public string type;
		public Button.ButtonClickedEvent clickEvent;
	}
	
	public GameObject sampleItem;
	public List<Item> itemList;
	public List<SampleItem> scrollingList;

	public Transform contentPanel;

	public Color disableColor = new Color(255f/255, 255f/255, 255f/255, 0f/255);
	//Color enableColor = new Color(255f, 255f, 255f, 255f);

	public Color isBoughtColor = new Color(255f/255,255f/255,255f/255,255f/255);
	//Color notBoughtCOlor = new Color(2f,0f,54f,255f);

	public Color diamondFontColor = new Color(255f/255,250f/255,88f/255,255f/255);

	void Start () {
		PopulateList ();
	}

	void PopulateList(){
		int i = 0;
		foreach (var item in itemList){
			GameObject newSampleItem = Instantiate (sampleItem) as GameObject;
			SampleItem newItem = newSampleItem.GetComponent<SampleItem>();

			if (i == 0){
				//Default Stars
				newItem.amount.color = disableColor;
				newItem.type.color = disableColor;
				newItem.itemImage.sprite = item.itemImage;
				newItem.itemImage.gameObject.SetActive(true);
				newItem.panel.color = isBoughtColor;
				newItem.button.onClick = item.clickEvent;
			}else{
				//1-45 Items
				if (GameData.savings.isItemBought[i]){
					//Bought
					newItem.amount.color = disableColor;
					newItem.type.color = disableColor;
					newItem.itemImage.sprite = item.itemImage;
					newItem.itemImage.gameObject.SetActive(true);
					newItem.panel.color = isBoughtColor;
					newItem.button.onClick = item.clickEvent;
				}else{
					//Non Bought
					if (i > 10){
						//diamond font color
						newItem.type.color = diamondFontColor;
					}
					newItem.amount.text = item.amount;
					newItem.type.text = item.type;
					newItem.itemImage.sprite = item.itemImage;
					newItem.button.onClick = item.clickEvent;
				}
			}

			newSampleItem.transform.SetParent(contentPanel);
			newSampleItem.GetComponent<RectTransform>().localScale = new Vector2(1f,1f);
			scrollingList.Add(newItem);
			i++;
		}
	}

}
