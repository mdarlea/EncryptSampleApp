using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CriptText.ViewModels.Messages
{
	public class RsaEncryptionErrorMessage : ValueChangedMessage<string>
	{
		public RsaEncryptionErrorMessage(string value) : base(value)
		{
		}
	}
}
