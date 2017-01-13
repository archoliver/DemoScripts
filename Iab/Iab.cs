using UnityEngine;
using System.Collections;

public class Iab : MonoBehaviour {

	static string base64EncodedPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwJJKjzbKzMKR/QHsLKkWeoO/Zj5pkGPm+QR3qKzrWMr7cbQghrMjgW6pvR8lOvXJoagc7jaF7o1BY74ujh6MCq139apqXZO6lnmC9h+bq37qnaq/kSxIzBpkFDBBFE06KfVFYHvzLQaP0FgYJ5ZlK6H7MdXXUAvFvP/F1eMBQWzDpq4dHNeEMEACmdt6CsFfxrNHFCTURdBKsfo2VONlIagtApPT5z6F+4JMPSUawAi5DL4kBARXT/WCZ5jXZzvsAz9aobmgTwJ3QV/VS6wor667XZ6tkgaIQfv/i72UEUVdSzNIlM2jgNX9YvcNMC0UL0FBnjcTNtSd5WgpfJ/gdQIDAQAB";

	public static void Init(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("initInappBilling", base64EncodedPublicKey);
		}
		#elif UNITY_IOS
		IAP.iap.init ();
		#endif
	}

	public static void BuyPremium () {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		//subscribe infinite banana gas from store
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("BuyPremium");
		}
		#elif UNITY_IOS
		//IAP.iap.BuyTheProduct("removeads");
		#endif
	}
	
	public static void Buy300Diamonds () {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		//subscribe infinite banana gas from store
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("Buy300Diamonds");
		}
		#elif UNITY_IOS
		IAP.iap.BuyTheProduct("300diamonds");
		#endif
	}
	
	public static void Buy700Diamonds () {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		//subscribe infinite banana gas from store
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("Buy700Diamonds");
		}
		#elif UNITY_IOS
		IAP.iap.BuyTheProduct("700diamonds");
		#endif
	}
	
	public static void Buy1500Diamonds () {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		//subscribe infinite banana gas from store
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("Buy1500Diamonds");
		}
		#elif UNITY_IOS
		IAP.iap.BuyTheProduct("1500diamonds");
		#endif
	}
	
	public static void Buy3500Diamonds () {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		//subscribe infinite banana gas from store
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("Buy3500Diamonds");
		}
		#elif UNITY_IOS
		IAP.iap.BuyTheProduct("3500diamonds");
		#endif
	}
	
	public static void Buy10000Diamonds () {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		//subscribe infinite banana gas from store
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("Buy10000Diamonds");
		}
		#elif UNITY_IOS
		IAP.iap.BuyTheProduct("10000diamonds");
		#endif
	}
}