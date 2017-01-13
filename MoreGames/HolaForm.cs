using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HolaLib;

namespace HolaLib
{
	public class HolaForm// : MonoBehaviour
	{
		private Dictionary<string,string> formdata;
		private bool containsFiles;

		private WWWForm holaform;
		public WWWForm form {
			get {
				WWWForm f = new WWWForm();
				f = holaform;
				string json = JsonHandler.Serialize(formdata);
				f.AddField(Sec.encrypt("json"), Sec.encrypt(json));
				return f;
			}
		}
		public byte[] jsonBytes {
			get {
				//byte[] j = Sec.encrypt( Encoding.UTF8.GetBytes( JsonHandler.Serialize(formdata) ) );
				byte[] j = Encoding.UTF8.GetBytes( Sec.encrypt( JsonHandler.Serialize(formdata) ) );
				return j;
			}
		}
		public Dictionary<string,string> headers
		{
			get
			{
				Dictionary<string,string> dictionary = new Dictionary<string, string>();
				if (this.containsFiles)
				{
					//hashtable["Content-Type"] = "multipart/form-data; boundary=\"" + Encoding.UTF8.GetString(this.boundary) + "\"";
					dictionary["Content-Type"] = "multipart/form-data";
				}
				else
				{
					dictionary["Content-Type"] = "application/x-www-form-urlencoded";
				}
				return dictionary;
			}
		}
		//private RSA rsa;

		public HolaForm () {
			holaform = new WWWForm ();
			formdata = new Dictionary<string, string> ();
			containsFiles = false;
		}

		// Use this for initialization
		void Start ()
		{
			//form = new WWWForm ();
			//rsa = new RSA ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void AddField (string index, string data)
		{
			////Debug.Log (index + " : " + data);
			////Debug.Log (RSA.encryptString(index) + " : " + RSA.encryptString(data));
			//string encryptedIndex = RSA.encryptString (index);
			//string encryptedData = RSA.encryptString (data);
			//form.AddField (RSA.encryptStringForPhpServer (index), RSA.encryptStringForPhpServer (data));
			//form.AddField (Sec.encrypt (index), Sec.encrypt (data));
			formdata [index] = data;
			//form.AddField (encryptedIndex, encryptedData);
		}

		public void AddBinaryData (string index, byte[] data, string filename = null)
		{
			if (string.IsNullOrEmpty (filename)) {
				//form.AddBinaryData (Sec.encrypt (index), data);
				holaform.AddBinaryData (Sec.encrypt (index), data);
			} else {
				//form.AddBinaryData (Sec.encrypt (index), data, Sec.encrypt (filename));
				holaform.AddBinaryData (Sec.encrypt (index), data, Sec.encrypt (filename));
			}
			containsFiles = true;
		}
	}
}