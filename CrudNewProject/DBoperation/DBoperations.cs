using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudNewProject.Models;
namespace CrudNewProject.DBoperation
{
    public class DBoperations
    {
        public List<EmployeeModel> GetAllData()
        {
            EmployeesEntities employeesEntities = new EmployeesEntities();
            using (var context = new EmployeesEntities())
            {
                var result = context.Employee.Where(x => x.isActive == true).Select(x => new EmployeeModel() {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                    Password = x.Password,
                    Did = x.Did,
                    Cid = x.Cid,
                    CityId = x.CityId,
                    Sid = x.Sid,
                    Id = x.Id
                }).ToList();
                return result;
            }
        }

        public List<EmployeeModel> DeletedList()
        {
            EmployeesEntities employeesEntities = new EmployeesEntities();
            using (var context = new EmployeesEntities())
            {
                var result = context.Employee.Where(x => x.isActive == false).Select(x => new EmployeeModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                    Password = x.Password,
                    Did = x.Did,
                    Cid = x.Cid,
                    CityId = x.CityId,
                    Sid = x.Sid,
                    Id = x.Id
                }).ToList();
                return result;
            }
        }


        public EmployeeModel GetEmployeeData(int id)
        {
            using (var context = new EmployeesEntities())
            {

                var result = context.Employee.Where(x => x.Id == id).Select(x => new EmployeeModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                    Password = x.Password
                }).FirstOrDefault();
                return result;
            }
        }


        public bool UpdateEmployee(int id, EmployeeModel employeeModel)
        {
            using (var context = new EmployeesEntities())
            {
                var employees = context.Employee.FirstOrDefault(x => x.Id == id);
                if (employees != null)
                {
                    employees.FirstName = employeeModel.FirstName;
                    employees.LastName = employeeModel.LastName;
                    employees.Email = employeeModel.Email;
                    employees.PhoneNo = employeeModel.PhoneNo;
                    employees.isActive = true;
                }
                context.SaveChanges();
                return true;
            }
        }

        public bool Restore(int id)
        {
            using (var context = new EmployeesEntities())
            {
                var employees = context.Employee.Where(x=>x.Id == id).FirstOrDefault(x => x.isActive == false);
                if (employees != null)
                {
                    employees.isActive = true;
                }
                context.SaveChanges();
                return true;
            }
        }

    }
}