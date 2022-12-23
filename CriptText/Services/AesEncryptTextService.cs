using System;
using System.IO;
using System.Security.Cryptography;
using CriptText.Models;

namespace CriptText.Services
{
	public class AesEncryptTextService : IAesEncryptTextService
	{
		public AesEncryptModel EncryptText(string text)
		{
			var result = new AesEncryptModel();

			using (Aes aesAlgorithm = Aes.Create())
			{
				//set the parameters with out keyword
				result.KeyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
				result.VectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);

				// Create encryptor object
				ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();

				byte[] encryptedData;

				//Encryption will be done in a memory stream through a CryptoStream object
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter sw = new StreamWriter(cs))
						{
							sw.Write(text);
						}
						encryptedData = ms.ToArray();
					}
				}

				result.EncryptedText = Convert.ToBase64String(encryptedData);
			}

			return result;
		}

		public string DecryptText(AesEncryptModel encryptedModel)
		{
			using (Aes aesAlgorithm = Aes.Create())
			{
				aesAlgorithm.Key = Convert.FromBase64String(encryptedModel.KeyBase64!);
				aesAlgorithm.IV = Convert.FromBase64String(encryptedModel.VectorBase64!);

				// Create decryptor object
				ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();

				byte[] cipher = Convert.FromBase64String(encryptedModel.EncryptedText);

				//Decryption will be done in a memory stream through a CryptoStream object
				using (MemoryStream ms = new MemoryStream(cipher))
				{
					using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader sr = new StreamReader(cs))
						{
							return sr.ReadToEnd();
						}
					}
				}
			}
		}
	}
}


