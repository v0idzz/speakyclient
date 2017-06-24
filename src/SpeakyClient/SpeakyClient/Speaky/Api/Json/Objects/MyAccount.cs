﻿using System;
using System.Collections.Generic;
namespace SpeakyClient.Speaky.Api.Json.Objects
{
	public class Data
	{
		public int messagesNumber { get; set; }
		public int sentCorrectedMessagesNumber { get; set; }
		public int sentAcceptedConversationNumber { get; set; }
	}

    public class Stickers
	{
	}

    public class LearningLanguageLevel
	{
		public int id { get; set; }
		public int level { get; set; }
	}

	public class MyAccount
	{
		public string accessLevel { get; set; }
		public bool allowedNatives { get; set; }
		public bool isInLiveChat { get; set; }
		public bool allowedNonNatives { get; set; }
		public bool allowedMen { get; set; }
		public bool allowedWomen { get; set; }
		public int allowedMaxAge { get; set; }
		public int allowedMinAge { get; set; }
		public string facebookId { get; set; }
		public List<object> userGroups { get; set; }
		public int signUpOn { get; set; }
		public List<object> blockedLanguageIds { get; set; }
		public Data data { get; set; }
		public int coins { get; set; }
		public int hearts { get; set; }
		public string email { get; set; }
		public List<int> learningLanguageIds { get; set; }
		public bool notifyOnConversationRequest { get; set; }
		public bool notifyOnConversationAccepted { get; set; }
		public bool notifyOnMessage { get; set; }
		public bool notifyOnReminder { get; set; }
		public bool emailOnConversationRequest { get; set; }
		public bool emailOnConversationAccepted { get; set; }
		public bool emailOnMessage { get; set; }
		public bool emailOnReminder { get; set; }
		public Stickers stickers { get; set; }
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
		public int experience { get; set; }
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
    }
}
