using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace HolaLib
{
	public class Sec {// : MonoBehaviour {

		// constructor
		public Sec () {
		}

		public static byte[] encrypt (byte[] original) {
			try {
				//string encryptedString = RSA.encryptStringForPhpServer(original);
				byte[] encrypted = Rijndael.encrypt(original);
				return encrypted;
			} catch {
				return original;
			}
		}
		
		public static byte[] decrypt (byte[] encrypted) {
			try {
				//string decryptedString = RSA.decryptStringFromPhpServer(encryptedString);
				byte[] decrypted = Rijndael.decrypt(encrypted);
				return decrypted;
			} catch {
				return encrypted;
			}
		}

		public static string encrypt (string original) {
			try {
				//string encryptedString = RSA.encryptStringForPhpServer(original);
				string encryptedString = Rijndael.encrypt(original);
				return encryptedString;
			} catch {
				return original;
			}
		}

		public static string decrypt (string encryptedString) {
			try {
				//string decryptedString = RSA.decryptStringFromPhpServer(encryptedString);
				string decryptedString = Rijndael.decrypt(encryptedString);
				return decryptedString;
			} catch {
				return encryptedString;
			}
		}

		public static ICryptoTransform getEncryptor () {
			return Rijndael.getEncryptor ();
		}
		public static ICryptoTransform getDecryptor () {
			return Rijndael.getDecryptor ();
		}

		public static byte[] GetHash(string inputString)
		{
			//HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
			/*HashAlgorithm algorithm = SHA1.Create();*/
			HashAlgorithm algorithm = SHA512.Create ();
			return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
		}
		
		public static string GetHashString(string inputString)
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash(inputString))
				sb.Append(b.ToString("X2"));
			
			return sb.ToString().ToLower();
		}
	}
}
