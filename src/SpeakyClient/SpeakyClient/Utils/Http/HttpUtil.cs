using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using SpeakyClient.Utils.Html;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;

namespace SpeakyClient.Utils.Http
{
    public static class HttpUtil
    {
        private static CookieContainer _container = new CookieContainer();
        public static string LocationUrl { get; set; }

        public static async Task<string> GetAsync(string url, string referer = null)
		{
            var client = CreateClient(5000);

			client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:54.0) Gecko/20100101 Firefox/54.0");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

            if (!string.IsNullOrEmpty(referer))
                client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", referer);
            
			var response = await client.GetAsync(url);

			if (!VaildateResponse(response))
				throw new Exception("Status code isn't success, is http request wrong?");

			var responseBody = await response.Content.ReadAsStringAsync();

            LocationUrl = response.RequestMessage.RequestUri.ToString();

			return responseBody;
		}

        public static async Task<string> PostAsync(string url, HttpContent content, string referer = null)
		{
            var client = CreateClient(30000);

			client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:54.0) Gecko/20100101 Firefox/54.0");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", (await content.ReadAsStringAsync()).Length.ToString());
			if (!string.IsNullOrEmpty(referer))
				client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", referer);

            var response = await client.PostAsync(url, content);

			if (!VaildateResponse(response))
				throw new Exception("Status code isn't success, is http request wrong?");

            var responseBody = await response.Content.ReadAsStringAsync();

            LocationUrl = response.RequestMessage.RequestUri.ToString();

            return responseBody;
		}

        public static void AddCookie(string cookieName, string cookieValue, string domain)
        {
            var cookie = new Cookie(cookieName, cookieValue) { Domain = domain };
            _container.Add(cookie);
        }

		private static HttpClient CreateClient(int timeout = 3000)
		{
            
            return new HttpClient(new HttpClientHandler {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                CookieContainer = _container,
                AllowAutoRedirect = true
            })
			{
				Timeout = TimeSpan.FromMilliseconds(timeout),
			};
		}

		private static bool VaildateResponse(HttpResponseMessage response)
		{
#if DEBUG
            if (!response.IsSuccessStatusCode)
                Debug.WriteLine(response.StatusCode);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();
#endif
			return response.IsSuccessStatusCode;
		}

        public static HttpContent CreateHttpContent(HtmlForm form)
        {
            return new FormUrlEncodedContent(form.InputElements.Select(x => new KeyValuePair<string, string>(x.Name, x.Value)).ToArray());
        }

        public static string HttpDecode(this string s)
        {
            return System.Web.HttpUtility.HtmlDecode(s);
        }

		public static async Task<Gdk.Pixbuf> DownloadBitmap(string url)
		{
			var client = CreateClient(20000);

			client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:54.0) Gecko/20100101 Firefox/54.0");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

			var response = await client.GetAsync(url);

			if (!VaildateResponse(response))
				throw new Exception("Status code isn't success, is http request wrong?");

			var responseBytes = await response.Content.ReadAsByteArrayAsync();

			return new Gdk.Pixbuf(responseBytes);
		}
    }
}
