using Layers.Models;
using Layers.Reposiotries;
using Layers.viewModels;

namespace Layers.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
           this.employeeRepo = employeeRepo;
        }

        public List<employeeVM> GetAll()
        {
            List<Employee> employees = employeeRepo.GetAll();

            List<employeeVM> employeeVMs = new List<employeeVM>();
            foreach (var emp in employees)
            {
                employeeVMs.Add(new employeeVM()
                {
                    SSN = emp.SSN,
                    Fname = emp.Fname,
                    Lname = emp.Lname,
                    Minit = emp.Minit,
                    Sex = emp.Sex,
                    Address = emp.Address,
                    Salary = emp.Salary,
                    BirthDate = emp.BirthDate,
                    SupervisorSSN = emp.SupervisorSSN,
                });
            }
            return employeeVMs;
        }

        public employeeVM GetById(int id)
        {
            Employee employee = employeeRepo.GetById(id);
            employeeVM employeeVM = new employeeVM()
            {
                SSN = employee.SSN,
                Fname = employee.Fname,
                Lname = employee.Lname,
                Minit = employee.Minit,
                Sex = employee.Sex,
                Address = employee.Address,
                Salary = employee.Salary,
                BirthDate = employee.BirthDate,
                SupervisorSSN = employee.SupervisorSSN,
            };
            return employeeVM;
        }



        public int Add(employeeVM employeeVM)
        {

            Employee employee = new Employee()
            {
                SSN = employeeVM.SSN,
                Fname = employeeVM.Fname,
                Lname = employeeVM.Lname,
                Minit = employeeVM.Minit,
                Salary = employeeVM.Salary,
                Sex = employeeVM.Sex,
                Address = employeeVM.Address,
                BirthDate = employeeVM.BirthDate
            };

            return employeeRepo.Add(employee);

        }

        public int Edit(employeeVM employeeVM)
        {

            Employee employee = new Employee()
            {
                SSN = employeeVM.SSN,
                Fname = employeeVM.Fname,
                Lname = employeeVM.Lname,
                Minit = employeeVM.Minit,
                Salary = employeeVM.Salary,
                Sex = employeeVM.Sex,
                Address = employeeVM.Address,
                BirthDate = employeeVM.BirthDate
            };

            return employeeRepo.Edit(employee);

        }
        public int Delete(int id)
        {
            return employeeRepo.Delete(id);

        }

    }
}
