using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Serialization;

namespace WinHosts_Manager
{
	public class WinHost
	{
		public WinHost()
			: this("", IPAddress.None, false)
		{
		}

		public WinHost(string i_Name, IPAddress i_Address, bool i_IsEnabled)
		{
			Name = i_Name;
			Address = i_Address;
			IsEnabled = i_IsEnabled;
		}

		public string Name { get; set; }
		[XmlIgnore]
		public IPAddress Address { get; set; }
		public bool IsEnabled { get; set; }

		[XmlElement("Address")]
		public string AddressForXml
		{
			get { return Address.ToString(); }
			set
			{
				Address = string.IsNullOrEmpty(value) ? null :
					IPAddress.Parse(value);
			}
		}
	}
}
