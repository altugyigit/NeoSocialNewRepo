using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NeoSocial.Database.Models
{
    public class Mail
    {
        [EmailAddress]
        public string FromEmail { get; set; }
        [Required,EmailAddress]
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}