using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CriptText.ViewModels.Messages
{
	internal class RsaTextDecryptedMessage : ValueChangedMessage<string>
	{
		public RsaTextDecryptedMessage(string value) : base(value)
		{
		}
	}
}
