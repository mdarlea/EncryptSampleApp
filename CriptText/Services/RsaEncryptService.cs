using CriptText.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CriptText.Services
{
	public class RsaEncryptService : IRsaEncryptService, IDisposable
	{
		private readonly RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
		private readonly UnicodeEncoding byteConverter = new UnicodeEncoding();

		public ActionResult<RsaEncryptModel> EncryptText(string text)
		{
			var plainText = byteConverter.GetBytes(text);

			var result = new RsaEncryptModel();
			
			try
			{
				var encryptedData = RSAEncrypt(plainText, RSA.ExportParameters(false), false);

				result.EncryptedBytes = encryptedData;
				result.EncryptedText = byteConverter.GetString(encryptedData);

				return new ActionResult<RsaEncryptModel>(result);
			}
			catch (CryptographicException e)
			{
				return new ActionResult<RsaEncryptModel>(result)
				{
					Error = e.Message
				};
			}
		}

		public ActionResult<string?> DecryptText(RsaEncryptModel encryptedData)
		{
			if (encryptedData.EncryptedBytes== null) return null;

			try
			{
				var decryptedText = RSADecrypt(encryptedData.EncryptedBytes, RSA.ExportParameters(true), false);

				return new ActionResult<string?>(byteConverter.GetString(decryptedText));
			}
			catch (CryptographicException e)
			{
				return new ActionResult<string?>(null)
				{
					Error = e.Message
				};
			}
		}
		private static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
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

		private static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
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

		public void Dispose()
		{
			RSA.Dispose();
		}
	}
}
