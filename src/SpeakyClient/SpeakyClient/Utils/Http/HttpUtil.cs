using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
namespace SpeakyClient.Utils.Http
{
    public static class HttpUtil
    {
        public static async Task<string> GetAsync(string url)
		{
			var client = CreateClient();
			client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:54.0) Gecko/20100101 Firefox/54.0");

			var response = await client.GetAsync(url);

			if (!VaildateResponse(response))
				throw new Exception("Status code isn't success, is http request wrong?");

			var responseBody = await response.Content.ReadAsStringAsync();

			return responseBody;
		}

        public static async Task<string> PostAsync(string url, HttpContent content)
		{
			var client = CreateClient();
			client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:54.0) Gecko/20100101 Firefox/54.0");

			var response = await client.PostAsync(url, content);

			if (!VaildateResponse(response))
				throw new Exception("Status code isn't success, is http request wrong?");

			var responseBody = await response.Content.ReadAsStringAsync();

			return responseBody;
		}

		private static HttpClient CreateClient(int timeout = 3000)
		{
			return new HttpClient()
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
    }
}
