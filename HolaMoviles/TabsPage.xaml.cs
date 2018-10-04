using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HolaMoviles
{
	public partial class TabsPage
	{
		public TabsPage()
		{
			InitializeComponent();

			//Children.Add(new MainPage() { Title = "Tab 2" });
			//Children.Add(new MainPage() { Title = "Tab 3" });

			BotonMarcado.Command = new Command(() => {
				var marcador = DependencyService.Get<IMarcadorTelefonico>();

				marcador?.Llamar(Telefono.Text);
			});

			ControlCamara.Command = new Command(() => {
				Navigation.PushAsync(new CamaraPage());
			});
		}
	}
}
