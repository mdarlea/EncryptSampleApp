using CriptText.Models;

namespace CriptText.Services
{
	public interface IAesEncryptTextService
	{
		string DecryptText(AesEncryptModel encryptedModel);
		AesEncryptModel EncryptText(string text);
	}
}