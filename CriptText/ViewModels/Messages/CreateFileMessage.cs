using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CriptText.ViewModels.Messages
{
	public enum FileContentType { Encrypted, Decrypted, Text }

	public class CreateFileMessage : ValueChangedMessage<string>
	{
		public CreateFileMessage(string fileName, string fileContent, FileContentType fileContentType) : base(fileName)
		{
			FileContent = fileContent;
			FileContentType = fileContentType;
		}

		public string? TimeFileName { get; set; }
		public string FileContent { get; }
		public FileContentType FileContentType { get; }
	}
}
