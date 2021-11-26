using MRAProject.APIs.Classes.Post;
using MRAProject.APIs.Interfaces.Post;
using MRAProject.Models;
using MRAProject.Models.Enums;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRAProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( LoginRequestModel loginRequestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IRestPostRequestWithBasicAunthentication restResponseRequest = new RestPostRequest();
                    IRestResponse response = restResponseRequest.PostRequestWithBasicAunthentication(Session["username"].ToString(), Session["password"].ToString(), ApiUrlLink.GetUrl(),
                        "auth/login", loginRequestModel);
                    var content = response.Content;
                    GeneralResponseModel responseUserModel = JsonConvert.DeserializeObject<GeneralResponseModel>(content);

                    if (responseUserModel.messageCode == (int)SystemMessageCode.Success)
                    {
                        Session["systemNotification"] = responseUserModel.description;
                        return RedirectToAction("AllTaxPayers", "AllTaxPayers");
                    }

                    ViewBag.Error = responseUserModel.description;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Failed to Login. Please contact the system administrator for assistance.";
                    
                    return View("AllTaxPayers","AllTaxPayers");
                }
            }
            ViewBag.Error = "Please fill all the required fields";
            
            return View(loginRequestModel);
        }
    }
}