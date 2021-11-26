using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAProject.Models.Enums
{
    public enum SystemMessageCode
    {
        EmailDoesNotExist = 0,
       
        UserDoesNotExist = 3,
       
        UserCrediantialsCorrect = 7,
        NoResponse = 8,
       
        UserCredentialsIncorrect = 13,        
        UserIdDoesNotExist = 25,
        
        ModelDataInvalid,
        Success = 200,
        InternalServerError = 500
    }
}