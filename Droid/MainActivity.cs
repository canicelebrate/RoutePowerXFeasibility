using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism;
using Prism.Ioc;
using XLog.Formatters;
using XLog;
using XLog.NET.Targets;
using XLog.Android.Targets;
using System.IO;
using Acr.UserDialogs;


namespace MyCoolCompanyApp.Droid
{
	[Activity (Label = "MyCoolCompanyApp.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		protected override void OnCreate (Bundle bundle)
		{
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
            MyCoolCompanyApp.Droid.Renders.CustomReturnEntryRenderer.Init();

            InitLogging();
            InitUserDialog();

            try
            {
                LoadApplication(new App(new AndroidInitializer()));
            }
            catch(Exception e)
            {
                
            }
		}

        private void InitLogging()
        {
            var formatter = new LineFormatter();
            var logConfig = new LogConfig(formatter);
            var target = new SyncFileTarget(Path.Combine(global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "MyCoolCompanyApp.log"));
            var logcatTarget = new LogcatTarget("MyCoolCompanyApp");

            logConfig.AddTarget(LogLevel.Trace, LogLevel.Fatal, logcatTarget);
            logConfig.AddTarget(LogLevel.Trace, LogLevel.Fatal, target);
            LogManager.Init(logConfig);
        }

        private void InitUserDialog()
        {
            UserDialogs.Init(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            LogManager.Default.Flush();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            LogManager.Default.Flush();
        }
    }



    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
            container.RegisterInstance<Acr.UserDialogs.IUserDialogs>(UserDialogs.Instance);
        }
    }
}

