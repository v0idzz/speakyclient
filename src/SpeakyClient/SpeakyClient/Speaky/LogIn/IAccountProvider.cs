using System;
using SpeakyClient.Speaky;

namespace SpeakyClient.Speaky.LogIn
{
    public interface IAccountProvider
    {
        Account Login();
    }
}
