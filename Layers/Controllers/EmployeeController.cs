using Layers.Models;
using Layers.Services;
using Layers.Reposiotries;
using Layers.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Layers.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            List<employeeVM> employeeVMs = employeeService.GetAll();
            return View(employeeVMs);
        }

        public IActionResult GetById(int id)
        {
            employeeVM empVM = employeeService.GetById(id);
            return View(empVM);
        }

        public IActionResult Add()
        {
            List<employeeVM> employeeVMs = employeeService.GetAll();
            ViewBag.emps = new SelectList(employeeVMs, "SSN", "Fname");
            return View();
        }
        public IActionResult AddDb(employeeVM employeeVM)
        {
            employeeService.Add(employeeVM);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            List<employeeVM> employeeVMs = employeeService.GetAll();
            employeeVM employeeVM = employeeService.GetById(id);

            ViewBag.emps = new SelectList(employeeVMs, "SSN", "Fname");
            return View(employeeVM);
        }
        public IActionResult EditDb(employeeVM employeeVM)
        {
            employeeService.Edit(employeeVM);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
