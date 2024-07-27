using EMS.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS.Controllers
{
    public class HomeController : Controller
    {
        readonly DBOperations db = null;
        public HomeController()
        {
            db = new DBOperations();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UsersDM obj)
        {
            using (var dbObj = new EmployeeDBEntities())
            {
                bool isValid = dbObj.Users.Any(x => x.username == obj.Username && x.password == obj.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(obj.Username, false);
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            ViewBag.IsValid = "Wrong Username or Password!!!";
            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ViewEmployeeList()
        {
            var result = db.GetAllEmployees();
            return View(result);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeesDM obj)
        {
            if (ModelState.IsValid)
            {
                int id = db.AddEmployee(obj);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Employee Details Added Successfully.";
                }
            }
            return View();
        }

        public ActionResult EditEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeesDM obj)
        {
            ModelState.Clear();
            var emp = db.GetEmployee(obj.Id);
            if (emp == null)
                ViewBag.IsSuccess = "No Data Found.";
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeesDM model)
        {
            if (ModelState.IsValid)
            {
                db.UpdateEmployee(model.Id, model);
                return RedirectToAction("ViewEmployeeList");
            }
            return View("EditEmployee", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEmployee()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEmployee(EmployeesDM obj)
        {
            ModelState.Clear();
            var emp = db.GetEmployee(obj.Id);
            if (emp == null)
                ViewBag.IsSuccess = "No Data Found.";
            return View(emp);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            db.DeleteEmployee(id);
            return RedirectToAction("ViewEmployeeList");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult MapRole()
        {
            EmployeeDBEntities dbObj = new EmployeeDBEntities();
            ViewBag.empList = new SelectList(dbObj.Employees, "id", "firstname");
            ViewBag.roleList = new SelectList(dbObj.Roles, "id", "role");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult MapRole(EmployeesDM obj)
        {
            if (db.MapRole(obj))
            {
                ViewBag.RoleStatus = "Role Assigned Successfully";
                return View("Dashboard");
            }
            ViewBag.RoleStatus = "Failed !!!";
            return View("Dashboard");
        }
    }
}