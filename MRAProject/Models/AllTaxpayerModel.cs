using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAProject.Models
{
    public class AllTaxpayerModel
    {
        public string TPIN { get; set; }
        public string BusinessCertificateNumber { get; set; }
        public string TradingName { get; set; }
        public string BusinessRegistrationDate { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string PhysicalLocation { get; set; }
        public string Username { get; set; }
        public string Deleted { get; set; }
        public string id { get; set; }
    }
    //these are for adding
    //public class TaxpayerModel
    //{
    //    public string TPIN { get; set; }
    //    public string BusinessCertificateNumber { get; set; }
    //    public string TradingName { get; set; }
    //    public string BusinessRegistrationDate { get; set; }
    //    public string MobileNumber { get; set; }
    //    public string Email { get; set; }
    //    public string PhysicalLocation { get; set; }
    //    public string Username { get; set; }

    //}
}