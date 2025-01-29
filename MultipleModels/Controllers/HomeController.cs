using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultipleModels.Models;

namespace MultipleModels.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(sortorder))
            {
                sortorder = "asc";
            }
            if (string.IsNullOrEmpty(sortcolumn))
            {
                sortcolumn = "Eno";
            }
            ViewBag.SortOrder = sortorder == "asc" ? "desc" : "asc";
            CompanyDBDataContext dBDataContext = new CompanyDBDataContext();
            List<Employee> emp = SortEmployees(dBDataContext.GetEmployees(), sortorder, sortcolumn);
            List<Department> dept = dBDataContext.GetDepartments();
            EmpDeptViewModel empDeptViewModel = new EmpDeptViewModel
            {
                departments = dept,
                employees = emp
            };
            return View(empDeptViewModel);
        }
        public List<Employee> SortEmployees(List<Employee> employees, string sortorder, string sortcolumn)
        {
            List<Employee> emps = employees;
            List<Employee> sortedEmployees = new List<Employee>();
            switch (sortcolumn)
            {
                case "Eno":
                    sortedEmployees = sortorder == "asc" ? emps.OrderBy(e => e.Eno).ToList() : emps.OrderByDescending(e => e.Eno).ToList();
                    break;
                case "Ename":
                    sortedEmployees = sortorder == "asc" ? emps.OrderBy(e => e.Ename).ToList() : emps.OrderByDescending(e => e.Ename).ToList();
                    break;
                case "Job":
                    sortedEmployees = sortorder == "asc" ? emps.OrderBy(e => e.Job).ToList() : emps.OrderByDescending(e => e.Job).ToList();
                    break;
                case "Salary":
                    sortedEmployees = sortorder == "asc" ? emps.OrderBy(e => e.Salary).ToList() : emps.OrderByDescending(e => e.Salary).ToList();
                    break;
                case "Dname":
                    sortedEmployees = sortorder == "asc" ? emps.OrderBy(e => e.Dname).ToList() : emps.OrderByDescending(e => e.Dname).ToList();
                    break;
            }
            return sortedEmployees;
        }
    }
}