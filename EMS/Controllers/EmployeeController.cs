using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
       
        EmployeeDal dal = new EmployeeDal();

        public ActionResult Index()
        {
            return View();
        }

        //Read (AJAX)
        public JsonResult GetEmployees()
        {
            var data = dal.GetAllEmployees();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Insert (AJAX)

        [HttpPost]
        public JsonResult InsertEmployee(Employee employee)
        {
            bool result = dal.InsertEmployee(employee);
            return Json(result);
        }

        //Get by Id (AJAX)
        [HttpGet]
        public JsonResult GetEmployeeById(int id)
        {
            var data = dal.GetEmployeeById(id);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        //Update (AJAX)
        [HttpPost]
        public JsonResult UpdateEmployee(Employee employee)
        {
            bool result = dal.UpdateEmployee(employee);
            return Json(result);
        }

        //Delete (AJAX)
        [HttpPost]

        public JsonResult DeleteEmployee(int id)
        {
            bool result = dal.DeleteEmployee(id);
            return Json(result);
        }
        
    }
}