using CommunityToolkit.Mvvm.ComponentModel;
using CriptText.ViewModels.CreateFile;

namespace CriptText.ViewModels
{
    public class Exercise2MainViewModel : ObservableObject
    {
		public Exercise2MainViewModel(
			Exercise2ViewModel layoutViewModel,
			CurrentUserViewModel currentUserViewModel,
			WindowsUserViewModel windowsUserViewModel,
			CreateFileViewModel createFileViewModel,
			EncryptViewModel encryptViewModel,
			DecryptViewModel decryptViewModel)
		{
			LayoutViewModel = layoutViewModel;
			CurrentUserViewModel = currentUserViewModel;
			WindowsUserViewModel = windowsUserViewModel;
			CreateFileViewModel = createFileViewModel;
			EncryptViewModel = encryptViewModel;
			DecryptViewModel = decryptViewModel;
		}

		public Exercise2ViewModel LayoutViewModel { get; }
		public CurrentUserViewModel CurrentUserViewModel { get; }
		public WindowsUserViewModel WindowsUserViewModel { get; }
		public CreateFileViewModel CreateFileViewModel { get; }
		public EncryptViewModel EncryptViewModel { get; }
		public DecryptViewModel DecryptViewModel { get; }
	}
}
