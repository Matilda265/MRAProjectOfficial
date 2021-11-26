using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace MRAProject.APIs.Interfaces.Put
{
    interface IRestPutRequestWithBasicAunthentication
    {
        IRestResponse PutRequestWithBasicAunthentication<T>(string username, string password, string baseUrl, string relativeUrl, T putObject);
    }
}