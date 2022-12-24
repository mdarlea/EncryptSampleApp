using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CriptText.ViewModels.Messages
{
	public class AesEncryptTextMessage : ValueChangedMessage<string?>
	{
		public AesEncryptTextMessage(string? value) : base(value)
		{
		}

		public string? TimeFileName { get; set; }
	}
}
