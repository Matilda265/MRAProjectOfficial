using MRAProject.APIs.RestModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAProject.APIs.Interfaces.Get
{
    interface IRestGetRequestWithBasicAunthentication
    {
        IRestResponse GetRequestWithBasicAunthentication(string username, string password, string baseUrl, string relativeUrl);
        IRestResponse GetRequestWithBasicAunthentication<T>(string username, string password, string baseUrl, string relativeUrl, T postObject);
        IRestResponse GetRequestWithBasicAunthentication(
            string username, 
            string password, 
            string baseUrl, string relativeUrl,
            List<RestParameter> parameters);
    }
}