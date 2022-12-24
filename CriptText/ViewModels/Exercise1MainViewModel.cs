using CommunityToolkit.Mvvm.ComponentModel;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.CurrentUser;
using CriptText.ViewModels.Decrypt;
using CriptText.ViewModels.Encrypt;
using CriptText.ViewModels.Exercise1;

namespace CriptText.ViewModels
{
    public class Exercise1MainViewModel : ObservableObject
    {
        public Exercise1MainViewModel(
            Exercise1ViewModel layoutViewModel,
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

        public Exercise1ViewModel LayoutViewModel { get; }
        public CurrentUserViewModel CurrentUserViewModel { get; }
        public CreateFileViewModel CreateFileViewModel { get; }
        public EncryptViewModel EncryptViewModel { get; }
        public DecryptViewModel DecryptViewModel { get; }
    }
}
