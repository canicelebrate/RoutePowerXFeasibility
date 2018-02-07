using System;

using Xamarin.Forms;

namespace MyCoolCompanyApp
{
	public partial class App : Application
	{
		public App ()
		{
            InitializeComponent();
			// The root page of your application
			//MainPage = new MyPeople();
			//MainPage = new MyCoolCompanyPage();
            MainPage = new NavigationPage (new RoutePowerX.Dlg3000());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
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

