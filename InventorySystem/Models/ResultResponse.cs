using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class ResultResponse
    {
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
        public string Data { get; set; }
        public int PrimaryKey { get; set; }
    }
}