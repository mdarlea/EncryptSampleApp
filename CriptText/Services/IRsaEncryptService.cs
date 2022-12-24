using CriptText.Models;

namespace CriptText.Services
{
	public interface IRsaEncryptService
	{
		string? DecryptText(RsaEncryptModel encryptedData);
		RsaEncryptModel EncryptText(string text);
	}
}