using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.Services;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.CurrentUser;
using CriptText.ViewModels.Messages;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CriptText.ViewModels.Exercise2
{
    public class Exercise2ViewModel : ObservableRecipient
    {
		private readonly IFileService fileService;
		public Exercise2ViewModel(IFileService fileService) 
        {
            CreateFileCommand = new RelayCommand(CreateFile);
			this.fileService = fileService;
		}

        public ICommand CreateFileCommand { get; }

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

		private bool fileCreated;
		public bool FileCreated
		{
			get => fileCreated;
			private set => SetProperty(ref fileCreated, value);
		}

		protected override void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);

			if (e.PropertyName == nameof(FileName) && !string.IsNullOrWhiteSpace(FileName)) 
			{
				TextToSave = fileService.GetFileContent(FileName);
			}
		}

		protected override void OnActivated()
        {
            Messenger.Register<Exercise2ViewModel, TextToSaveInFileRequestMessage>(this, (r, m) => m.Reply(r.TextToSave!));
			Messenger.Register<Exercise2ViewModel, FileCreatedMessage>(this, (r, m) => 
			{
				FileCreated= true;
			});

			FileName = Messenger.Send<FileNameRequestMessage>();
		}

		protected override void OnDeactivated()
		{
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

            Messenger.Send(new CreateFileMessage(fileName!));
        }

    }
}
