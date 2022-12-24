using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.ViewModels;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CriptText
{
	/// <summary>
	/// Interaction logic for Exercise2Page.xaml
	/// </summary>
	public partial class Exercise2Page : Page
    {
		public Exercise2Page()
		{
			InitializeComponent();
			DataContext = Ioc.Default.GetRequiredService<Exercise2MainViewModel>();
		}

		public Exercise2MainViewModel ViewModel => (Exercise2MainViewModel)DataContext;

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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Text files (*.txt)|*.txt";

			if (openFileDialog.ShowDialog() == true)
				ViewModel.LayoutViewModel.SelectedFilePath = openFileDialog.FileName;
		}
	}
}
