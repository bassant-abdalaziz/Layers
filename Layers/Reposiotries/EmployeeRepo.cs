using Layers.Models;

namespace Layers.Reposiotries
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private CompanyDBContext DB;
        public EmployeeRepo(CompanyDBContext dBContext)
        {
            this.DB = dBContext;
        }

        public List<Employee> GetAll()
        {
            //List<Employee> employees = DB.Employees.ToList();
            //return employees;

            return DB.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return DB.Employees.SingleOrDefault(e => e.SSN == id);
        }


        public int Add(Employee employee)
        {
            try
            {
                DB.Employees.Add(employee);
                return DB.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }


        public int Edit(Employee employee)
        {
            try
            {
                Employee oldEmployee = DB.Employees.SingleOrDefault(e => e.SSN == employee.SSN);
                oldEmployee.Fname = employee.Fname;
                oldEmployee.Lname = employee.Lname;
                oldEmployee.Minit = employee.Minit;
                oldEmployee.Sex = employee.Sex;
                oldEmployee.Address = employee.Address;
                oldEmployee.Salary = employee.Salary;
                oldEmployee.BirthDate = employee.BirthDate;
                oldEmployee.SupervisorSSN = employee.SupervisorSSN;

                DB.Employees.Add(oldEmployee);
                return DB.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int Delete(int id)
        {
            Employee employee = GetById(id);
            DB.Employees.Remove(employee);
            return DB.SaveChanges();
        }


    }
}
