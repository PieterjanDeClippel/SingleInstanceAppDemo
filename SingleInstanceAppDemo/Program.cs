using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SingleInstanceAppDemo
{
	static class Program
	{
		//Mutex declareren voor single-instance applicatie
		static Mutex mutex = new Mutex(true, "{C99BA508-5AB6-4850-8F90-634F7CE0D81E}");
		
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static void Main()
		{
			if (mutex.WaitOne(TimeSpan.Zero, true))
			{
				//Eerste instantie
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
				mutex.ReleaseMutex();
			}
			else
			{
				/*new Thread(delegate ()
				{*/
					// aangeklikt bestand achterhalen
					string[] args = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
					string tekst = args == null ? "" : args[0];

					int hwnd = 0;
					while (hwnd == 0)
					{
						hwnd = Win32.FindWindow(null, "Form1");
					}
					SendArgs((IntPtr)hwnd, tekst);
				/*}).Start();*/
				Thread.Sleep(50);
			}
		}

		/// <summary>
		/// Sends string arguments to running instance of World Wind.
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static bool SendArgs(IntPtr targetHWnd, string args)
		{
			Win32.CopyDataStruct cds = new Win32.CopyDataStruct();
			try
			{
				cds.cbData = (args.Length + 1) * 2;
				cds.lpData = Win32.LocalAlloc(0x40, cds.cbData);
				Marshal.Copy(args.ToCharArray(), 0, cds.lpData, args.Length);
				cds.dwData = (IntPtr)1;
				Win32.SendMessage(targetHWnd, Win32.WM_COPYDATA, IntPtr.Zero, ref cds);
			}
			finally
			{
				cds.Dispose();
			}

			return true;
		}
	}
}