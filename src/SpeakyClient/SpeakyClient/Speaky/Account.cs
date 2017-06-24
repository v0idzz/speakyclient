using System;
using HtmlAgilityPack;
using SpeakyClient.Speaky.LogIn;
using SpeakyClient.Utils.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using SpeakyClient.Speaky.Api.Json.Classes.RootObjects;
using SpeakyClient.Speaky.Api.Json.Endpoints;
using Newtonsoft.Json;
using System.Collections.Generic;
using SpeakyClient.Speaky.Api.Json.Classes;

namespace SpeakyClient
{
    public class Account
    {
        public string Firstname => _account.firstname;
        public string Lastname => _account.lastname;
        public List<User> Contacts => _acceptedConversations.SelectMany(x => x.conversationUsers).Where(x => x.user.id != _account.id).Select(x => x.user).ToList();
        public LogInMethod LogInMethod { get; }

        private Gdk.Pixbuf _picture;
        private MyAccount _account;
        private List<AcceptedConversations> _acceptedConversations;

        public Account(LogInMethod method)
        {
            LogInMethod = method;
            Task.Run(UpdateAccount).Wait();
        }

        public Account() {}

        public async Task UpdateAccount()
        {
            _account = JsonConvert.DeserializeObject<MyAccount>(await HttpUtil.GetAsync(JsonApiEndpoints.GetFullUrl(JsonApiEndpoints.MY_ACCOUNT)));

            var friendsJson = await HttpUtil.GetAsync(JsonApiEndpoints.GetFullUrl(JsonApiEndpoints.ACCEPTED_CONVERSATIONS));
            _acceptedConversations = JsonConvert.DeserializeObject<List<AcceptedConversations>>(friendsJson);
        }

        public async Task<Gdk.Pixbuf> GetProfilePictureAsync()
        {
            return await HttpUtil.DownloadBitmap(_account.profilePicture);
        }
    }
}
