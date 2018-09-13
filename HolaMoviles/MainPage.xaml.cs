using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HolaMoviles
{
	public partial class MainPage
	{
		public ObservableCollection<object> Items { get; set; } = new List<object> { 1, "2", true, false };

		public MainPage()
		{
			InitializeComponent();

			ButtonAgregar.Clicked += ButtonAgregar_Click;
		}

		private /*async*/ void ButtonAgregar_Click (object sender, EventArgs arg)
		{
			Items.Add($"Elemento #{Items.Count}");



			//await DisplayAlert("Titulo", "Hola!", "Cerrar");
		}
	}
}
