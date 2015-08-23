using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WinHosts_Manager
{
	public class Data
	{
		private ObservableCollection<WinHost> m_listHosts = new ObservableCollection<WinHost>();
		public ObservableCollection<WinHost> Hosts
		{
			get { return m_listHosts; }
			set { m_listHosts = value; }
		}
	}
}
