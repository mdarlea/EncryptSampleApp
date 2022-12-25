using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.Services;
using CriptText.ViewModels.Messages;
using System;

namespace CriptText.ViewModels
{
    public class DecryptViewModel : ObservableRecipient
    {
        private readonly IFileService fileService;
        private readonly IAesEncryptTextService aesEncryptTextService;
		private readonly IRsaEncryptService rsaEncryptTextService;

		public DecryptViewModel(IFileService fileService, IAesEncryptTextService aesEncryptTextService, IRsaEncryptService rsaEncryptTextService)
        {
            this.fileService = fileService;
            this.aesEncryptTextService = aesEncryptTextService;
			this.rsaEncryptTextService = rsaEncryptTextService;
		}

        private string? decryptedText = string.Empty;
        public string? DecryptedText
        {
            get => decryptedText;
            private set => SetProperty(ref decryptedText, value);
        }

        protected override void OnActivated()
        {
            Messenger.Register<DecryptViewModel, AesTextEncryptedMessage>(this, (r, m) =>
            {
                var decryptedText = aesEncryptTextService.DecryptText(m.Value);

				if (!string.IsNullOrWhiteSpace(m.TimeFileName))
				{
					fileService.AddNewlineToFile(m.TimeFileName, $"Encrypted value: {m.Value.EncryptedText} was decrypted at {DateTime.Now}");
				}

                DecryptedText = decryptedText;
            });

			Messenger.Register<DecryptViewModel, RsaTextEncryptedMessage>(this, (r, m) =>
			{
				var decryptedResult = rsaEncryptTextService.DecryptText(m.Value);

				if (!string.IsNullOrEmpty(decryptedResult.Error)) 
				{
					Messenger.Send(new RsaEncryptionErrorMessage(decryptedResult.Error));

					return;
				}

				if (!string.IsNullOrWhiteSpace(m.TimeFileName))
				{
					fileService.AddNewlineToFile(m.TimeFileName, $"Text was decrypted at {DateTime.Now}");
				}

				DecryptedText = decryptedResult.Result;

				Messenger.Send(new RsaTextDecryptedMessage(decryptedResult.Result ?? string.Empty));
			});
		}

        protected override void OnDeactivated()
        {
            Messenger.UnregisterAll(this);
        }
    }
}
