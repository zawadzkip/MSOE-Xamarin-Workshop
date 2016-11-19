
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Microsoft.ProjectOxford.Emotion.Contract;
using Plugin.Media.Abstractions;

namespace MSOEWorkshop
{
	public partial class EmotionDetailPage : ContentPage
	{
		private Emotion[] emotions;
		private MediaFile image;
		public EmotionDetailPage(Emotion[] emotions, MediaFile image)
		{
			InitializeComponent();
			this.Title = "Image Details";
			this.emotions = emotions;
			if (image != null)
			{
				this.image = image;
				circleImage.Source = ImageSource.FromStream(() =>
				{
					var stream = image.GetStream();
					return stream;
				});
			}
			this.SetEmotionLabels();



		}

		private void SetEmotionLabels()
		{
			if (emotions == null)
			{
				DisplayAlert("Error", "No Emotions Provided", "Ok");
				return;
			}
			if (emotions.Length == 1)
			{
				angryLabel.Text = string.Format("{0}", emotions[0].Scores.Anger.ToString("P"));
				contemptLabel.Text = string.Format("{0}", emotions[0].Scores.Contempt.ToString("P"));
				disgustLabel.Text = string.Format("{0}", emotions[0].Scores.Disgust.ToString("P"));
				fearLabel.Text = string.Format("{0}", emotions[0].Scores.Fear.ToString("P"));
				happinessLabel.Text = string.Format("{0}", emotions[0].Scores.Happiness.ToString("P"));
				neutralLabel.Text = string.Format("{0}", emotions[0].Scores.Neutral.ToString("P"));
				sadnessLabel.Text = string.Format("{0}", emotions[0].Scores.Sadness.ToString("P"));
				surpriseLabel.Text = string.Format("{0}", emotions[0].Scores.Surprise.ToString("P"));
			}
			else
			{
				double averageAnger = 0.0;
				double averageContempt = 0.0;
				double averageDisgust = 0.0;
				double averageFear = 0.0;
				double averageHappiness = 0.0;
				double averageNeutral = 0.0;
				double averageSadness = 0.0;
				double averageSurprise = 0.0;
				foreach (var emotion in emotions)
				{
					averageAnger += emotion.Scores.Anger;
					averageContempt += emotion.Scores.Contempt;
					averageDisgust += emotion.Scores.Disgust;
					averageFear += emotion.Scores.Fear;
					averageHappiness += emotion.Scores.Happiness;
					averageNeutral += emotion.Scores.Neutral;
					averageSadness += emotion.Scores.Sadness;
					averageSurprise += emotion.Scores.Surprise;
				}
				averageAnger /= emotions.Length;
				averageContempt /= emotions.Length;
				averageDisgust /= emotions.Length;
				averageFear /= emotions.Length;
				averageHappiness /= emotions.Length;
				averageNeutral /= emotions.Length;
				averageSadness /= emotions.Length;
				averageSurprise /= emotions.Length;
				angryLabel.Text = string.Format("{0}", averageAnger.ToString("P"));
				contemptLabel.Text = string.Format("{0}", averageContempt.ToString("P"));
				disgustLabel.Text = string.Format("{0}", averageDisgust.ToString("P"));
				fearLabel.Text = string.Format("{0}", averageFear.ToString("P"));
				happinessLabel.Text = string.Format("{0}", averageHappiness.ToString("P"));
				neutralLabel.Text = string.Format("{0}", averageNeutral.ToString("P"));
				sadnessLabel.Text = string.Format("{0}", averageSadness.ToString("P"));
				surpriseLabel.Text = string.Format("{0}", averageSurprise.ToString("P"));

			}
		}
	}
}
