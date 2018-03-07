using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WStandSim;
using SQLite;

using Xamarin.Forms;
using WStandSim.Database;

namespace WStandSim
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new WStandSim.MainPage();
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
            UserDatabaseController db = new UserDatabaseController();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
