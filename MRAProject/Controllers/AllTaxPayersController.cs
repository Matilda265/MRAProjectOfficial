using MRAProject.Models;
using MRAProject.Models.Enums;
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
            try
            {
                approvalUserModel.respondedBy = Convert.ToInt32(Session["userPK"]);
                IRestPostRequestWithBasicAunthentication restPostRequest = new RestPostRequest();
                IRestResponse response = restPostRequest.PostRequestWithBasicAunthentication(Session["username"].ToString(), Session["password"].ToString(), ApiUrlLink.GetUrl(), "api/users/nitel-users/response-user-creation", approvalUserModel);
                var content = response.Content;
                GeneralResponseModel responseUserModel = JsonConvert.DeserializeObject<GeneralResponseModel>(content);
                if (responseUserModel.messageCode == (int)SystemMessageCode.Success)
                {
                    //try
                    //{
                    //    MailServerConfiguration currentMailConfiguration = _openChequelistUnitOfWork.Repository<MailServerConfiguration>().Get(u => u.state);
                    //    var relativeUrl = "/UserAccountActivation/VerifyAccount/" + newUserToAdd.activationCode;
                    //    var link = currentMailConfiguration.rootPath + relativeUrl;
                    //    string subject = "Your account is successfully created!";
                    //    string body = "Hello " + newUserToAdd.firstName + " " + newUserToAdd.lastName + ",<br/><br/> We are excited to tell you that your Open Chequelist User account has been successfully created. Please click on the below link to verify your account" + "<br/><br/> <a href ='" + link + "'>" + link + "</a>";

                    //    _emailHandler.SendEmail(newUserToAdd.email, subject, body);
                    //}
                    //catch (Exception ex)
                    //{
                    //    _logger.LogException(ex);
                    //    _messageCodeToInt = Convert.ToInt32(SystemMessageCode.Success);
                    //    _generalResponseModel.messageCode = _messageCodeToInt;
                    //    _generalResponseModel.description = "Failed to send email address to the new User added. Please make sure the email address is valid. <br />" +
                    //                                     "If problem persists, please contact the system administrator for assistance.";
                    //    return _generalResponseModel;
                    //}
                    Session["systemNotification"] = responseUserModel.description;
                    return RedirectToAction("AllUserRequests", "ProcessNitelUserRegistration");
                }
                ViewBag.Error = responseUserModel.description;
                MessageFromApi messageFromApi = JsonConvert.DeserializeObject<MessageFromApi>(content);
                ViewBag.message = messageFromApi.Message;
                return LoadAllNitelRequestDependencies();
            }
            catch (Exception ex)
            {
                _logException.LogException(ex);
                ViewBag.message = "Failed to add the new User, Please contact the system administrator for assistance.";
                return LoadAllNitelRequestDependencies();
            }
        }
    }
}