using RestSharp;
using System;


namespace MRAProject.APIs.Interfaces.Post
{
    interface IRestPostRequestWithBasicAunthentication
    {
        IRestResponse PostRequestWithBasicAunthentication<T>(string username, string password, string baseUrl, string relativeUrl, T postObject);
    }
}