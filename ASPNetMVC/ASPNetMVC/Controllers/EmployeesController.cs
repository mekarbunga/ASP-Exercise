using ASPNetMVC.Context;
using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        private MyContext myContext = new MyContext(); 
        public ActionResult Index()
        {
            return View(myContext.Employees.ToList());
        }
        public ActionResult Create()
        {
            return View(myContext.Employees.Create());
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            myContext.Employees.Add(employee);
            myContext.SaveChanges();
            return RedirectToAction("Index");
            //return View(myContext.Employees.Create());
        }

        public ActionResult Details(int id)
        {
            return View(myContext.Employees.Find(id));
        }

        public ActionResult Update(int id)
        {
            return View(myContext.Employees.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            myContext.Entry(employee).State = EntityState.Modified;
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(myContext.Employees.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(Employee employee, int id)
        {
            var del = myContext.Employees.Find(id);
            myContext.Employees.Remove(del);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}