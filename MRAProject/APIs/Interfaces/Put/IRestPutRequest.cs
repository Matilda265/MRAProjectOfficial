using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAProject.APIs.Interfaces.Put
{
    interface IRestPutRequest
    {
        IRestResponse PutRequest<T>(string baseUrl, string relativeUrl, T putObject);
    }
}