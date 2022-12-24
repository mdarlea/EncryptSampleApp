using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.Messages;
using System;
using System.Windows.Input;

namespace CriptText.ViewModels
{
	public class Exercise1ViewModel : StudentViewModel
	{
        public Exercise1ViewModel()
        {
            CreateFileCommand = new RelayCommand(CreateFile);
        }

        public ICommand CreateFileCommand { get; }

        private string? filename;
        public string? Filename
        {
            get => filename;
            set => SetProperty(ref filename, value, true);
        }

        private bool manuallySelectFileName;
        public bool ManuallySelectFileName
        {
            get => manuallySelectFileName;
            set => SetProperty(ref manuallySelectFileName, value);
        }

        protected override void OnActivated()
        {
			base.OnActivated();

			Messenger.Register<Exercise1ViewModel, TextToSaveInFileRequestMessage>(this, (r, m) => 
			{
				var userName = Messenger.Send<CurrentUserNameRequestMessage>();
				m.Reply(userName);
			});

			Messenger.Register<Exercise1ViewModel, FileCreatedMessage>(this, (r, m) =>
			{
				Messenger.Send(new AesEncryptTextMessage(Filename)
				{
					TimeFileName = "timp.txt"
				});
			});
		}

        protected override void OnDeactivated()
        {
			base.OnDeactivated();

            Messenger.UnregisterAll(this);
        }
        private void CreateFile()
        {
            if (!ManuallySelectFileName)
            {
                var fileName = Guid.NewGuid().ToString();

                Filename = fileName;
            }
        }
    }
}
