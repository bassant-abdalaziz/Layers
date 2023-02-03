using Layers.Reposiotries;

namespace Layers.Services
{
    public class DI
    {
        private IEmployeeRepo employeeRepo;
        
        public void SetDependency(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        //propery
        public IEmployeeRepo employeeRepo1
        {
            set
            {
                employeeRepo = value;
            }
        }
    }
     
    public class factory
    {
        public static IEmployeeRepo getObject()
        {
            return new EmployeeRepo (new Models.CompanyDBContext());
        }
    }

    public class myMain
    {
        public void myMainFunc()
        {
            DI dI = new DI();
            dI.employeeRepo1 = factory.getObject();
        }
    }
}
