using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Drawing;

namespace RedWipeReborn
{
	internal static class Program
	{
		public static RedWipeEngine Engine
		{
			get;
			private set;
		}

		public static Form NextForm
		{
			get;
			set;
		}

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Program.Engine = new RedWipeEngine();
			Program.NextForm = new LoginForm();

			do
			{
				Form form = Program.NextForm;
				Program.NextForm = null;
				try
				{
					Application.Run(form);
				}
				finally
				{
					form.Dispose();
				}
			}
			while (Program.NextForm != null);
		}
	}
}