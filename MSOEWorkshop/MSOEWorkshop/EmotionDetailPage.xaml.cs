using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Microsoft.ProjectOxford.Emotion.Contract;
using Plugin.Media.Abstractions;

namespace MSOEWorkshop
{
	public partial class EmotionDetailPage : ContentPage
	{
		private Emotion emotion;
		private MediaFile image;
		public EmotionDetailPage (Emotion emotion, MediaFile image)
		{
			InitializeComponent ();
			this.Title = "Image Details";
			this.emotion = emotion;
			this.image = image;

		}
	}
}
