using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudNewProject.Models
{
    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public Nullable<int> CountryId { get; set; }
        
    }
}