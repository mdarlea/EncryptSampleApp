using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.Services;
using CriptText.ViewModels;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.CurrentUser;
using CriptText.ViewModels.Decrypt;
using CriptText.ViewModels.Encrypt;
using CriptText.ViewModels.Main;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CriptText
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			Ioc.Default.ConfigureServices(
			   new ServiceCollection()
			   .AddTransient<MainWindowViewModel>()
			   .AddTransient<CreateFileViewModel>()
			   .AddTransient<LayoutViewModel>()
			   .AddTransient<CurrentUserViewModel>()
			   .AddTransient<EncryptViewModel>()
			   .AddTransient<DecryptViewModel>()
			   .AddTransient<IFileService, FileService>()
			   .AddTransient<IAesEncryptTextService, AesEncryptTextService>()
			   .BuildServiceProvider()
			   );
			   
		}
	}
}
