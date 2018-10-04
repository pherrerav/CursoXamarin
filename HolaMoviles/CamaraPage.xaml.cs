using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;
using Plugin.Media.Abstractions;

namespace HolaMoviles
{
	public partial class CamaraPage : ContentPage
	{
		public CamaraPage()
		{
			InitializeComponent();

			BotonCamara.Command = new Command(CapturarImagen);
		}

		private async void CapturarImagen(object obj)
		{
			if (!CrossMedia.IsSupported
			   || !CrossMedia.Current.IsCameraAvailable)
			{
				return;
			}

			var resultado = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
			{
				SaveToAlbum = true,
				Directory = "Xamarin",
				Name = $"Foto{DateTime.Now.Millisecond}"
			});

			MostrarImagen(resultado);
		}

		private void MostrarImagen(MediaFile media)
		{
			Imagen.Source = FileImageSource.FromFile(media.Path); 
		}
	}
}
