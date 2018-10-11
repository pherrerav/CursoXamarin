using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

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
			var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
			var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

			if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
			{
				var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
				cameraStatus = results[Permission.Camera];
				storageStatus = results[Permission.Storage];
			}

			if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
			{
				await DisplayAlert("Permisos requeridos", "Es requerido el permiso de camara y almacenamiento", "Cerrar");
				return;
			}

			if (!CrossMedia.IsSupported
			   || !CrossMedia.Current.IsCameraAvailable)
			{
				TomarDeGaleria();
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

		private async void TomarDeGaleria()
		{
			if (!CrossMedia.IsSupported
			   || !CrossMedia.Current.IsPickPhotoSupported)
			{

				return;
			}

			var resultado = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions {
				CompressionQuality = 40,
				PhotoSize = PhotoSize.Medium
			});

			MostrarImagen(resultado);
		}

		private void MostrarImagen(MediaFile media)
		{
			Imagen.Source = FileImageSource.FromFile(media.Path);

			Texto.Text = media.Path;
		}
	}
}
