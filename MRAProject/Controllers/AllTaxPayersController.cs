using MRAProject.APIs.Classes.Get;
using MRAProject.APIs.Classes.Post;
using MRAProject.APIs.Interfaces.Get;
using MRAProject.APIs.Interfaces.Post;
using MRAProject.Models;
using MRAProject.Models.Enums;
using MRAProject.Models.RequestModels;
using Newtonsoft.Json;
using RestSharp;
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
        public ActionResult AllTaxPayers(AllTaxpayerModel approvalUserModel)
        {
            try
            {
                approvalUserModel.Email = Convert.ToString(Session["email"]);
                IRestGetRequestWithBasicAunthentication restPostRequest = new RestGetRequest();
                IRestResponse response = restPostRequest.GetRequestWithBasicAunthentication(Session["email"].ToString(), Session["password"].ToString(), ApiUrlLink.GetUrl(), "Taxpayers/getAll", approvalUserModel);
                var content = response.Content;
                GeneralResponseModel responseUserModel = JsonConvert.DeserializeObject<GeneralResponseModel>(content);
                if (responseUserModel.messageCode == (int)SystemMessageCode.Success)
                {
                    
                    Session["systemNotification"] = responseUserModel.description;
                    return RedirectToAction("AllUserRequests", "ProcessNitelUserRegistration");
                }
                ViewBag.Error = responseUserModel.description;
            }
            catch (Exception ex)
            {
                
                ViewBag.message = "Failed to load users, Please contact the system administrator for assistance.";
                
            }
            return RedirectToAction("Login", "Login");
        }
        public ActionResult AddTaxPayers(AddTaxpayerModel approvalUserModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IRestPostRequestWithBasicAunthentication restPostRequest = new RestPostRequest();
                    IRestResponse response = restPostRequest.PostRequestWithBasicAunthentication(Session["email"].ToString(), Session["password"].ToString(), ApiUrlLink.GetUrl(), "Taxpayers/add", approvalUserModel);
                    var content = response.Content;
                    GeneralResponseModel responseModel = JsonConvert.DeserializeObject<GeneralResponseModel>(content);

                    if (responseModel.messageCode == (int)SystemMessageCode.Success)
                    {
                        Session["systemNotification"] = responseModel.description;
                        return RedirectToAction("AddTaxPayers","AllTaxPayers");
                    }

                    ViewBag.Error = responseModel.description;
                    return View(approvalUserModel);
                }
                catch (Exception ex)
                {
                    
                    ViewBag.Error = "Failed to add the new Tax payer. Please contact the system administrator for assistance.";
                   
                }
            }
            return RedirectToAction("Login", "Login");
        }
    
    }
}