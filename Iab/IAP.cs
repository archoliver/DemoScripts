using HolaLib;
using System.Security.Cryptography;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine;
using MobileIAP;
using MobileIAP.Api;

public class IAP : MonoBehaviour {

	public static IAP iap;

	public Text theShopText;
	IAPManager iapManager;
	public Dictionary<string, string> iapSKProducts;
	public GameObject[] buttonArr;
	bool isAllowToBuy = false;
	//bool isAdsPurchased = false;
	mStarRush mstarRush;
	IAPRequest iapr;

	void Awake(){
#if UNITY_EDITOR
#elif UNITY_IOS
		Environment.SetEnvironmentVariable ("MONO_REFLECTION_SERIALIZER", "yes");
		DontDestroyOnLoad (gameObject);
#endif
		mstarRush = GetComponent<mStarRush> ();
		iap = this;
	}

	public void init(){
		RequestIAP ();
		mStarRush.mPremium = false;
		//mStarRush.mPremium = ReadIsRemoveAdsInFile();
		mstarRush.mPremiumFromiOS (mStarRush.mPremium);
	}
	/*
	public bool ReadIsRemoveAds(){
		return isAdsPurchased;
	}

	private bool ReadIsRemoveAdsInFile(){
		//Debug.Log("ReadIsRemoveAdsInFile");
		bool isAdsPurchased = false;
		if(File.Exists(Application.persistentDataPath + "/data48.data")) {//Debug.Log("if:yes");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/data48.data", FileMode.Open);
			Stream cryptoStream = new CryptoStream (file, HolaLib.Sec.getDecryptor(), CryptoStreamMode.Read);
			isAdsPurchased = (bool)bf.Deserialize(cryptoStream);
			cryptoStream.Close ();
			file.Close();

		}
		//Debug.Log("if:no");

		return isAdsPurchased;
	}
	
	private void SaveIsRemoveAdsInFile(){
		//Debug.Log("SaveIsRemoveAdsInFile");
		bool isAdsPurchased = true;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/data48.data");
		Stream cryptoStream = new CryptoStream (file, HolaLib.Sec.getEncryptor(), CryptoStreamMode.Write);
		binaryFormatter.Serialize(cryptoStream, isAdsPurchased);
		cryptoStream.Close ();
		file.Close();
	}
*/
	private void RequestIAP(){
		//Debug.Log ("---IAP: RequestIAP---");
		iapManager = new IAPManager ();
		//Register for iap events
			//iapManager.IAPSKProductsLoaded += HandleIAPSKProductsLoaded;
		iapManager.SKProductsReceivedEvent += HandleISKProductsReceived;
		iapManager.SKPaymentTransactionStatePurchasedEvent += HandleSKPaymentTransactionStatePurchased;
		//Load SKProducts
		iapManager.LoadSKProducts (SetSKProducts());
	}

	private IAPRequest SetSKProducts(){
		//Debug.Log ("---IAP: SetSKProducts---");
		iapr = new IAPRequest();
		//iapr.addProductID ("removeads", "hk.com.holatech.starrush.removeads");
		iapr.addProductID ("300diamonds", "hk.com.holatech.starrush.300diamonds");
		iapr.addProductID ("700diamonds", "hk.com.holatech.starrush.700diamonds");
		iapr.addProductID ("1500diamonds", "hk.com.holatech.starrush.1500diamonds");
		iapr.addProductID ("3500diamonds", "hk.com.holatech.starrush.3500diamonds");
		iapr.addProductID ("10000diamonds", "hk.com.holatech.starrush.10000diamonds");
		return iapr;
	}

	public void BuyTheProduct(string productId){
		//Debug.Log ("---IAP: BuyTheProduct---");
		isAllowToBuy = false;
		iapManager.BuyTheProduct (productId);
	}

	#region IAP Callback handlers
	public void HandleISKProductsReceived (object sender, EventArgs args)
	{
		//Debug.Log ("---IAP: HandleISKProductsReceived---");
		isAllowToBuy = true;
	}
	public void HandleSKPaymentTransactionStatePurchased (object sender, SKPaymentTransactionStatePurchasedEventArgs args)
	{
		//Debug.Log ("HandleSKPaymentTransactionStatePurchased");
		string str1 = args.str;
		/*
		if(str1 == iapr.IAPSKProducts["removeads"]){
			SaveIsRemoveAdsInFile ();
			mstarRush.SetmPremiumToTrueFromiOS ();
		}else 
		*/
		if (str1 == iapr.IAPSKProducts["300diamonds"]){
			mstarRush.m300DiamondsFromAndroid();
		}else if (str1 == iapr.IAPSKProducts["700diamonds"]){
			mstarRush.m700DiamondsFromAndroid();
		}else if (str1 == iapr.IAPSKProducts["1500diamonds"]){
			mstarRush.m1500DiamondsFromAndroid();
		}else if (str1 == iapr.IAPSKProducts["3500diamonds"]){
			mstarRush.m3500DiamondsFromAndroid();
		}else if (str1 == iapr.IAPSKProducts["10000diamonds"]){
			mstarRush.m10000DiamondsFromAndroid();
		}
		
		DiamondManager.isBuying = false;

	}
	#endregion

	
}
