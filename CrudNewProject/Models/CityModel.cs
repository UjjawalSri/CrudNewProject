using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudNewProject.Models
{
    public class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Nullable<int> StateId { get; set; }
    }
}