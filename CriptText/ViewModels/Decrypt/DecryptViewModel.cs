using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.Services;
using CriptText.ViewModels.Encrypt;
using System;

namespace CriptText.ViewModels.Decrypt
{
	public class DecryptViewModel: ObservableRecipient
	{
		private readonly IFileService fileService;
		private readonly IAesEncryptTextService aesEncryptTextService;

		public DecryptViewModel(IFileService fileService, IAesEncryptTextService aesEncryptTextService)
		{
			this.fileService = fileService;
			this.aesEncryptTextService = aesEncryptTextService;
		}

		private string? decryptedName = string.Empty;
		public string? DecryptedName
		{
			get => decryptedName;
			private set => SetProperty(ref decryptedName, value);
		}

		protected override void OnActivated() 
		{
			Messenger.Register<DecryptViewModel, TextEncryptedMessage>(this, (r, m) =>
			{
				var decryptedText = aesEncryptTextService.DecryptText(m.Value);

				fileService.AddNewlineToFile("timp.txt", $"Encrypted value: {m.Value.EncryptedText} was decrypted at {DateTime.Now}");

				DecryptedName = decryptedText;
			});
		}

		protected override void OnDeactivated()
		{
			Messenger.UnregisterAll(this);
		}
	}
}
