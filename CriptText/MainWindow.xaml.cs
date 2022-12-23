using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.ViewModels;
using System;
using System.Windows;

namespace CriptText
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
		}

		public MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext;

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			ViewModel.LayoutViewModel.IsActive= true;
			ViewModel.CreateFileViewModel.IsActive= true;
			ViewModel.CurrentUserViewModel.IsActive= true;
			ViewModel.EncryptViewModel.IsActive= true;
			ViewModel.DecryptViewModel.IsActive = true;
		}

		protected override void OnDeactivated(EventArgs e)
		{
			base.OnDeactivated(e);
			ViewModel.LayoutViewModel.IsActive= false;
			ViewModel.CreateFileViewModel.IsActive = false;
			ViewModel.CurrentUserViewModel.IsActive = false;
			ViewModel.EncryptViewModel.IsActive= false;
			ViewModel.DecryptViewModel.IsActive = false;
		}

	}
}
