using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpeakyClient.Utils.Http;

namespace SpeakyClient.Speaky.Api.Json.Classes
{
	public class User
	{
		public Stickers stickers { get; set; }
        public MessagesData data { get; set; }
		public List<int> interests { get; set; }
		public int androidVersionCode { get; set; }
		public int friendState { get; set; }
		public int gamificationLevel { get; set; }
		public int speakyLevel { get; set; }
		public string createdAt { get; set; }
		public string updatedAt { get; set; }
		public List<int> selectedLearningLanguageIds { get; set; }
		public List<int> nativeLanguageIds { get; set; }
		public string description { get; set; }
		public int gender { get; set; }
		public int status { get; set; }
		public bool isConnected { get; set; }
		public List<int> groupIds { get; set; }
		public List<LearningLanguageLevel> learningLanguageLevels { get; set; }
		public List<int> learningLanguageIds { get; set; }
		public object experience { get; set; }
		public string connectedAt { get; set; }
		public string disconnectedAt { get; set; }
		public string country { get; set; }
		public string address { get; set; }
		public int level { get; set; }
		public int id { get; set; }
		public string birthdate { get; set; }
		public string firstname { get; set; }
		public string profilePicture { get; set; }
		public string lastname { get; set; }

        public async Task<Gdk.Pixbuf> GetProfilePicture()
        {
            return await HttpUtil.DownloadBitmap(profilePicture);
        }
	}
}
