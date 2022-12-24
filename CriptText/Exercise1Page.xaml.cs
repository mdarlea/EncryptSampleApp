using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CriptText
{
	/// <summary>
	/// Interaction logic for Exercise1Page.xaml
	/// </summary>
	public partial class Exercise1Page : Page
    {
        public Exercise1Page()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<Exercise1MainViewModel>();
        }

        public Exercise1MainViewModel ViewModel => (Exercise1MainViewModel)DataContext;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LayoutViewModel.IsActive = true;
            ViewModel.CreateFileViewModel.IsActive = true;
            ViewModel.CurrentUserViewModel.IsActive = true;
			ViewModel.WindowsUserViewModel.IsActive = true;
            ViewModel.EncryptViewModel.IsActive = true;
            ViewModel.DecryptViewModel.IsActive = true;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LayoutViewModel.IsActive = false;
            ViewModel.CreateFileViewModel.IsActive = false;
            ViewModel.CurrentUserViewModel.IsActive = false;
			ViewModel.WindowsUserViewModel.IsActive = false;
			ViewModel.EncryptViewModel.IsActive = false;
            ViewModel.DecryptViewModel.IsActive = false;
        }
    }
}
