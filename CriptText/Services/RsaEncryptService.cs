using CriptText.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CriptText.Services
{
	public class RsaEncryptService : IRsaEncryptService, IDisposable
	{
		RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
		UnicodeEncoding ByteConverter = new UnicodeEncoding();
		public RsaEncryptModel EncryptText(string text)
		{
			var plainText = ByteConverter.GetBytes(text);

			var encryptedData = RSAEncrypt(plainText, RSA.ExportParameters(false), false);

			return (encryptedData == null) ? new RsaEncryptModel() : new RsaEncryptModel 
			{
				EncryptedBytes= encryptedData,
				EncryptedText = ByteConverter.GetString(encryptedData)
			};
		}

		public string? DecryptText(RsaEncryptModel encryptedData)
		{
			if (encryptedData.EncryptedBytes== null) return null;

			var decryptedText = RSADecrypt(encryptedData.EncryptedBytes, RSA.ExportParameters(true), false);

			return (decryptedText == null) ? null : ByteConverter.GetString(decryptedText);
		}
		private static byte[]? RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
		{
			try
			{
				byte[] encryptedData;
				//Create a new instance of RSACryptoServiceProvider.
				using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
				{

					//Import the RSA Key information. This only needs
					//toinclude the public key information.
					RSA.ImportParameters(RSAKeyInfo);

					//Encrypt the passed byte array and specify OAEP padding.  
					//OAEP padding is only available on Microsoft Windows XP or
					//later.  
					encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
				}
				return encryptedData;
			}
			//Catch and display a CryptographicException  
			//to the console.
			catch (CryptographicException e)
			{
				return null;
			}
		}

		private static byte[]? RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
		{
			try
			{
				byte[] decryptedData;
				//Create a new instance of RSACryptoServiceProvider.
				using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
				{
					//Import the RSA Key information. This needs
					//to include the private key information.
					RSA.ImportParameters(RSAKeyInfo);

					//Decrypt the passed byte array and specify OAEP padding.  
					//OAEP padding is only available on Microsoft Windows XP or
					//later.  
					decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
				}
				return decryptedData;
			}
			//Catch and display a CryptographicException  
			//to the console.
			catch (CryptographicException e)
			{
				return null;
			}
		}

		public void Dispose()
		{
			RSA.Dispose();
		}
	}
}
