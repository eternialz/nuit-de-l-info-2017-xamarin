using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;

public class Api
{
<<<<<<< Updated upstream
    private string RestUrl;
    private HttpClient Client;

    public Api(string Url)
    {
        Client = new HttpClient();
        Client.MaxResponseContentBufferSize = 256000;
=======
    /*private string RestUrl;

    public Api(string Url)
    {
>>>>>>> Stashed changes
        RestUrl = Url;
    }

    public async Task<object> Request(string Uri)
    {
        var RestUri = new Uri (string.Format (RestUrl + Uri, string.Empty));
        var Response = await Client.GetAsync(RestUri);

        if (Response.IsSuccessStatusCode) {
            var Content = await Response.Content.ReadAsStringAsync();
            return Content;
        } else {
<<<<<<< Updated upstream
            return Response.StatusCode;
        }
    }

    public async Task<object> Post(string Json, string Uri, bool IsNewItem)
    {
        Uri RestUri = new Uri(string.Format(RestUrl + Uri, string.Empty));

        StringContent Content = new StringContent (Json, Encoding.UTF8, "application/json");

        HttpResponseMessage Response = null;
        if (IsNewItem)
        {
            Response = await Client.PostAsync(RestUri, Content);
        }

        return Response.StatusCode;
    }
=======
            return new string('{"status": "error"}');
        }
    }*/
>>>>>>> Stashed changes
}
