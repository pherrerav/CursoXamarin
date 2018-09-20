using System;
using Foundation;
using UIKit;

namespace HolaMoviles.iOS.Servicios
{
	public class MarcadoriOS : IMarcadorTelefonico
	{
		public void Llamar(string numero)
		{
			UIApplication.SharedApplication.OpenUrl(new NSUrl($"tel:{numero}"));
		}
	}
}
