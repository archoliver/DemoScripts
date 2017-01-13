using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//using System.Runtime.Serialization.Json;
//using JsonFx;
//using LitJson;
using MiniJSON;
using HolaLib;

namespace HolaLib
{
	public static class JsonHandler
	{
/*
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
*/

		public static Dictionary<string, object> Deserialize (string jsonString)
		{
			//JavaScriptSerializer serializer = new JavaScriptSerializer();

			//DataContractJsonSerializer dcjs = new DataContractJsonSerializer(List<object>);

			/*
			string jsonString = "{ \"array\": [1.44,22,33], " +  
			"\"object\": {\"key1\":\"value1\", \"key2\":256}, " +  
				"\"string\": \"The quick brown fox \\\"jumps\\\" over the lazy dog \", " +  
				"\"unicode\": \"\\u3041 Men\\u00fa sesi\\u00f3n\", " +  
				"\"int\": 65536, " +  
				"\"float\": 3.1415926, " +  
				"\"bool\": true, " +  
				"\"null\": null }";
			JsonReader reader = new JsonReader (jsonString);
			while (reader.Read()) {
				string type = reader.Value != null ?
					reader.Value.GetType().ToString() : "";
				
				//Debug.Log(reader.Token + "           " + reader.Value + "           " + type);
			}
			//return (string)reader.Value;
			*/

			return MiniJSON.Json.Deserialize (jsonString) as Dictionary<string, object>;
		}
		public static Dictionary<string, string> DeserializeAsDictionary (string jsonString)
		{
			if (!string.IsNullOrEmpty (jsonString)) {
				Dictionary<string, object> response = MiniJSON.Json.Deserialize (jsonString) as Dictionary<string, object>;
				Dictionary<string, string> result = new Dictionary<string, string> ();
				foreach (KeyValuePair<string, object> data in response) {
					if (data.Value != null)
						result.Add (data.Key, data.Value.ToString());
					else
						result.Add (data.Key, null);
				}
				return result;
			} else
				return null;
		}
		public static List<object> DeserializeAsList (string jsonString)
		{
			return MiniJSON.Json.Deserialize (jsonString) as List<object>;
		}

		public static Dictionary<string, string> DeserializeAndKeyDecrypt (string jsonString)
		{
			//JavaScriptSerializer serializer = new JavaScriptSerializer();
			
			//DataContractJsonSerializer dcjs = new DataContractJsonSerializer(List<object>);
			
			/*
			string jsonString = "{ \"array\": [1.44,22,33], " +  
			"\"object\": {\"key1\":\"value1\", \"key2\":256}, " +  
				"\"string\": \"The quick brown fox \\\"jumps\\\" over the lazy dog \", " +  
				"\"unicode\": \"\\u3041 Men\\u00fa sesi\\u00f3n\", " +  
				"\"int\": 65536, " +  
				"\"float\": 3.1415926, " +  
				"\"bool\": true, " +  
				"\"null\": null }";
			JsonReader reader = new JsonReader (jsonString);
			while (reader.Read()) {
				string type = reader.Value != null ?
					reader.Value.GetType().ToString() : "";
				
				//Debug.Log(reader.Token + "           " + reader.Value + "           " + type);
			}
			//return (string)reader.Value;
			*/
			if (!string.IsNullOrEmpty (jsonString)) {
				Dictionary<string, object> response = MiniJSON.Json.Deserialize (jsonString) as Dictionary<string, object>;
				////Debug.Log ("response: " + response.Keys.ToString());
				Dictionary<string, string> keyDecryptedResponse = new Dictionary<string, string> (); 
				foreach (KeyValuePair<string, object> data in response) {
					string index = Sec.decrypt (data.Key.ToString ());
					if (data.Value != null)
						keyDecryptedResponse [index] = data.Value.ToString ();
					else
						keyDecryptedResponse [index] = null;
				}

				return keyDecryptedResponse;
			} else
				return null;
		}

		public static Dictionary<string, object> DeserializeAsObjectAndKeyDecrypt (string jsonString)
		{
			if (!string.IsNullOrEmpty (jsonString)) {
				Dictionary<string, object> response = MiniJSON.Json.Deserialize (jsonString) as Dictionary<string, object>;
				////Debug.Log ("response: " + response.Keys.ToString());
				Dictionary<string, object> keyDecryptedResponse = new Dictionary<string, object> (); 
				foreach (KeyValuePair<string, object> data in response) {
					string index = Sec.decrypt (data.Key.ToString ());
					keyDecryptedResponse [index] = data.Value;
				}
				return keyDecryptedResponse;
			} else
				return null;
		}

		public static Dictionary<string, string> DeserializeAndDecrypt (string jsonString)
		{
			if (!string.IsNullOrEmpty (jsonString)) {
				Dictionary<string, object> response = MiniJSON.Json.Deserialize (jsonString) as Dictionary<string, object>;
				////Debug.Log ("response: " + response.Keys.ToString());
				Dictionary<string, string> decryptedResponse = new Dictionary<string, string> (); 
				foreach (KeyValuePair<string, object> data in response) {
					string index = Sec.decrypt (data.Key.ToString ());
					decryptedResponse [index] = Sec.decrypt(data.Value.ToString ());
				}
				
				return decryptedResponse;
			} else
				return null;
		}


