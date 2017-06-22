using System;
using System.Diagnostics;
using SpeakyClient.Utils.Http;
using System.Threading.Tasks;
namespace SpeakyClient.Speaky.LogIn
{
    public class FacebookLogin : IAccountProvider
    {
		private string _username;
		private string _password;

        private const string LOGIN_ENDPOINT = "https://www.speaky.com/api/auth/facebook/";

        public FacebookLogin(string username, string password)
		{
			_username = username;
			_password = password;
		}

		public async Task<Account> Login()
		{
            var loginPage = await HttpUtil.GetAsync(LOGIN_ENDPOINT);
            Debug.WriteLine(loginPage);
			return new Account();
		}
    }
}
