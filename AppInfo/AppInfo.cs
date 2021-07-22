using SR = System.Reflection;
using System.Reflection;

namespace AppInfo
{

	interface IAppInfo
	{
		string Title {get;}
		string Description { get; }
		string Company { get; }
		string Copyright { get; }
		string Trademark { get; }
		string Version { get; }
	}

    public class AppInfo : IAppInfo
    {

		private System.Reflection.Assembly m_AssInfo;
		private string _Cad;
		private object[] m_Text;

		public AppInfo()
		{
			_Cad = string.Empty;
			m_AssInfo = System.Reflection.Assembly.GetExecutingAssembly();
		}

		public string Company
		{
			get
			{
				m_Text = m_AssInfo.GetCustomAttributes(typeof(System.Reflection.AssemblyCompanyAttribute) , false);
				_Cad = ((AssemblyCompanyAttribute) m_Text[0]).Company;

				return _Cad;
			}
		}

		public string Copyright
		{
			get
			{
				m_Text = m_AssInfo.GetCustomAttributes(typeof(System.Reflection.AssemblyCopyrightAttribute) , false);
				_Cad = ((AssemblyCopyrightAttribute) m_Text[0]).Copyright;

				return _Cad;
			}
		}

		public string Description
		{
			get
			{
				m_Text = m_AssInfo.GetCustomAttributes(typeof(System.Reflection.AssemblyDescriptionAttribute) , false);
				_Cad = ((AssemblyDescriptionAttribute) m_Text[0]).Description;

				return _Cad;
			}
		}

		public string Title
		{
			get
			{
				m_Text = m_AssInfo.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute) , false);
				_Cad = ((AssemblyTitleAttribute) m_Text[0]).Title;

				return _Cad;
			}
		}

		public string Trademark
		{
			get
			{
				m_Text = m_AssInfo.GetCustomAttributes(typeof(System.Reflection.AssemblyTrademarkAttribute) , false);
				_Cad = ((AssemblyTrademarkAttribute) m_Text[0]).Trademark;

				return _Cad;
			}
		}

		public string Version
		{
			get
			{
				m_Text = m_AssInfo.GetCustomAttributes(typeof(System.Reflection.AssemblyVersionAttribute) , false);
				_Cad = ((AssemblyVersionAttribute) m_Text[0]).Version;

				return _Cad;
			}
		}

    }
}
