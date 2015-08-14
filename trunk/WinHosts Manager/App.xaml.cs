using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections.ObjectModel;

namespace WinHosts_Manager
{
	/// <summary>
	/// Logica di interazione per App.xaml
	/// </summary>
	public partial class App : Application
	{
		private Data m_Data = new Data();
		public Data Data
		{
			//get { return (Data)(Application.Current.Resources["Data"]); }
			get { return m_Data; }
			set { m_Data = value; }
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			ObservableCollection<WinHost> dataHosts = null;
			XmlReader oReader = null;
			try
			{
				oReader = XmlReader.Create(GetConfigurationFilePath());
				XmlSerializer oSerializer = new XmlSerializer(typeof(Configuration));
				if (oSerializer.CanDeserialize(oReader))
				{
					Configuration oConfig = (Configuration)oSerializer.Deserialize(oReader);
					dataHosts = new ObservableCollection<WinHost>(oConfig.Hosts);
				}
			}
			catch (FileNotFoundException)
			{
			}
			catch (XmlException)
			{
			}
			if (oReader != null)
				oReader.Close();

			if (dataHosts == null)
			{
				string szHostsFile = GetHostsFilePath();
				string szHostsFileBackup = string.Format("{0}.{1}.bak", 
					szHostsFile, DateTime.Now.ToString("yyyyMMdd-HHmm"));
				File.Copy(szHostsFile, szHostsFileBackup);
				dataHosts = new ObservableCollection<WinHost>(ParseWinHosts());
			}
			Data.Hosts = dataHosts;
		}

		private string GetConfigurationFilePath()
		{
			return "hosts.xml";
		}

		private string GetHostsFilePath()
		{
			return System.Environment.ExpandEnvironmentVariables(
				"%SystemRoot%\\System32\\drivers\\etc\\hosts");
		}

		private IEnumerable<WinHost> ParseWinHosts()
		{
			List<WinHost> listRet = new List<WinHost>();

			string szFilePath = GetHostsFilePath();
			StreamReader oReader = new StreamReader(szFilePath);
			string szLine = "";
			while ((szLine = oReader.ReadLine()) != null)
			{
				string[] aszParts = szLine.Trim().Split("#".ToCharArray());
				if (aszParts[0].Trim().Length == 0)
					continue;
				string[] aszTokens = aszParts[0].Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				for (int i = 1; i < aszTokens.Length; ++i)
				{
					WinHost oHost = new WinHost();
					oHost.Address = IPAddress.Parse(aszTokens[0]);
					oHost.Name = aszTokens[i];
					oHost.IsEnabled = true;
					listRet.Add(oHost);
				}
			}
			oReader.Close();

			return listRet;
		}

		internal void WriteToWinHosts()
		{
			StreamWriter oWriter = new StreamWriter(GetHostsFilePath());

			oWriter.WriteLine("###############################################");
			oWriter.WriteLine("#");
			oWriter.WriteLine("# This file was generated automatically");
			oWriter.WriteLine("# on {0}", DateTime.Now);
			oWriter.WriteLine("# with");
			oWriter.WriteLine("# WinHosts Manager");
			oWriter.WriteLine("#");
			oWriter.WriteLine("###############################################");
			oWriter.WriteLine();

			foreach (WinHost oHost in Data.Hosts)
			{
				if (oHost.IsEnabled)
				{
					oWriter.WriteLine("{0} {1}", oHost.Address, oHost.Name);
				}
			}

			oWriter.Close();
		}

		private void Application_Exit(object sender, ExitEventArgs e)
		{
			SaveConfiguration();
		}

		internal void SaveConfiguration()
		{
			Configuration toSave = new Configuration();
			toSave.Hosts = Data.Hosts.ToList();

			XmlTextWriter oWriter = new XmlTextWriter(GetConfigurationFilePath(), System.Text.Encoding.UTF8);
			oWriter.Formatting = Formatting.Indented;
			oWriter.IndentChar = '\t';
			oWriter.Indentation = 1;
			XmlSerializer oSerializer = new XmlSerializer(typeof(Configuration));
			oSerializer.Serialize(oWriter, toSave);
			oWriter.Close();
		}
	}
}
