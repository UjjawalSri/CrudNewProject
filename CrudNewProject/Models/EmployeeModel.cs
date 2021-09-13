using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrudNewProject.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int Did { get; set; }
        public int Cid { get; set; }
        public int Sid { get; set; }
        [EmailAddress()]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNo { get; set; }
        public int CityId { get; set; }
        public string Password { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual State State { get; set; }

        public Nullable<bool> isActive { get; set; }
    }
}