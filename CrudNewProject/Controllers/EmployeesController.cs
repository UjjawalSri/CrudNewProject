using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudNewProject.Models;
using CrudNewProject.DBoperation;

namespace CrudNewProject.Controllers
{
    
    public class EmployeesController : Controller
    {

        EmployeesEntities db = null;
        DBoperations DBoperations = null;

        public EmployeesController()
        {
            DBoperations = new DBoperations();
            db = new EmployeesEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetResult()
        {
            EmployeeVM empvm = new EmployeeVM();
            empvm.GetAllData = DBoperations.GetAllData();
            return PartialView("GetResult", empvm);
        }

        public ActionResult DeletedList()
        {
            EmployeeVM empvm = new EmployeeVM();
            empvm.DeletedData = DBoperations.DeletedList();
            return PartialView("DeletedList", empvm);
        }

        public long DeleteEmployee(int EmployeeId)
        {
            using (var context = new EmployeesEntities())
            {
                var emp = context.Employee.FirstOrDefault(x => x.Id == EmployeeId);
                if (emp != null)
                {
                    emp.isActive = false;
                    context.SaveChanges();
                    return 1;
                }
                return 0;
            }
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            List<Department> departments = db.Department.ToList();
            ViewBag.Department = new SelectList(departments, "Id", "DepartmentName");

            ViewBag.CountryList = new SelectList(countries(), "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(EmployeeModel employeeModel, CascadingModel cascadingModel)
        {

            using (var context = new EmployeesEntities())
            {
                Employee employee = new Employee()
                {
                    FirstName = employeeModel.FirstName,
                    LastName = employeeModel.LastName,
                    Email = employeeModel.Email,
                    PhoneNo = employeeModel.PhoneNo,
                    Password = employeeModel.Password,
                    Did = employeeModel.Department.Id,
                    CityId = cascadingModel.CityId,
                    Sid = cascadingModel.StateId,
                    Cid = cascadingModel.CountryId
                };
                context.Employee.Add(employee);
                context.SaveChanges();
                if (ModelState.IsValid)
                {
                    if (employee.Id > 0)
                    {
                        ModelState.Clear();
                        ViewBag.MyData = "Data Added";
                    }
                }
            };
            return RedirectToAction("Index");
        }

        public List<Country> countries()
        {
            List<Country> countries = db.Country.ToList();
            return countries;
        }

        public JsonResult GetStateList(int CountryId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<State> states = db.State.Where(x => x.CountryId == CountryId).ToList();

            return Json(states, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCityList(int StateId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<SelectListItem> states = db.State.Where(x => x.CountryId == CountryId).ToList().Select(x=>new SelectListItem {Text=x.StateName, Value=x.StateId.ToString()}).ToList();
            List<City> cities = db.City.Where(x => x.StateId == StateId).ToList();

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var result = DBoperations.GetEmployeeData(id);
            return View(result);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var employee = DBoperations.GetEmployeeData(id);
            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                DBoperations.UpdateEmployee(employeeModel.Id, employeeModel);
                return RedirectToAction("Index");
            }
            return View();
        }


        public long Restore(int empId)
        {
            using (var context = new EmployeesEntities())
            {
                var emp = context.Employee.FirstOrDefault(x => x.Id == empId);
                if (emp != null)
                {
                    emp.isActive = true;
                    context.SaveChanges();
                    return 1;
                }
                return 0;
            }
        }

    }


    }
