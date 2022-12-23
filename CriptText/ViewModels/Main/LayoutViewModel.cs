using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CriptText.ViewModels.CreateFile;
using CriptText.ViewModels.Encrypt;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CriptText.ViewModels.Main
{
	public class LayoutViewModel : ObservableRecipient
	{
		public LayoutViewModel() 
		{
			CreateFileCommand = new RelayCommand(CreateFile);
		}

		public ICommand CreateFileCommand { get; }

		private string? filename;
		public string? Filename
		{
			get => filename;
			set => SetProperty(ref filename, value, true);
		}

		private string? studentname;
		public string? StudentName
		{
			get => studentname;
			set => SetProperty(ref studentname, value);
		}

		private bool manuallySelectFileName;
		public bool ManuallySelectFileName
		{
			get => manuallySelectFileName;
			set => SetProperty(ref manuallySelectFileName, value);
		}

		private bool useWindowsUserName;
		public bool UseWindowsUserName
		{
			get => useWindowsUserName;
			set => SetProperty(ref useWindowsUserName, value);
		}

		protected override void OnActivated()
		{
			Messenger.Register<LayoutViewModel, StudentNameRequestMessage>(this, (r, m) => {
				if (UseWindowsUserName)
					m.Reply(null);
				else
				{
					m.Reply(r.StudentName);
				}
			});
		}

		protected override void OnDeactivated()
		{
			Messenger.UnregisterAll(this);
		}
		private void CreateFile()
		{
			if (!ManuallySelectFileName) 
			{
				var fileName = Guid.NewGuid().ToString();

				Filename = fileName;
			}
		}
	}
}
