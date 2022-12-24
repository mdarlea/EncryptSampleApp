using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CriptText
{
	/// <summary>
	/// Interaction logic for AllExercises.xaml
	/// </summary>
	public partial class AllExercises : Page
    {
        public AllExercises()
        {
            InitializeComponent();
        }

		private void exercise1_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("Exercise1Page.xaml", UriKind.Relative));
		}

		private void exercise2_Click(object sender, RoutedEventArgs e)
		{

		}

		private void createFile_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("CreateFilePage.xaml", UriKind.Relative));
		}
    }
}
