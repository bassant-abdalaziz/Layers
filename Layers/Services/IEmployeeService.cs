using Layers.Models;
using Layers.viewModels;

namespace Layers.Services
{
    public interface IEmployeeService
    {
        int Add(employeeVM employeeVM);
        int Edit(employeeVM employeeVM);
        public int Delete(int id);
        List<employeeVM> GetAll();
        employeeVM GetById(int id);
    }
}