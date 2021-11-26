﻿using MRAProject.APIs.Classes.Post;
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
                IRestPostRequestWithBasicAunthentication restPostRequest = new RestPostRequest();
                IRestResponse response = restPostRequest.PostRequestWithBasicAunthentication(Session["username"].ToString(), Session["password"].ToString(), ApiUrlLink.GetUrl(), "Taxpayers/getAll", approvalUserModel);
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
    }
}