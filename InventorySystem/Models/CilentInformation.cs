using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class ClientInformation
    {
        [Key]
        public int ClientId { get; set; }
        public string CilentName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPassword { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}