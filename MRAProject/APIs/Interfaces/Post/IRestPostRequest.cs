using RestSharp;

namespace MRAProject.APIs.Interfaces.Post
{
    interface IRestPostRequest
    {
        IRestResponse PostRequest<T>(string baseUrl, string relativeUrl, T postObject);
    }
}