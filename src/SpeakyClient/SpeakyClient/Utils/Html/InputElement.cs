using System;
using SpeakyClient.Utils.Http;

namespace SpeakyClient.Utils.Html
{
    public class InputElement
    {
        public string Name { get; }
        public string Value { get; set; }

        public InputElement(string name, string value)
        {
            Name = name.HttpDecode();
            Value = value.HttpDecode();
        }
    }
}
