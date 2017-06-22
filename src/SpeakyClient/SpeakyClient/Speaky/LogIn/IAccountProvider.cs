using System;
using SpeakyClient.Speaky;
using System.Threading.Tasks;
namespace SpeakyClient.Speaky.LogIn
{
    public interface IAccountProvider
    {
        Task<Account> Login();
    }
}
