using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CrudNewProject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Enter Your Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        public string Password { get; set; }
    }
}