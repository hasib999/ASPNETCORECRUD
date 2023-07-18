using ASPNETTMVCCRUD.Data;
using ASPNETTMVCCRUD.Models;
using ASPNETTMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETTMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext _mVCDemoDbContext;
        public EmployeesController(MVCDemoDbContext mVCDemoDbContext)
        {
            _mVCDemoDbContext = mVCDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees =  await _mVCDemoDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
            };
            await _mVCDemoDbContext.Employees.AddAsync(employee);
            await _mVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
