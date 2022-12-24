using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.Messages;

namespace CriptText.ViewModels
{
	public class MainWindowViewModel : ObservableRecipient
	{
		private string? fileName;
		public string? FileName
		{
			get => fileName;
			private set => SetProperty(ref fileName, value);
		}

		protected override void OnActivated()
		{
			Messenger.Register<MainWindowViewModel, FileNameRequestMessage>(this, (r, m) => m.Reply(r.FileName!));
			Messenger.Register<MainWindowViewModel, FileCreatedMessage>(this, (r, m) =>
			{
				FileName = m.Value.FileName;
			});
		}
	}
}
