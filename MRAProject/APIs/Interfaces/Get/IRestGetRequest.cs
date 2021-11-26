using MRAProject.APIs.RestModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAProject.APIs.Interfaces.Get
{
    public interface IRestGetRequest
    {
        IRestResponse GetRequest(string baseUrl, string relativeUrl);
        IRestResponse GetRequest<T>(string baseUrl, string relativeUrl, T postObject);
        IRestResponse GetRequest(string baseUrl, string relativeUrl, List<RestParameter> parameters);
    }
}