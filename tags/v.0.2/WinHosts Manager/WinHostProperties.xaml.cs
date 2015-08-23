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
	/// Logica di interazione per WinHostProperties.xaml
	/// </summary>
	public partial class WinHostPropertiesWidget : UserControl
	{
		public WinHost Subject
		{
			get { return (WinHost)GetValue(SubjectProperty); }
			set { SetValue(SubjectProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Subject.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SubjectProperty = DependencyProperty.Register(
				"Subject", typeof(WinHost), typeof(WinHostPropertiesWidget), new UIPropertyMetadata(null));		

		public WinHostPropertiesWidget()
		{
			InitializeComponent();
		}
	}
}
