using CrudNewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudNewProject.Models
{
    public class EmployeeVM
    {
        public List<EmployeeModel> GetAllData { get; set; }
        public List<EmployeeModel> DeletedData { get; set; }

    }
}