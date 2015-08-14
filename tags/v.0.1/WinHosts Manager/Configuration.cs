using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinHosts_Manager
{
	public class Configuration
	{
		public Configuration()
		{
			Hosts = new List<WinHost>();
		}

		public List<WinHost> Hosts { get; set; }
	}
}
