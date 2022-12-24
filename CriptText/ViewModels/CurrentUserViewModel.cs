using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.ViewModels.Messages;

namespace CriptText.ViewModels
{
	public class CurrentUserViewModel : ObservableRecipient
    {
        private string currentUser = string.Empty;
        public string CurrentUser
        {
            get => currentUser;
            private set => SetProperty(ref currentUser, value);
        }

        protected override void OnActivated()
        {
            Messenger.Register<CurrentUserViewModel, CurrentUserNameRequestMessage>(this, (r, m) => m.Reply(r.GetCurrentUser()));
        }

        protected override void OnDeactivated()
        {
            Messenger.UnregisterAll(this);
        }

        private string GetCurrentUser()
        {
            var result = Messenger.Send<StudentNameRequestMessage>();
            if (!string.IsNullOrWhiteSpace(result.Response))
            {
                CurrentUser = result.Response;
            }
            else
            {
                CurrentUser = Messenger.Send<WindowsUserRequestMessage>();
            }

            return CurrentUser;
        }

    }
}
