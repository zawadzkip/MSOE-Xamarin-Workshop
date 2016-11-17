using Xamarin.Forms;
using Plugin.Media;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.Linq;
using System.Diagnostics;
using Plugin.Media.Abstractions;

namespace MSOEWorkshop
{
	public partial class MSOEWorkshopPage : ContentPage
	{
		private Emotion currentEmotion;
		private MediaFile picture;
		public MSOEWorkshopPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			cameraButton.Clicked += async (sender, e) => {
				cameraButton.IsEnabled = false;
				await CrossMedia.Current.Initialize ();
				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) {
					DisplayAlert ("No Camera", "No Camera Available!", "Ok");
					return;
				}
				this.IsBusy = true;
				loadingIndicator.IsVisible = true;
				loadingIndicator.IsRunning = true;
				picture = await CrossMedia.Current.TakePhotoAsync (new Plugin.Media.Abstractions.StoreCameraMediaOptions {
					Directory = "MSOE App",
					PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
					DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
					Name = string.Format ("{0}.jpg", System.DateTime.Now.ToString ("G")),
				});
				circleImage.Source = ImageSource.FromStream (() => {
					var stream = picture.GetStream ();
					return stream;
				});
				var emotions = await WebServices.GetHappinessAsync (picture.GetStream ());
				this.ProcessEmotions (emotions);
				this.IsBusy = false;
				loadingIndicator.IsVisible = false;
				cameraButton.IsEnabled = true;
			};
			circleImage.GestureRecognizers.Add (new TapGestureRecognizer (CircleImageTapped));
		}

		void CircleImageTapped (View arg1, object arg2)
		{
			Navigation.PushAsync (new EmotionDetailPage (currentEmotion, picture));
		}

		private void ProcessEmotions (Emotion [] emotionArray)
		{
			if (emotionArray.Length == 0) {
				DisplayAlert ("Error", "Could not detect any faces", "Ok");
				return;
			}
			if (emotionArray.Length == 1) {
				happinessLabel.Text = string.Format ("1 Person, Happiness: {0} {1}", emotionArray.First ().Scores.Happiness.ToString ("P1"), this.GetSmiley (emotionArray.First ().Scores.Happiness));
				return;
			}
			var averageHappiness = 0.0;
			foreach (var emotion in emotionArray) {
				averageHappiness += emotion.Scores.Happiness;
			}
			happinessLabel.Text = string.Format ("{0} People, Average Happiness: {1} {2}", emotionArray.Length, averageHappiness.ToString ("P1"), this.GetSmiley (averageHappiness));
		}

		private string GetSmiley (double happiness)
		{
			if (happiness >= 0.75) {
				return "\ud83d\ude00"; //smiley with teeth
			} else if (happiness < 0.75 && happiness >= 0.5) {
				return "\ud83d\ude42"; //normal smiley
			} else if (happiness < 0.5 && happiness >= 0.25) {
				return "☹️"; // sad face
			} else {
				return "\ud83d\ude2d"; //crying face
			}
		}
	}
}
