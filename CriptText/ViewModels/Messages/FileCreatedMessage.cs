using CommunityToolkit.Mvvm.Messaging.Messages;
using CriptText.ViewModels.Messages;

namespace CriptText.ViewModels.CreateFile
{
	public class FileCreatedMessage : ValueChangedMessage<FileInfo>
	{
		public FileCreatedMessage(FileInfo value, FileContentType fileContentType) : base(value)
		{
			FileContentType = fileContentType;
		}

		public FileContentType FileContentType { get; }
	}

	public class FileInfo
	{
		public string? FileName { get; set; }
		public string? FilePath {get;set; }
	}
}
