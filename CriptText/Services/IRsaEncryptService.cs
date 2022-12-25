using CriptText.Models;
using System;

namespace CriptText.Services
{
	public interface IRsaEncryptService : IDisposable
	{
		ActionResult<string?> DecryptText(RsaEncryptModel encryptedData);
		ActionResult<RsaEncryptModel> EncryptText(string text);
	}
}