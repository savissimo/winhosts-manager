using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinHosts_Manager
{
	/// <summary>
	/// Logica di interazione per MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private Data AppData
		{
			get { return (App.Current as App).Data; }
		}

		private void btnWriteToHosts_Click(object sender, RoutedEventArgs e)
		{
			(App.Current as App).WriteToWinHosts();
			(App.Current as App).SaveConfiguration();
			MessageBox.Show("Configuration written to hosts");
		}

		private void btnNewHost_Click(object sender, RoutedEventArgs e)
		{
			AppData.Hosts.Add(new WinHost());
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0)
			{
				wHostProperties.Subject = e.AddedItems[0] as WinHost;
			}
		}
	}
}
