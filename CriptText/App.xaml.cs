using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.Services;
using CriptText.ViewModels;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.CurrentUser;
using CriptText.ViewModels.Decrypt;
using CriptText.ViewModels.Encrypt;
using CriptText.ViewModels.Exercise1;
using CriptText.ViewModels.Exercise2;
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
			   .AddTransient<Exercise1MainViewModel>()
			   .AddTransient<Exercise2MainViewModel>()
			   .AddTransient<CreateFileViewModel>()
			   .AddTransient<Exercise1ViewModel>()
			   .AddTransient<Exercise2ViewModel>()
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
