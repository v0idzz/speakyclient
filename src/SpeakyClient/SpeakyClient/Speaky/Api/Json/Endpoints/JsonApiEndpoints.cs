using System;
namespace SpeakyClient.Speaky.Api.Json.Endpoints
{
    public static class JsonApiEndpoints
    {
        public const string MY_ACCOUNT = "/api/account/me";

        public static string GetFullUrl(string s)
        {
            return "https://www.speaky.com" + s;
        }
    }
}
