using System;
using Android.App;
using Android.Content;
using Android.Widget;

namespace HolaMoviles.Droid.Servicios
{
	public class MarcadorAndroid : IMarcadorTelefonico
	{
		public void Llamar(string numero)
		{
			var mensajero = new Intent();
			mensajero.SetData(Android.Net.Uri.Parse("tel:" + numero));
			Toast.MakeText(Application.Context, "Llamando...", ToastLength.Long).Show();

			Application.Context.StartActivity(mensajero);
		}
	}
}
