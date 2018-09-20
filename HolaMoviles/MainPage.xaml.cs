using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;

using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HolaMoviles.Modelos;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HolaMoviles
{
	public partial class MainPage
	{
		public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object> { 1, "2", true, false };
		public Command AgregarComando { get; set; }
		public Command AbrirComando { get; set; }

		public MainPage()
		{
			AgregarComando = new Command(async () => await CargarItems());
			AbrirComando = new Command(async() => await Navigation.PushAsync(new TabsPage()));

			InitializeComponent();

			ButtonAgregar.Clicked += ButtonAgregar_Click;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			await CargarItems();
		}

		private async void ButtonAgregar_Click (object sender, EventArgs arg)
		{
			await CargarItems();
		}

		private async Task CargarItems()
		{
			if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
			{
				await DisplayAlert("Advertencia", "No hay internet", "Cerrar");
				return;
			}
			IsBusy = true;

			//await Task.Delay(2500);

			//Items.Add($"Elemento #{Items.Count}");

			Items.Clear();

			var productos = await CargarProductos();

			foreach (var item in productos)
			{
				Items.Add(item);
			}

			IsBusy = false;

			//await DisplayAlert("Titulo", "Hola!", "Cerrar");
		}

		private async Task<Producto[]> CargarProductos()
		{
			try
			{
				var cliente = new HttpClient();

				cliente.BaseAddress = new Uri(App.WebServiceUrl);
				var json = await cliente.GetStringAsync("api/products");

				Console.WriteLine(json);

				var resultado = JsonConvert.DeserializeObject<Producto[]>(json);

				return resultado;

			}
			catch (Exception ex)
			{
				// Log 
				return new Producto[0];
			}
		}
	}
}
