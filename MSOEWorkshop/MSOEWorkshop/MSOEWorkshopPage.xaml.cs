using Xamarin.Forms;
using Plugin.Media;

namespace MSOEWorkshop
{
	public partial class MSOEWorkshopPage : ContentPage
	{
		public MSOEWorkshopPage ()
		{
			InitializeComponent ();
			cameraButton.Clicked += async (sender, e) => {
				await CrossMedia.Current.Initialize ();
				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) {
					DisplayAlert ("No Camera", "No Camera Available!", "Ok");
					return;
				}

				var file = await CrossMedia.Current.TakePhotoAsync (new Plugin.Media.Abstractions.StoreCameraMediaOptions {
					Directory = "MSOE App",
					PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
					DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
					Name = string.Format ("{0}.jpg", System.DateTime.Now.ToString ("G")),
				});
				circleImage.Source = ImageSource.FromStream (() => {
					var stream = file.GetStream ();
					file.Dispose ();
					return stream;
				});
			};
		}
	}
}
