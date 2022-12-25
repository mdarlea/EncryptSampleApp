using CriptText.Models;

namespace CriptText.Services
{
	public interface IRsaEncryptService
	{
		ActionResult<string?> DecryptText(RsaEncryptModel encryptedData);
		ActionResult<RsaEncryptModel> EncryptText(string text);
	}
}