		public static string[] DeserializeAsArray (string jsonString)
		{
			if (!string.IsNullOrEmpty (jsonString)) {
				//return MiniJSON.Json.Deserialize (jsonString) as List<object>;
				jsonString = jsonString.Replace ("[", "");
				jsonString = jsonString.Replace ("]", "");
				//jsonString = jsonString.Replace(" ", "");
				//return jsonString.Split(',');
				return jsonString.Split (new string[] {","}, System.StringSplitOptions.RemoveEmptyEntries);
			} else 
				return null;
		}
		public static int[] DeserializeAsIntArray (string jsonString)
		{
			string[] jsonArray = DeserializeAsArray (jsonString);
			if (jsonArray != null) {
				return System.Array.ConvertAll(jsonArray, s => int.Parse(s));
			} else 
				return null;
		}
		public static List<Vector2> DeserializeAsVector2List (string jsonString)
		{
			/*List<object> objectList = DeserializeAsList (jsonString);
			if (objectList != null) {
				List<Vector2> v2List = new List<Vector2>();
				foreach (object o in objectList) {
					string oString = (string)o;
					Vector2 v2 = new Vector2();
					oString = oString.Replace("(", "");
					oString = oString.Replace(")", "");
					string[] xy = oString.Split (new string[] {","}, System.StringSplitOptions.RemoveEmptyEntries);
					float.TryParse(xy[0], out v2.x);
					float.TryParse(xy[1], out v2.y);
					v2List.Add(v2);
				}
				return v2List;
			} else 
				return null;*/
			string[] v2ListStringArray = jsonString.Split (new string[] {","}, System.StringSplitOptions.RemoveEmptyEntries);
			if (v2ListStringArray.Length > 0) {
				List<Vector2> v2List = new List<Vector2>();
				foreach (string v2String in v2ListStringArray) {
					Vector2 v2 = new Vector2();
					////Debug.Log("v2String" + v2String);
					string[] xy = v2String.Split (new string[] {";"}, System.StringSplitOptions.RemoveEmptyEntries);
					//if (xy[0].Substring(1,1) != ".")  xy[0] = "0." + xy[0];
					//if (xy[1].Substring(1,1) != ".")  xy[1] = "0." + xy[1];
					float.TryParse(xy[0], out v2.x);
					float.TryParse(xy[1], out v2.y);
					v2List.Add(v2);
				}
				return v2List;
			} else 
				return null;
		}
		public static List<double> DeserializeAsDoubleList (string jsonString)
		{
			List<object> objectList = DeserializeAsList (jsonString);
			if (objectList != null) {
				return objectList.ConvertAll(new System.Converter<object, double>(objectToDouble));
			} else 
				return null;
		}
		public static double objectToDouble (object obj)
		{
			return System.Convert.ToDouble (obj);//(double)obj;
		}

		public static string[] DecryptAndDeserializeAsArray (string jsonString)
		{
			string decryptedJsonString = Sec.decrypt (jsonString);
			return JsonHandler.DeserializeAsArray (decryptedJsonString);
		}


		public static Dictionary<string,object> DecryptAndDeserialize (string jsonString)
		{
			string decryptedJsonString = Sec.decrypt (jsonString);
			return JsonHandler.Deserialize (decryptedJsonString);
		}


		public static string Serialize (object DictionaryOrList)
		{
			return MiniJSON.Json.Serialize (DictionaryOrList);
		}

		public static string Serialize (string[] stringArray)
		{
			//return MiniJSON.Json.Deserialize (jsonString) as List<object>;
			//jsonString = jsonString.Replace("[", "");
			//jsonString = jsonString.Replace("]", "");
			//jsonString = jsonString.Replace(" ", "");
			//return jsonString.Split(',');
			//return jsonString.Split (new string[] {","}, System.StringSplitOptions.RemoveEmptyEntries);
			return "[" + (string.Join (",", stringArray)) + "]";
		}

		public static string Serialize (int[] intArray)
		{
			return Serialize(System.Array.ConvertAll(intArray, i => i.ToString()));
		}

		public static string Serialize (List<Vector2> v2List)
		{
			//string jsonResponse = string.Empty;
			//foreach (Vector2 v in v2List) {

			//}
			//return jsonResponse;//Serialize(System.Array.ConvertAll(intArray, i => i.ToString()));

			//return Serialize ((object)v2List);

			string v2ListString = string.Empty;
			bool comma = false;
			foreach (Vector2 v2 in v2List) {
				string x = v2.x.ToString();
				string y = v2.y.ToString();
				//if (x.Substring(0,2) == "0.")  x = x.Remove(0,2);
				//if (y.Substring(0,2) == "0.")  y = y.Remove(0,2);
				if (!comma) {
					//v2ListString = v2ListString + "\"(" + v2.x.ToString() + "," + v2.y.ToString() + ")\"";
					v2ListString = v2ListString + x + ";" + y;
					comma = true;
				} else {
					//v2ListString = v2ListString + ",\"(" + v2.x.ToString() + "," + v2.y.ToString() + ")\"";
					v2ListString = v2ListString + "," + x + ";" + y;
				}
			}
			return v2ListString;
		}

		public static string Serialize (List<double> doubleList)
		{
			//string jsonResponse = string.Empty;
			//foreach (double d in doubleList) {
				
			//}
			//return jsonResponse;//return Serialize(System.Array.ConvertAll(intArray, i => i.ToString()));
			return Serialize ((object)doubleList);
		}
	}
}