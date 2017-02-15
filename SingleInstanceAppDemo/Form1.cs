using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SingleInstanceAppDemo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			string[] args = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
			if (args != null)
				OpenFile(args[0]);
		}

		int counter = 1;
		private void OpenFile(object bestand)
		{
			Activate();
			listBox1.Items.Add(counter++ + ") " + bestand);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case Win32.WM_COPYDATA:
					Win32.CopyDataStruct st = (Win32.CopyDataStruct)Marshal.PtrToStructure(m.LParam, typeof(Win32.CopyDataStruct));
					string bestandsnaam = Marshal.PtrToStringUni(st.lpData);
					new Thread(new ParameterizedThreadStart(OpenFile)).Start(bestandsnaam);
					break;
				default:
					// let the base class deal with it
					base.WndProc(ref m);
					break;
			}
		}

		// https://social.msdn.microsoft.com/Forums/windows/en-US/64837e34-6876-4cd3-ac8a-767c6fe2b32d/set-classname-in-windows-forms?forum=winforms
		protected override CreateParams CreateParams
		{
			get
			{
				//ClassNameMgmt.RegisterWindowClass("SIADemo");
				//CreateParams param = base.CreateParams;
				//param.ClassName = "SIADemo"; // classname i want to use
				//return param;
				return base.CreateParams;
			}
		}

		private void btnMaakBestanden_Click(object sender, EventArgs e)
		{
			string map = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Testbestanden");
			if (!Directory.Exists(map)) Directory.CreateDirectory(map);
			for (int i = 1; i < 16; i++)
			{
				FileStream fs = new FileStream(Path.Combine(map, "Testbestand " + i + ".filb"), FileMode.Create);
				StreamWriter writer = new StreamWriter(fs);
				writer.Write("Testbestand " + i);
				writer.Close();
			}
			Process.Start(map);
		}
	}
}
