using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Emotion;
namespace MSOEWorkshop
{
	public static class WebServices
	{

		public static async Task<Emotion []> GetHappinessAsync (Stream stream)
		{
			var emotionClient = new EmotionServiceClient (APIKeys.EMOTION_API);
			var emotions = await emotionClient.RecognizeAsync (stream);
			return emotions;
		}

	}
}
