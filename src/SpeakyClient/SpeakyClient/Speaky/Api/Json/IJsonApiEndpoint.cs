using System;
using Newtonsoft.Json;

namespace SpeakyClient.Speaky.Api.Json
{
    public interface IJsonApiEndpoint
    {
        [JsonIgnore]
        string ApiEndpointUrl { get; }
    }
}
