using UnityEngine;
using System.Collections;
using HolaLib;

namespace HolaLib
{
	public class NET : MonoBehaviour
	{
		/*
		public static NET instance;
		public static NET Instance { get { return current(); } }

		delegate NET InstanceStep();
		
		static InstanceStep init = delegate()
		{
			GameObject container = new GameObject("NETObject");
			instance = container.AddComponent<NET>();
			//instance.lives = StartingLives;
			//instance.score = StartingScore;
			//instance.highScore = null;
			current = then;
			return instance;
		};
		static InstanceStep then = delegate() { return instance; };
		static InstanceStep current = init;
		*/

		//public string url;
		//private WWW www;
		//public Object result;
		//public WWWForm form;

//		public void init ()
//		{
//			return gameObject.AddComponent ( typeof ( NET ) ) as NET;
//		}

		// Awake
		void Awake()
		{
			//DontDestroyOnLoad(this);
		}
		
		// Use this for initialization
		void Start () {
			//Time.timeScale = 1.0f;
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}

	
		public void wget (string url, responseHandler handler)
		{
			if (!string.IsNullOrEmpty (url)) {
				//url = WWW.EscapeURL (url);
				////Debug.Log (WWW.UnEscapeURL (url));
				if (WWW.UnEscapeURL (url) == url)
					url = url.Substring (0, url.LastIndexOf ("/") + 1) + WWW.EscapeURL (url.Substring (url.LastIndexOf ("/") + 1));
				////Debug.Log (url);
				//www = new WWW (url);
				StartCoroutine (WaitForResponse (url, handler));
			}
		}

		public void postHolaForm (string url, HolaForm form, responseHandler handler)
		{
			if (!string.IsNullOrEmpty (url)) {
				//url = WWW.EscapeURL (url);
				if (WWW.UnEscapeURL (url) == url)
					url = url.Substring (0, url.LastIndexOf ("/") + 1) + WWW.EscapeURL (url.Substring (url.LastIndexOf ("/") + 1));
				//www = new WWW (url, form.form);
				StartCoroutine (WaitForResponse (url, form.form, handler));
			}
		}

		public void postHolaJson (string url, HolaForm hola, HolaResponseHandler handler)
		{
			if (!string.IsNullOrEmpty (url)) {
				//url = WWW.EscapeURL (url);
				if (WWW.UnEscapeURL (url) == url)
					url = url.Substring (0, url.LastIndexOf ("/") + 1) + WWW.EscapeURL (url.Substring (url.LastIndexOf ("/") + 1));
				//www = new WWW (url, form.form);
				StartCoroutine (WaitForResponse (url, hola, handler));
			}
		}
		
		public void postForm (string url, WWWForm form, responseHandler handler)
		{
			if (!string.IsNullOrEmpty (url)) {
				//url = WWW.EscapeURL (url);
				if (WWW.UnEscapeURL (url) == url)
					url = url.Substring (0, url.LastIndexOf ("/") + 1) + WWW.EscapeURL (url.Substring (url.LastIndexOf ("/") + 1));
				//www = new WWW (url, form);
				StartCoroutine (WaitForResponse (url, form, handler));
			}
		}


		public delegate void responseHandler (WWW www, string url = null, WWWForm form = null);

		public void defaultResponseHandler (WWW www, string url = null, WWWForm form = null) {;}

		public delegate void HolaResponseHandler (WWW www, string url = null, HolaForm form = null);


		public IEnumerator WaitForResponse (string url, responseHandler handler)
		{
			WWW www = new WWW (url);
			yield return www;
			handler (www, url);
		}

		/*public IEnumerator WaitForResponse (string url, HolaForm form, responseHandler handler)
		{
			WWW www = new WWW (url, form.form);
			yield return www;
			handler (www, url, form.form);
		}*/
		
		public IEnumerator WaitForResponse (string url, HolaForm hola, HolaResponseHandler handler)
		{
			WWW www = new WWW (url, hola.jsonBytes, hola.headers);
			yield return www;
			handler (www, url, hola);
		}

		public IEnumerator WaitForResponse (string url, WWWForm form, responseHandler handler)
		{
			WWW www = new WWW (url, form);
			yield return www;
			handler (www, url, form);
		}




		/*
		public void wget (string url, responseRetryHandler handler)
		{
			//url = WWW.EscapeURL (url);
			//www = new WWW (url);
			StartCoroutine (WaitForResponse (url, handler));
		}
		
		public void post (string url, HolaForm form, responseRetryHandler handler)
		{
			//url = WWW.EscapeURL (url);
			//www = new WWW (url, form.form);
			StartCoroutine (WaitForResponse (url, form, handler));
		}
		
		public void postWithNonEncryptedForm (string url, WWWForm form, responseRetryHandler handler)
		{
			//url = WWW.EscapeURL (url);
			//www = new WWW (url, form);
			StartCoroutine (WaitForResponse (url, form, handler));
		}
		
		public delegate void responseRetryHandler (WWW www, string url);
		
		public delegate void responseRetryHandler (WWW www, string url, HolaForm form);
		
		public delegate void responseRetryHandler (WWW www, string url, WWWForm form);

		public IEnumerator WaitForResponse (string url, responseRetryHandler handler)
		{
			WWW www = new WWW (url);
			yield return www;
			handler (www, url);
		}
		
		public IEnumerator WaitForResponse (string url, HolaForm form, responseRetryHandler handler)
		{
			WWW www = new WWW (url, form.form);
			yield return www;
			handler (www, url, form);
		}
		
		public IEnumerator WaitForResponse (string url, WWWForm form, responseRetryHandler handler)
		{
			WWW www = new WWW (url, form);
			yield return www;
			handler (www, url, form);
		}
		*/
/*
		public void downloadAudio (string url, downloadAudioCallback callback, WWWForm form = null)
		{
			url = WWW.EscapeURL (url);
			if (form == null)
				www = new WWW (url);
			else
				www = new WWW (url, form);
			StartCoroutine (WaitForAudioClip (callback));
		}

		public delegate void downloadAudioCallback (AudioClip audio);

		public IEnumerator WaitForAudioClip (downloadAudioCallback callback)
		{
			yield return www;
			//audio.clip = www.audioClip;
			//result = www.GetAudioClip (false);
			//callback ((AudioClip)result);
			callback (www.GetAudioClip (false));
		}

//	public void Update ()
//	{
//		if (audio.clip != null && !audio.isPlaying && audio.clip.isReadyToPlay)
//			audio.Play ();
//	}


		public void downloadTexture (string url, downloadTextureCallback callback, WWWForm form = null)
		{
			url = WWW.EscapeURL (url);
			if (form == null)
				www = new WWW (url);
			else
				www = new WWW (url, form);
			StartCoroutine (WaitForTexture (callback));
		}

		public delegate void downloadTextureCallback (Texture texture);
	
		public IEnumerator WaitForTexture (downloadTextureCallback callback)
		{
			yield return www;
			//audio.clip = www.audioClip;
			//result = www.texture;
			//callback ((Texture) result);
			callback (www.texture);
		}
	
		public void downloadText (string url, downloadTextCallback callback, WWWForm form = null)
		{
			url = WWW.EscapeURL (url);
			if (form == null)
				www = new WWW (url);
			else
				www = new WWW (url, form);
			StartCoroutine (WaitForText (callback));
		}
	
		public delegate void downloadTextCallback (string text);
	
		public IEnumerator WaitForText (downloadTextCallback callback)
		{
			yield return www;
			//audio.clip = www.audioClip;
			//result = www.text;
			callback (www.text);
		}
*/


	}
}
