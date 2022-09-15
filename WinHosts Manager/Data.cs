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

		public ObservableCollection<Environment> Environments { get; set; } = new ObservableCollection<Environment>();
	}
}
