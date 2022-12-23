using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CriptText.ViewModels.CreateFile
{
	public class FileCreatedMessage : ValueChangedMessage<string?>
	{
		public FileCreatedMessage(string? value) : base(value)
		{
		}
	}
}
