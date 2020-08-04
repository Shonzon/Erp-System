using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models.AdminModel
{
    public class UserInformation
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string EmployeeCode { get; set; }
        public int? GenderId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DefaultCompanyId { get; set; }
        public int? DefaultBusinessUnitId { get; set; }
        public int? ManagerId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAdmin { get; set; }
        public string UserPhoneNo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? CreatedBYId { get; set; }
        public string UserProPicName { get; set; }
        public string UserProPicPath { get; set; }
        public string UserProPicServerName { get; set; }
    }
}