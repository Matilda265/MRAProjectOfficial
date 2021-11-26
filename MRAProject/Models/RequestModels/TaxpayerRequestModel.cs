using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAProject.Models.RequestModels
{
    public class TaxpayerRequestModel
    {
        public int requestId { get; set; }
        public int respondedBy { get; set; }
        public int requestResponse { get; set; }
        public string description { get; set; }
    }
}