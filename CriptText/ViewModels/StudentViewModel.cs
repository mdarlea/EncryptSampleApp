using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.ViewModels.Messages;

namespace CriptText.ViewModels
{
	public class StudentViewModel : ObservableRecipient
	{
		private string? studentname;
		public string? StudentName
		{
			get => studentname;
			set => SetProperty(ref studentname, value);
		}

		private bool useWindowsUserName;
		public bool UseWindowsUserName
		{
			get => useWindowsUserName;
			set => SetProperty(ref useWindowsUserName, value);
		}

		protected override void OnActivated()
		{
			Messenger.Register<StudentViewModel, StudentNameRequestMessage>(this, (r, m) =>
			{
				if (UseWindowsUserName)
					m.Reply(null);
				else
				{
					m.Reply(r.StudentName);
				}
			});
		}

		protected override void OnDeactivated()
		{
			Messenger.UnregisterAll(this);
		}
	}
}
