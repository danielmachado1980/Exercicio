using RestSharp;

namespace Questao2.Client
{
    public class ApiClient
    {        
        public string Execute(string baseUrl, string path)
        {
            var options = new RestClientOptions(baseUrl);
            var _client = new RestClient(options);
            var request = new RestRequest(path);
            var response = _client.Get(request);
            return response?.Content;
        }
    }
}
