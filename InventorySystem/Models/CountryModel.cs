using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryFlag { get; set; }
    }
}