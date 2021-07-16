using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerInBlazorDemo.Data
{
    public class RegisterModel :LoginModel
    {
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
