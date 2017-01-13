using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using HolaLib;

public class MoreGamesManager : MonoBehaviour {

	//modify this app_id
	public string app_id;

	public GameObject FadeAllImage;
	public Animator FadeAllImageAnim;

	mStarRush mstarRush;

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

	//public readonly string Url = "http://api-holatech.rhcloud.com/HolaApp/moregames/";
	public readonly string Url = "http://holatech.byethost15.com/api/moregames/";
	NET net;

	List<Dictionary<string,object>> gamesInfo;
	public List<Dictionary<string, object>> GamesInfo {
		get {
			return gamesInfo;
		}
		set {
			gamesInfo = value;
		}
	}

	Dictionary<string,int> icon_uri_to_gameInfo;

	public GameObject loadingText;

	[System.Serializable]
	public class Game{
		//public Texture icon;
		public string app_id;
		public string name;
		public string description;
		public string link;
	}

	public GameObject sampleMoreGame;
	public List<Game> gameList;
	public Transform contentPanel;

	// Use this for initialization
	void Awake () {
		mstarRush = GameObject.Find ("mStarRush").GetComponent<mStarRush>();
		net = GetComponent<NET> ();
		LoadGameListFromServer ();
	}
	
	void Start(){
		mstarRush.HideBanner ();
	}

	public void LoadGameListFromServer () {
		string url = "";
		#if UNITY_EDITOR
		url = Url + "Android";
		#elif UNITY_IOS
		url = Url + "iOS";
		#elif UNITY_ANDROID
		url = Url + "Android";
		#endif
		//Debug.Log ("Start Load Game From Server...");
		loadingText.SetActive (true);
		net.wget(url, LoadGameListFromServerResponseHandler);
	}

	void LoadGameListFromServerResponseHandler (WWW www, string url, WWWForm form = null) {
		loadingText.SetActive (false);
		//Debug.Log ("Server Respond.");
		if (!string.IsNullOrEmpty (www.text)) {
			//Debug.Log (www.text);
			gamesInfo = new List<Dictionary<string, object>>();
			gameList = new List<Game>();
			icon_uri_to_gameInfo = new Dictionary<string, int>();
			List<object> result = JsonHandler.DeserializeAsList(www.text);

			foreach (object r in result) {
				Dictionary<string, object> game = (Dictionary<string, object>)r;
				if (game.ContainsKey("icon_uri")) {
					icon_uri_to_gameInfo.Add((string)game["icon_uri"], gamesInfo.Count);
					net.wget((string)game["icon_uri"], LoadIconFromServerResponseHandler);
				}
				gamesInfo.Add((Dictionary<string, object>)r);

				Game g = new Game();
				if (game.ContainsKey("app_id")){
					g.app_id = (string)game["app_id"];
				}
				if (game.ContainsKey("name")) {
					g.name = (string)game["name"];
				}
				if (game.ContainsKey("uri")) {
					g.link = (string)game["uri"];
				}
				if (game.ContainsKey("description")) {
					g.description = (string)game["description"];
				}
				gameList.Add(g);
			}
		}
		PopulateList ();
	}
	void LoadIconFromServerResponseHandler (WWW www, string url, WWWForm form = null) {
		if (www.texture != null) {
			//Debug.Log("loadIconResponseHandler: " + url);
			gamesInfo[icon_uri_to_gameInfo[url]]["icon"] = www.texture;
			//gameList[icon_uri_to_gameInfo[url]].icon = (Texture)gamesInfo[icon_uri_to_gameInfo[url]]["icon"];
			//Debug.Log(icon_uri_to_gameInfo[url]);
			if (sampleMoreGameArr[icon_uri_to_gameInfo[url]] != null )
				sampleMoreGameArr[icon_uri_to_gameInfo[url]].icon.texture = (Texture)gamesInfo[icon_uri_to_gameInfo[url]]["icon"];
		}
	}

	//for async icon loading
	SampleMoreGame[] sampleMoreGameArr;

	void PopulateList(){
		sampleMoreGameArr = new SampleMoreGame[gameList.Count];
		int MoreGameNum = 0;
		foreach (var game in gameList){
			if (game.app_id != app_id){
				GameObject newSampleMoreGames = Instantiate (sampleMoreGame) as GameObject;
				SampleMoreGame newMoreGame = newSampleMoreGames.GetComponent<SampleMoreGame>();

				//Title
				newMoreGame.title.text = game.name;
				//Description
				newMoreGame.description.text = game.description;
				//Download Button
				AddListener(newMoreGame.downloadButton, game.link);
				//Add to Scroll list
				newMoreGame.transform.SetParent(contentPanel);
				newMoreGame.GetComponent<RectTransform>().localScale = new Vector2(1f,1f);
				//Array for async icon loading
				sampleMoreGameArr[MoreGameNum] = newMoreGame;
			}
			MoreGameNum++;
		}
	}

	//add download button listener
	void AddListener(Button b, string value){
		b.onClick.AddListener(() => OpenUrl(value));
	}
	
	public void OpenUrl(string url){
		Application.OpenURL(url);
	}

}
