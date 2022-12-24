using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CriptText.Services;
using CriptText.ViewModels.Messages;

namespace CriptText.ViewModels.CreateFile
{
	public class CreateFileViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<string?>>
	{
		private readonly IFileService fileService;

		public CreateFileViewModel(IFileService fileService) 
		{
			this.fileService = fileService;
		}

		private string? fileName = string.Empty;
		public string? FileName
		{
			get => fileName;
			private set => SetProperty(ref fileName, value);
		}

		public void Receive(PropertyChangedMessage<string?> message)
		{
			if (message.Sender.GetType() == typeof(Exercise1ViewModel) && message.PropertyName == nameof(Exercise1ViewModel.Filename))
			{
				var response = Messenger.Send<TextToSaveInFileRequestMessage>();
				var text = response.Response;

				CreateFile(message.NewValue ?? string.Empty, text, FileContentType.Text);
			}
		}

		protected override void OnActivated()
		{
			base.OnActivated();

			Messenger.Register<CreateFileViewModel, CreateFileMessage>(this, (r, m) => 
			{
				CreateFile(m.Value, m.FileContent, m.FileContentType);
			});
		}

		protected override void OnDeactivated()
		{
			Messenger.UnregisterAll(this);
		}

		private void CreateFile(string fileName, string fileContent, FileContentType fileContentType)
		{
			try
			{
				var filePath = fileService.CreateFile(fileName, fileContent);

				FileName = fileName;

				Messenger.Send(new FileCreatedMessage(new FileInfo
				{
					FileName = fileName,
					FilePath = filePath
				}, fileContentType));
			}
			catch
			{
				Messenger.Send(new FileCreatedMessage(new FileInfo
				{
					FileName = null,
					FilePath = null
				}, fileContentType));
			}
		}
	}
}
