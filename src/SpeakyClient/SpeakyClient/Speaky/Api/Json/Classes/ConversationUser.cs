using System;
namespace SpeakyClient.Speaky.Api.Json.Classes
{
    public class ConversationUser
	{
		public User user { get; set; }
		public int id { get; set; }
		public bool isAccepted { get; set; }
		public bool isAdmin { get; set; }
		public bool isHidden { get; set; }
		public string lastSeen { get; set; }
	}
}
