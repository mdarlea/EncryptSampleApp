using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.ViewModels.Messages;

namespace CriptText.ViewModels
{
	public class WindowsUserViewModel : ObservableRecipient
	{
		private string userName = string.Empty;
		public string UserName
		{
			get => userName;
			private set => SetProperty(ref userName, value);
		}
		protected override void OnActivated()
		{
			Messenger.Register<WindowsUserViewModel, WindowsUserRequestMessage>(this, (r, m) => m.Reply(r.GetUserName()));
		}

		private string GetUserName() 
		{
			var userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

			var index = userName.IndexOf(@"\");

			var name = userName.Substring(index + 1);

			UserName = name;

			return name;
		}
	}
}
