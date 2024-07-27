using System.Collections.Generic;
using System.Linq;

namespace EMS.Models
{
    public class DBOperations
    {
        public EmployeesDM GetEmployee(int id)
        {
            using (var dbObj = new EmployeeDBEntities())
            {
                var result = dbObj.Employees.Where(x => x.id == id).Select(x => new EmployeesDM()
                {
                    Id = x.id,
                    Firstname = x.firstname,
                    Lastname = x.lastname,
                    Mobile = x.mobile,
                    Emailid = x.emailid,
                    Address = x.address,
                    Department = x.department
                }).FirstOrDefault();
                return result;
            }
        }

        public List<EmployeesDM> GetAllEmployees()
        {
            using (var dbObj = new EmployeeDBEntities())
            {
                var result = dbObj.Employees.Select(x => new EmployeesDM()
                {
                    Id = x.id,
                    Firstname = x.firstname,
                    Lastname = x.lastname,
                    Mobile = x.mobile,
                    Emailid = x.emailid,
                    Address = x.address,
                    Department = x.department
                }).ToList();
                return result;
            }
        }

        public int AddEmployee(EmployeesDM obj)
        {
            using (var dbObj = new EmployeeDBEntities())
            {
                Employees emp = new Employees()
                {
                    firstname = obj.Firstname,
                    lastname = obj.Lastname,
                    mobile = obj.Mobile,
                    emailid = obj.Emailid,
                    address = obj.Address,
                    department = obj.Department,
                    Users = new Users()
                    {
                        username = obj.UsersDM.Username,
                        password = obj.UsersDM.Password
                    }
                };
                dbObj.Employees.Add(emp);
                dbObj.SaveChanges();
                return emp.id;
            }
        }

        public bool UpdateEmployee(int id, EmployeesDM obj)
        {
            using (var dbObj = new EmployeeDBEntities())
            {
                var emp = dbObj.Employees.FirstOrDefault(x => x.id == id);
                if (emp != null)
                {
                    emp.firstname = obj.Firstname;
                    emp.lastname = obj.Lastname;
                    emp.mobile = obj.Mobile;
                    emp.emailid = obj.Emailid;
                    emp.address = obj.Address;
                    emp.department = obj.Department;
                }
                dbObj.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var dbObj = new EmployeeDBEntities())
            {
                var emp = dbObj.Employees.FirstOrDefault(x => x.id == id);
                if (emp != null)
                {
                    var usr = dbObj.Users.FirstOrDefault(x => x.id == emp.userid);
                    if (usr != null)
                    {
                        dbObj.Employees.Remove(emp);
                        dbObj.Users.Remove(usr);
                        dbObj.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }

        public bool MapRole(EmployeesDM obj)
        {
            using (var dbObj = new EmployeeDBEntities())
            {
                var emp = dbObj.Employees.FirstOrDefault(x => x.id == obj.Id);
                if (emp != null)
                {
                    var usr = dbObj.Users.FirstOrDefault(x => x.id == emp.userid);
                    if (usr != null)
                    {
                        usr.roleid = obj.UsersDM.RolesDM.Id;
                        dbObj.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}