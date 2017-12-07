public class Api
{
    private string RestUrl;

    public Api(string Url)
    {
        RestUrl = Url
    }

    public string Request(string Uri)
    {
        var RestUri = new Uri (string.Format (RestUrl + Uri, string.Empty));
        var Response = await client.GetAsync(uri);

        if (Response.IsSuccessStatusCode) {
            var Content = await response.Content.ReadAsStringAsync();
            return Content;
            //use JsonConvert.DeserializeObject <List<Object>> (Content);
        } else {
            return new string ('{"status": "error"}')
        }
    }
}
