using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;

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
		[JsonIgnore]
		public IPAddress Address { get; set; }
		public bool IsEnabled { get; set; }

		[XmlElement("Address")]
		[JsonProperty("Address")]
		public string AddressForXml
		{
			get { return Address.ToString(); }
			set
			{
				Address = string.IsNullOrEmpty(value) ? null :
					IPAddress.Parse(value);
			}
		}

		public Dictionary<string, string> AddressesByEnvironment { get; set; } = new Dictionary<string, string>();

		public IPAddress GetAddressByEnvironment(string i_environmentName)
		{
			if (i_environmentName == "")
			{
				return Address;
			}
			string addressString = AddressesByEnvironment.ContainsKey(i_environmentName) ? AddressesByEnvironment[i_environmentName] : null;
			if (addressString == null)
			{
				return Address;
			}
			IPAddress address;
			if (!IPAddress.TryParse(addressString, out address))
			{
				return Address;
			}
			return address;
		}
	}
}
