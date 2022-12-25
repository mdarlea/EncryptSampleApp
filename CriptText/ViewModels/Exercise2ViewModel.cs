 using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.Services;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.Messages;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CriptText.ViewModels
{
	public class Exercise2ViewModel : StudentViewModel
    {
		private readonly IFileService fileService;
		public Exercise2ViewModel(IFileService fileService)
        {
            CreateFileCommand = new RelayCommand(CreateFile);
            EncryptTextCommand = new RelayCommand(EncryptText);
			this.fileService = fileService;
		}

        public ICommand CreateFileCommand { get; }
        public ICommand EncryptTextCommand { get; }

        private string? fileName;
        public string? FileName
        {
            get => fileName;
            set => SetProperty(ref fileName, value);
        }

        private string? textToSave;
        public string? TextToSave
        {
            get => textToSave;
            set => SetProperty(ref textToSave, value);
        }

		private string? timeFileName;
		public string? TimeFileName
		{
			get => timeFileName;
			private set => SetProperty(ref timeFileName, value);
		}

		private string? encryptedTextFilePath;
		public string? EncryptedTextFilePath
		{
			get => encryptedTextFilePath;
			set => SetProperty(ref encryptedTextFilePath, value);
		}

		private string? decryptedTextFilePath;
		public string? DecryptedTextFilePath
		{
			get => decryptedTextFilePath;
			set => SetProperty(ref decryptedTextFilePath, value);
		}

		private string? selectedFilePath;
		public string? SelectedFilePath
		{
			get => selectedFilePath;
			set => SetProperty(ref selectedFilePath, value);
		}

		private string? filePath;
		public string? FilePath
		{
			get => filePath;
			set => SetProperty(ref filePath, value);
		}

		private bool fileCreated;
        public bool FileCreated
        {
            get => fileCreated;
            private set => SetProperty(ref fileCreated, value);
        }

		private string? rsaEncryptionError;
		public string? RsaEncryptionError
		{
			get => rsaEncryptionError;
			private set => SetProperty(ref rsaEncryptionError, value);
		}

		protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName == nameof(FileName) && !string.IsNullOrWhiteSpace(FileName))
            {
                TextToSave = fileService.GetUserFileContent(FileName);
            }

			if (e.PropertyName == nameof(SelectedFilePath) && !string.IsNullOrWhiteSpace(SelectedFilePath))
			{
				EncryptText();
			}
		}

        protected override void OnActivated()
        {
			base.OnActivated();

            Messenger.Register<Exercise2ViewModel, FileCreatedMessage>(this, (r, m) =>
            {
				switch (m.FileContentType) 
				{
					case FileContentType.Text:
						FileName = m.Value.FileName;
						FilePath = m.Value.FilePath;
						FileCreated = true;
						break;
					case FileContentType.Encrypted:
						EncryptedTextFilePath = m.Value.FilePath;
						break;
					case FileContentType.Decrypted:
						DecryptedTextFilePath = m.Value.FilePath;
						break;
				}
            });
			Messenger.Register<Exercise2ViewModel, RsaTextEncryptedMessage>(this, (r, m) => 
			{
				if (!string.IsNullOrWhiteSpace(m.Value.EncryptedText))
				{
					var result = Messenger.Send<CurrentUserNameRequestMessage>();

					var fileName = $"{result.Response.Replace(" ", string.Empty)}_crypt";

					Messenger.Send(new CreateFileMessage(fileName, m.Value.EncryptedText, FileContentType.Encrypted));
				}
			});
			Messenger.Register<Exercise2ViewModel, RsaTextDecryptedMessage>(this, (r, m) =>
			{
				if (!string.IsNullOrWhiteSpace(m.Value))
				{
					var result = Messenger.Send<CurrentUserNameRequestMessage>();

					var fileName = $"{result.Response.Replace(" ", string.Empty)}_decrypt";					

					Messenger.Send(new CreateFileMessage(fileName, m.Value, FileContentType.Decrypted));
				}
			});
			Messenger.Register<Exercise2ViewModel, RsaEncryptionErrorMessage>(this, (r, m) => RsaEncryptionError = m.Value);

			FileName = Messenger.Send<FileNameRequestMessage>();
        }

        protected override void OnDeactivated()
        {
			base.OnDeactivated();

            Messenger.UnregisterAll(this);
        }

        private void CreateFile()
        {
            var fileName = FileName;

            if (string.IsNullOrWhiteSpace(FileName))
            {
                fileName = Guid.NewGuid().ToString();

                FileName = fileName;
            }

            Messenger.Send(new CreateFileMessage(fileName!, TextToSave!, FileContentType.Text));
        }

        private void EncryptText()
        {
			EncryptedTextFilePath = null;
			DecryptedTextFilePath= null;
			RsaEncryptionError = null;

            if (string.IsNullOrWhiteSpace(SelectedFilePath))
            {
				return;
            }

			var result = Messenger.Send<CurrentUserNameRequestMessage>();
			TimeFileName = $"{result.Response.Replace(" ", string.Empty)}_timp.txt";

			Messenger.Send(new RsaEncryptTextMessage(SelectedFilePath, false)
			{
				TimeFileName = TimeFileName
			}); ;
        }

    }
}
