using UnityEngine;
using System.Collections;
using System.Text;
using System.Security.Cryptography;

public class Rijndael {// : MonoBehaviour {

	static readonly string keyString = "holalopilmpstechjklmxqrstuv16yo3laefgheyno";

	public static void genKey () {
		RijndaelManaged cipher = new RijndaelManaged ();
		cipher.KeySize = 256;
		cipher.BlockSize = 256;
		cipher.GenerateKey ();
		cipher.GenerateIV ();
		//Debug.Log ("Key: " + cipher.Key.ToString ());
		//Debug.Log ("IV: " + cipher.IV.ToString ());
		//Debug.Log ("Key (Base64String): " + System.Convert.ToBase64String(cipher.Key));
		//Debug.Log ("IV (Base64String): " + System.Convert.ToBase64String(cipher.IV));
		//Debug.Log ("Key (UTF8String): " + Encoding.UTF8.GetString(cipher.Key));
		//Debug.Log ("IV (UTF8String): " + Encoding.UTF8.GetString(cipher.IV));
	}

	public static RijndaelManaged GetRijndaelManaged(string secretKey)
	{
		var keyBytes = new byte[32];
		//var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
		var secretKeyBytes = Encoding.ASCII.GetBytes(secretKey);
		System.Array.Copy(secretKeyBytes, keyBytes, System.Math.Min(keyBytes.Length, secretKeyBytes.Length));
		return new RijndaelManaged
		{
			Mode = CipherMode.CBC,
			Padding = PaddingMode.PKCS7,//PaddingMode.PKCS7,
			KeySize = 256,
			BlockSize = 256,
			Key = keyBytes,
			IV = keyBytes
		};
	}

	public static ICryptoTransform getEncryptor () {
		RijndaelManaged rijndaelManaged = GetRijndaelManaged (keyString);
		return rijndaelManaged.CreateEncryptor ();
	}
	public static ICryptoTransform getDecryptor () {
		RijndaelManaged rijndaelManaged = GetRijndaelManaged (keyString);
		return rijndaelManaged.CreateDecryptor ();
	}
	
	public static byte[] encrypt(byte[] plainBytes)
	{
		RijndaelManaged rijndaelManaged = GetRijndaelManaged (keyString);
		return rijndaelManaged.CreateEncryptor()
			.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
	}
	
	public static byte[] decrypt(byte[] encryptedData)
	{
		RijndaelManaged rijndaelManaged = GetRijndaelManaged (keyString);
		return rijndaelManaged.CreateDecryptor()
			.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
	}
	
	/// <summary>
	/// Encrypts plaintext using AES 128bit key and a Chain Block Cipher and returns a base64 encoded string
	/// </summary>
	/// <param name="plainText">Plain text to encrypt</param>
	/// <param name="key">Secret key</param>
	/// <returns>Base64 encoded string</returns>
	public static string encrypt(string plainText)
	{
		var plainBytes = Encoding.UTF8.GetBytes(plainText);
		//plainBytes = new byte[]{195, 165, 194, 150, 194, 138, 195, 165, 194, 135, 194, 186, 195, 169, 194, 187, 194, 142};
		//Debug.Log (System.BitConverter.ToString(plainBytes));
		//Debug.Log ("encrypt " + plainText + ": " + System.Convert.ToBase64String (encrypt (plainBytes)));
		return WWW.EscapeURL(System.Convert.ToBase64String(encrypt(plainBytes)));
	}
	
	/// <summary>
	/// Decrypts a base64 encoded string using the given key (AES 128bit key and a Chain Block Cipher)
	/// </summary>
	/// <param name="encryptedText">Base64 Encoded String</param>
	/// <param name="key">Secret Key</param>
	/// <returns>Decrypted String</returns>
	public static string decrypt(string encryptedText)
	{
		var encryptedBytes = System.Convert.FromBase64String (WWW.UnEscapeURL(encryptedText));
		return Encoding.UTF8.GetString (decrypt (encryptedBytes));
	}
}
