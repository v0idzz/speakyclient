using System;
using System.Threading.Tasks;
namespace SpeakyClient.Speaky.LogIn
{
    public class GoogleLogin : IAccountProvider
    {
        private string _username;
        private string _password;

        public GoogleLogin(string username, string password)
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
