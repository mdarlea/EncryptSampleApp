using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.ViewModels;
using System;
using System.Windows.Navigation;

namespace CriptText
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
			DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
		}

		public MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext;

		protected override void OnActivated(EventArgs e)
		{
			ViewModel.IsActive= true;
		}

		protected override void OnDeactivated(EventArgs e) 
		{
			ViewModel.IsActive= false;
		}
	}
}
