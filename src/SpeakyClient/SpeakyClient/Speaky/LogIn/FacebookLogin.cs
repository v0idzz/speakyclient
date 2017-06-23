using SpeakyClient.Utils.Http;
using SpeakyClient.Utils.Html;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

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
            HttpUtil.AddCookie("noscript", "1", "facebook.com");

            var loginPage = await HttpUtil.GetAsync(LOGIN_ENDPOINT);
            var form = HtmlForm.CreateFromHtmlString("login_form", loginPage);
            form.InputElements.Add(new InputElement("login", "1"));
			form.InputElements.ForEach(x =>
			{
				if (x.Name == "email")
					x.Value = _username;
				if (x.Name == "pass")
					x.Value = _password;
			});
            var content = HttpUtil.CreateHttpContent(form);

            var speakyPage = await HttpUtil.PostAsync("https://www.facebook.com" + form.Action.HttpDecode(), content, HttpUtil.LocationUrl);
            return new Account();
        }
    }
}
