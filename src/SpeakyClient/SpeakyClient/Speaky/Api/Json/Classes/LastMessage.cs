using System;
using System.Collections.Generic;
namespace SpeakyClient.Speaky.Api.Json.Classes
{
    public class LastMessage
    {
		public int id { get; set; }
		public int conversationId { get; set; }
		public int userId { get; set; }
		public string uuid { get; set; }
		public int type { get; set; }
        public ExtraData data { get; set; }
		public List<object> files { get; set; }
		public string createdAt { get; set; }
		public string updatedAt { get; set; }
    }
}
