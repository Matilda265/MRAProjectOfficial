using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRAProject.Controllers
{
    public class AllTaxPayersController : Controller
    {
        // GET: AllTaxPayers
        public ActionResult AllTaxPayers()
        {
           
            List<User> allUsers = new List<User>();
            try
            {
                allUsers = _userRepository.AllUsers(Convert.ToInt32(Session["email"]));
              
                return View(allUsers);
            }
            catch (Exception ex)
            {
                _logException.LogException(ex);
            }
            ViewBag.Error =
                "System run into an internal error. Please try again later. If problem continues contact the administrator";
            return View(allUsers);
        }
    }
}