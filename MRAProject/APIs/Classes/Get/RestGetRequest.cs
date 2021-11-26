using MRAProject.APIs.Interfaces.Get;
using MRAProject.APIs.RestModels;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAProject.APIs.Classes.Get
{
    public class RestGetRequest : IRestGetRequest, IRestGetRequestWithBasicAunthentication
    {
        public IRestResponse GetRequest(string baseUrl, string relativeUrl)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(relativeUrl, Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetRequest<T>(string baseUrl, string relativeUrl, T parameterObject)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(relativeUrl, Method.GET);
            request.AddObject(parameterObject);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetRequest(string baseUrl, string relativeUrl, List<RestParameter> parameters)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(relativeUrl, Method.GET);
            foreach (var eachParameter in parameters)
            {
                request.AddParameter(eachParameter.name, eachParameter.value);
            }
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetRequestWithBasicAunthentication(string username, string password, string baseUrl, string relativeUrl)
        {
            var client = new RestClient(baseUrl) { Authenticator = new HttpBasicAuthenticator(username, password) };
            var request = new RestRequest(relativeUrl, Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetRequestWithBasicAunthentication<T>(string username, string password, string baseUrl,
            string relativeUrl, T postObject)
        {
            var client = new RestClient(baseUrl) { Authenticator = new HttpBasicAuthenticator(username, password) };
            var request = new RestRequest(relativeUrl, Method.GET);
            request.AddObject(postObject);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetRequestWithBasicAunthentication(string username, string password, string baseUrl, string relativeUrl,
            List<RestParameter> parameters)
        {
            var client = new RestClient(baseUrl) { Authenticator = new HttpBasicAuthenticator(username, password) };
            var request = new RestRequest(relativeUrl, Method.GET);
            foreach (var eachParameter in parameters)
            {
                request.AddParameter(eachParameter.name, eachParameter.value);
            }
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}