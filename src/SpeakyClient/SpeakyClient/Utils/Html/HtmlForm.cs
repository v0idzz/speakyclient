using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace SpeakyClient.Utils.Html
{
    public class HtmlForm
    {
        public string Action { get; }
        public HtmlFormMethod Method { get; }
        public List<InputElement> InputElements { get; }

        public HtmlForm(string action, HtmlFormMethod method, List<InputElement> inputElements)
        {
            Action = action;
            Method = method;
            InputElements = inputElements;
        }

        public static HtmlForm CreateFromHtmlString(string id, string htmlDocument)
        {
            var document = new HtmlDocument();
            document.LoadHtml(htmlDocument);

            var form = document.GetElementbyId(id);

            var action = string.Empty;
            var method = HtmlFormMethod.Get; //get is the default html form action

            if (form.Attributes.Contains("action"))
                action = form.Attributes["action"].Value;
            if (form.Attributes.Contains("method"))
                method = (HtmlFormMethod)Enum.Parse(typeof(HtmlFormMethod), form.Attributes["method"].Value, true);

            var inputElements = new List<InputElement>();

            foreach (var node in form.Descendants("input"))
            {
                var name = string.Empty;
                var val = string.Empty;

                if (node.Attributes.Contains("name"))
                    name = node.Attributes["name"].Value;
                if (node.Attributes.Contains("value"))
                    val = node.Attributes["value"].Value;

                if (!string.IsNullOrEmpty(name))
                    inputElements.Add(new InputElement(name, val));
            }

            return new HtmlForm(action, method, inputElements);
        }
    }

    public enum HtmlFormMethod
    {
        Get,
        Post
    }
}
