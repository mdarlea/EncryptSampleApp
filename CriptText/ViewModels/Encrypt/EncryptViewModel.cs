using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.Services;
using CriptText.ViewModels.CreateFile;
using System;

namespace CriptText.ViewModels.Encrypt
{
	public class EncryptViewModel : ObservableRecipient
	{
		private readonly IFileService fileService;
		private readonly IAesEncryptTextService aesEncryptTextService;

		public EncryptViewModel(IFileService fileService, IAesEncryptTextService aesEncryptTextService) 
		{
			this.fileService = fileService;
			this.aesEncryptTextService = aesEncryptTextService;
		}

		private string? encryptedName = string.Empty;
		public string? EncryptedName
		{
			get => encryptedName;
			private set => SetProperty(ref encryptedName, value);
		}

		protected override void OnActivated() 
		{
			Messenger.Register<EncryptViewModel, FileCreatedMessage>(this, (r, m) =>
			{
				if (string.IsNullOrWhiteSpace(m.Value))
				{
					throw new InvalidOperationException("File could not be created");
				}

				var text = fileService.GetFileContent(m.Value);

				var encryptedValue = aesEncryptTextService.EncryptText(text);

				fileService.AddNewlineToFile("timp.txt", $"Name {text} was encrypted at {DateTime.Now }");

				EncryptedName = encryptedValue.EncryptedText;

				Messenger.Send(new TextEncryptedMessage(encryptedValue));
			});
		}

		protected override void OnDeactivated()
		{
			Messenger.UnregisterAll(this);
		}
	}
}
