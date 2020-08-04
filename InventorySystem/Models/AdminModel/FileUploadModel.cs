using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models.AdminModel
{
    public class FileUploadModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string ServerFileName { get; set; }
        public string FileUploadPath { get; set; }
    }
}