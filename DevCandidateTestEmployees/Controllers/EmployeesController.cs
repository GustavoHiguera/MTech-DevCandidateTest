using DevCandidateTestEmployees.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DevCandidateTestEmployees.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Employees.ToList());

            }
        }



        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Employees.Where(x => x.ID == id).FirstOrDefault());
            }
               
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employees employees)
        {
            try
            {
                using (DbModels context = new DbModels()) 
                {
                    context.Employees.Add(employees);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Employees.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employees employees)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(employees).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Employees.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using(DbModels context = new DbModels())
                {
                    Employees employee = context.Employees.Where(x=>x.ID == id).FirstOrDefault();
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
