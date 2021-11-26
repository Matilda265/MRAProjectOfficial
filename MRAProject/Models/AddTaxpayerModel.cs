using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRAProject.Models
{
    public class AddTaxpayerModel
    {
        [Required]
        public string TPIN { get; set; }
        public string BusinessCertificateNumber { get; set; }

        [Display(Name = "Trading Name")]
        [Required]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Trading Name should only contain alphabetical letters")]
        public string TradingName { get; set; }
        public string BusinessRegistrationDate { get; set; }
        public string MobileNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Email address is not in a valid format. Example of correct format: joe.example@example.org")]
        public string Email { get; set; }
        public string PhysicalLocation { get; set; }
        public string Username { get; set; }

    }
}