using CommunityToolkit.Mvvm.ComponentModel;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.Exercise2;

namespace CriptText.ViewModels
{
	public class Exercise2MainViewModel : ObservableObject
    {
        public Exercise2MainViewModel(
            Exercise2ViewModel layoutViewModel,
            CreateFileViewModel createFileViewModel
            )
        {
			LayoutViewModel = layoutViewModel;
            CreateFileViewModel = createFileViewModel;
        }

        public Exercise2ViewModel LayoutViewModel { get; }
        public CreateFileViewModel CreateFileViewModel { get; }
    }
}
