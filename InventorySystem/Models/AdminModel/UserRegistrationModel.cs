using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models.AdminModel
{
    public class UserRegistrationModel
    {
        public string Message { get; set; }
        public UserInformation UserInformation { get; set; }
        public CompanyModel CompanyModel { get; set; }
        public List<UserModule> UserModuleList { get; set; }
    }
}