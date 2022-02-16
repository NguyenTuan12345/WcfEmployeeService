using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfEmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        EAPEmployee db = new EAPEmployee();
        public void CreateEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();

        }

        public Employee GetEmployeeInfo(int id)
        {
            Employee emp = db.Employees.Find(id);
            return emp;
        }

        public List<Employee> SearchEmployeeByFirstName(string firstName)
        {
            List<Employee> empList = new List<Employee>();
            var listEmp = from e in db.Employees select e;
            foreach(var item in listEmp)
            {
                if(item.EmpFirstName == firstName)
                {
                    Employee emp = db.Employees.Find(item.EmpId);
                    empList.Add(emp);
                }
            }
            return empList;
        }
    }
}
