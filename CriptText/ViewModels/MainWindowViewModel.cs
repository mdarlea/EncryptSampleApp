using CommunityToolkit.Mvvm.ComponentModel;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.CurrentUser;
using CriptText.ViewModels.Decrypt;
using CriptText.ViewModels.Encrypt;
using CriptText.ViewModels.Main;

namespace CriptText.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
		public MainWindowViewModel(
            LayoutViewModel layoutViewModel, 
            CurrentUserViewModel currentUserViewModel, 
            CreateFileViewModel createFileViewModel, 
            EncryptViewModel encryptViewModel,
			DecryptViewModel decryptViewModel)
        {
            LayoutViewModel = layoutViewModel;
            CurrentUserViewModel = currentUserViewModel;
            CreateFileViewModel = createFileViewModel;
			EncryptViewModel = encryptViewModel;
			DecryptViewModel = decryptViewModel;
		}

        public LayoutViewModel LayoutViewModel { get; }
        public CurrentUserViewModel CurrentUserViewModel { get; }
        public CreateFileViewModel CreateFileViewModel { get; }
		public EncryptViewModel EncryptViewModel { get; }
		public DecryptViewModel DecryptViewModel { get; }
	}
}
