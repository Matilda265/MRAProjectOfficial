using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;

namespace MRAProject.Models
{
    public class ApiUrlLink
    {
        public static string GetUrl()
        {
            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            string apiUrl = configuration.AppSettings.Settings["https://www.mra.mw/sandbox/programming/challenge/webservice/"].Value;
            return apiUrl;
        }
    }
}