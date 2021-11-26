using MRAProject.APIs.Interfaces.Put;
using RestSharp;
using RestSharp.Authenticators;

namespace MRAProject.APIs.Classes.Put
{
    public class RestPutRequest : IRestPutRequest, IRestPutRequestWithBasicAunthentication
    {
        public IRestResponse PutRequest<T>(string baseUrl, string relativeUrl, T putObject)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(relativeUrl, Method.PUT);
            request.AddObject(putObject);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse PutRequestWithBasicAunthentication<T>(string username, string password, string baseUrl,
            string relativeUrl, T putObject)
        {
            var client = new RestClient(baseUrl) { Authenticator = new HttpBasicAuthenticator(username, password) };
            var request = new RestRequest(relativeUrl, Method.PUT);
            request.AddObject(putObject);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}