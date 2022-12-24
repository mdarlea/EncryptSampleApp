using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CriptText.ViewModels.CreateFile
{
	public class RsaEncryptTextMessage : ValueChangedMessage<string?>
	{
		public RsaEncryptTextMessage(string? value, bool isUserFile) : base(value)
		{
			IsUserFile = isUserFile;
		}

		public string? TimeFileName { get; set; }
		public bool IsUserFile { get; }
	}
}
