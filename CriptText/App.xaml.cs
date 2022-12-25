using CommunityToolkit.Mvvm.DependencyInjection;
using CriptText.Services;
using CriptText.ViewModels;
using CriptText.ViewModels.CreateFile;
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
			    .AddSingleton<IRsaEncryptService, RsaEncryptService>()
			   .AddTransient<MainWindowViewModel>()
			   .AddTransient<Exercise1MainViewModel>()
			   .AddTransient<Exercise2MainViewModel>()
			   .AddTransient<CreateFileViewModel>()
			   .AddTransient<Exercise1ViewModel>()
			   .AddTransient<Exercise2ViewModel>()
			   .AddTransient<CurrentUserViewModel>()
			   .AddTransient<WindowsUserViewModel>()
			   .AddTransient<EncryptViewModel>()
			   .AddTransient<DecryptViewModel>()
			   .AddTransient<IFileService, FileService>()
			   .AddTransient<IAesEncryptTextService, AesEncryptTextService>()
			   .BuildServiceProvider()
			   );
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);

			var service = Ioc.Default.GetService<IRsaEncryptService>();
			service?.Dispose();
		}
	}
}
