using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class CompanyModel
    {
        public int CompanyID { get; set; }  
        public string CompanyName { get; set; }  
        public int? NatureOfBusinessId { get; set; }  
        public string CompanyShortName { get; set; }  
        public string IndexPrefix { get; set; }  
        public int? CompanyCurrencyId { get; set; }  
        public int? ReportingCurrencyId { get; set; }  
        public string CompanyDescription { get; set; }  
        public int? NoOfEmployees { get; set; }  
        public string PANNumber { get; set; }  
        public string TINNumber { get; set; }  
        public string VATNumber { get; set; }  
        public string RagistrationNumber { get; set; }  
        public string TradeLicenceNumber { get; set; }  
        public string ContactPerson { get; set; }  
        public string CompanyAddress { get; set; }  
        public string City { get; set; }  
        public string State { get; set; }  
        public string Zip { get; set; }  
        public int? CountryId { get; set; }  
        public string Telephone1 { get; set; }  
        public string Telephone2 { get; set; }  
        public string Fax { get; set; }  
        public string Email { get; set; }  
        public string CompanyWebsite { get; set; }  
        public string Remarks { get; set; }  
        public DateTime? CreateDate { get; set; }  
        public DateTime? UpdateDate { get; set; }  
        public bool? IsActive { get; set; }  
        public string CompanyLogoName { get; set; }  
        public string CompanyLogoPath { get; set; }  
        public string CompanyServerName { get; set; }  
    }
}