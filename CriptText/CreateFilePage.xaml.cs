using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CriptText
{
	/// <summary>
	/// Interaction logic for CreateFilePage.xaml
	/// </summary>
	public partial class CreateFilePage : Page
    {
        public CreateFilePage()
        {
            InitializeComponent();
			DataContext = Ioc.Default.GetRequiredService<Exercise2MainViewModel>();
		}

		public Exercise2MainViewModel ViewModel => (Exercise2MainViewModel)DataContext;

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			ViewModel.LayoutViewModel.IsActive = true;
			ViewModel.CreateFileViewModel.IsActive = true;
		}

		private void Page_Unloaded(object sender, RoutedEventArgs e)
		{
			ViewModel.LayoutViewModel.IsActive = false;
			ViewModel.CreateFileViewModel.IsActive = false;
		}
	}
}
