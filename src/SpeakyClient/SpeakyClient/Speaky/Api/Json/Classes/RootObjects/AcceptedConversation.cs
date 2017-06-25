using System;
using System.Collections.Generic;
namespace SpeakyClient.Speaky.Api.Json.Classes.RootObjects
{
    public class AcceptedConversation
    {
		public List<ConversationUser> conversationUsers { get; set; }
		public LastMessage lastMessage { get; set; }
		public int id { get; set; }
		public string createdAt { get; set; }
		public bool isActive { get; set; }
		public bool isInit { get; set; }
		public int lastMessageId { get; set; }
		public int type { get; set; }
		public string updatedAt { get; set; }
    }
}
