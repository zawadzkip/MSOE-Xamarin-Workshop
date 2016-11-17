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
		public EmotionDetailPage (Emotion[] emotions, MediaFile image)
		{
			InitializeComponent ();
			this.Title = "Image Details";
			this.emotions = emotions;
			this.image = image;

			//TODO change label values based off of emotion values.

		}
	}
}
