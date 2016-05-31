using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;
using SapnaWebsite.Models;

namespace SapnaWebsite.ViewModels.Manage
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }
         
        public string FirstName { get; set; }

         
        public string LastName { get; set; }
    }
}
