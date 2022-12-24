using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CriptText.ViewModels.Messages
{
	public class CreateFileMessage : ValueChangedMessage<string>
	{
		public CreateFileMessage(string value) : base(value)
		{
		}
	}
}
