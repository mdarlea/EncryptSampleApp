using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CriptText.Services;
using CriptText.ViewModels.CurrentUser;
using CriptText.ViewModels.Main;
using System;

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
			if (message.Sender.GetType() == typeof(LayoutViewModel) && message.PropertyName == nameof(LayoutViewModel.Filename))
			{
				CreateFile(message.NewValue ?? string.Empty);
			}
		}

		protected override void OnDeactivated()
		{
			Messenger.UnregisterAll(this);
		}

		private void CreateFile(string fileName)
		{
			var response = Messenger.Send<CurrentUsernameRequestMessage>();
			var userName = response.Response;

			try
			{
				fileService.CreateFile(fileName, userName);
				FileName = fileName;
				Messenger.Send(new FileCreatedMessage(fileName));
			}
			catch
			{
				Messenger.Send(new FileCreatedMessage(null));
			}
		}
	}
}
