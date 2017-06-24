using System;
namespace SpeakyClient.Speaky.Api.Json.Classes
{
	public class MessagesData
	{
		public int messagesNumber { get; set; }
		public int sentCorrectedMessagesNumber { get; set; }
		public int sentAcceptedConversationNumber { get; set; }
	}
}
