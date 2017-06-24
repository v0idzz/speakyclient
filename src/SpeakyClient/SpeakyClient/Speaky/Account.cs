using System;
using HtmlAgilityPack;
using SpeakyClient.Speaky.LogIn;
using SpeakyClient.Utils.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using SpeakyClient.Speaky.Api.Json.Objects;
using SpeakyClient.Speaky.Api.Json.Endpoints;
using Newtonsoft.Json;

namespace SpeakyClient
{
    public class Account
    {
        public string Firstname => _account.firstname;
        public string Lastname => _account.lastname;
        public LogInMethod LogInMethod { get; }

        private Gdk.Pixbuf _picture;
        private MyAccount _account;

        public Account(LogInMethod method)
        {
            LogInMethod = method;
            Task.Run(UpdateAccount).Wait();
        }

        public Account() {}

        public async Task UpdateAccount()
        {
            _account = JsonConvert.DeserializeObject<MyAccount>(await HttpUtil.GetAsync(JsonApiEndpoints.GetFullUrl(JsonApiEndpoints.MY_ACCOUNT)));
        }

        public async Task<Gdk.Pixbuf> GetProfilePictureAsync()
        {
            return await HttpUtil.DownloadBitmap(_account.profilePicture);
        }
    }
}
