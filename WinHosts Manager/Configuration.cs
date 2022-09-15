using System.Collections.Generic;

namespace WinHosts_Manager
{
	public class Configuration
	{
		public Configuration()
		{
			Hosts = new List<WinHost>();
			Environments = new List<Environment>();
		}

		public List<Environment> Environments { get; set; }
		public List<WinHost> Hosts { get; set; }
	}
}
