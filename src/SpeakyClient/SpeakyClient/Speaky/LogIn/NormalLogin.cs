using System;
using System.Threading.Tasks;
namespace SpeakyClient.Speaky.LogIn
{
    public class NormalLogin : IAccountProvider
    {
		private string _username;
		private string _password;

        public NormalLogin(string username, string password)
		{
			_username = username;
			_password = password;
		}

		public async Task<Account> Login()
		{
			return new Account();
		}
    }
}
