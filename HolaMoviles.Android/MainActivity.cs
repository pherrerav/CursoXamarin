using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HolaMoviles.Droid.Servicios;
using Plugin.Media;

namespace HolaMoviles.Droid
{
	[Activity(Label = "HolaMoviles", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			//Xamarin.Forms.MessageCenter

			// IoC = Inversion of Control => Dependency Injection
			Xamarin.Forms.DependencyService.Register<IMarcadorTelefonico, MarcadorAndroid>();

			//CrossMedia.Current.Initialize();

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
		{
			Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}

