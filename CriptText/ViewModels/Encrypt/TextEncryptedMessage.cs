using CommunityToolkit.Mvvm.Messaging.Messages;
using CriptText.Models;

namespace CriptText.ViewModels.Encrypt
{
	public class TextEncryptedMessage : ValueChangedMessage<AesEncryptModel>
	{
		public TextEncryptedMessage(AesEncryptModel value) : base(value)
		{
		}
	}
}
