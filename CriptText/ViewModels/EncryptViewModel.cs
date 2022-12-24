using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.Services;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.Messages;
using System;

namespace CriptText.ViewModels
{
	public class EncryptViewModel : ObservableRecipient
    {
        private readonly IFileService fileService;
        private readonly IAesEncryptTextService aesEncryptTextService;
		private readonly IRsaEncryptService rsaEncryptTextService;

		public EncryptViewModel(IFileService fileService, IAesEncryptTextService aesEncryptTextService, IRsaEncryptService rsaEncryptTextService)
        {
            this.fileService = fileService;
            this.aesEncryptTextService = aesEncryptTextService;
			this.rsaEncryptTextService = rsaEncryptTextService;
		}

        private string? encryptedText = string.Empty;
        public string? EncryptedText
        {
            get => encryptedText;
            private set => SetProperty(ref encryptedText, value);
        }

        protected override void OnActivated()
        {
            Messenger.Register<EncryptViewModel, AesEncryptTextMessage>(this, (r, m) =>
            {
				AesEncryptMessage(m.Value, m.TimeFileName);
            });

			Messenger.Register<EncryptViewModel, RsaEncryptTextMessage>(this, (r, m) =>
			{
				RsaEncryptMessage(m.Value, m.TimeFileName, m.IsUserFile);
			});
		}

        protected override void OnDeactivated()
        {
            Messenger.UnregisterAll(this);
        }

		private void AesEncryptMessage(string? fileName, string? timeFileName) 
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new InvalidOperationException("File could not be created");
			}

			var text = fileService.GetUserFileContent(fileName);

			var encryptedValue = aesEncryptTextService.EncryptText(text);

			if (!string.IsNullOrWhiteSpace(timeFileName))
			{
				fileService.AddNewlineToFile(timeFileName, $"Name {text} was encrypted at {DateTime.Now}");
			}

			EncryptedText = encryptedValue.EncryptedText;

			Messenger.Send(new AesTextEncryptedMessage(encryptedValue, timeFileName));
		}

		private void RsaEncryptMessage(string? fileName, string? timeFileName, bool isUserFile)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new InvalidOperationException("File could not be created");
			}

			var text = isUserFile ? fileService.GetUserFileContent(fileName) : fileService.GetFileContent(fileName);

			var encryptedValue = rsaEncryptTextService.EncryptText(text);

			if (!string.IsNullOrWhiteSpace(timeFileName))
			{
				fileService.AddNewlineToFile(timeFileName, $"Text was encrypted at { DateTime.Now }");
			}

			EncryptedText = encryptedValue.EncryptedText;

			Messenger.Send(new RsaTextEncryptedMessage(encryptedValue!, timeFileName));
		}
	}
}
