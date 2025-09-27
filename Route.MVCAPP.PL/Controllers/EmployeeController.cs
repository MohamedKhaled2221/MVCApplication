using Microsoft.AspNetCore.Mvc;
using Route.MVCAPP.BLL.DTOs.Employees;
using Route.MVCAPP.BLL.Services.Employees;

namespace Route.MVCAPP.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _environment;

        #region Part 6 Employee Controller
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _logger = logger;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();

            return View(Employees);
        }

        #region Part 7 Employee Controller - Create

        [HttpGet]
        public IActionResult Create(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto EmployeeDto)
        {
            if (!ModelState.IsValid) //Server Side Validation
            {
                return View(EmployeeDto);
            }
            var message = string.Empty;

            try
            {
                var result = _employeeService.CreateEmployee(EmployeeDto);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    message = "Failed to Create Employee";
                    ModelState.AddModelError(string.Empty, message);
                    return View(EmployeeDto);
                }
            }
            catch (Exception ex)
            {
                //1- Log Exception
                _logger.LogError(ex, ex.Message);
                //2- Set Message for User
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(EmployeeDto);
                }
                else
                {
                    message = "Employee is not Created";
                    return View("Error", message);
                }

            }
        }

        #endregion
        public IActionResult Details(int? id)

        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var Employee = _employeeService.GetEmployeeById(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }



        [HttpGet]

        //public IActionResult Edit(int? id)
        //{
        //    if (!id.HasValue || id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    var Employee = _employeeService.GetEmployeeById(id.Value);
        //    if (Employee == null)
        //    {
        //        return NotFound();

        //    }
        //    return View(new EmployeeEditViewModel()
        //    {
        //        Code = Employee.Code,
        //        Name = Employee.Name,
        //        Description = Employee.Description,
        //        CreationDate = Employee.CreationDate
        //    });
        //}
        [HttpPost]
        //public IActionResult Edit([FromRoute] int id, EmployeeEditViewModel EmployeeVM)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(EmployeeVM);
        //    }
        //    var message = string.Empty;
        //    try
        //    {
        //        var UpdateEmployee = new UpdatedEmployeeDto()
        //        {
        //            Id = id,
        //            Code = EmployeeVM.Code,
        //            Name = EmployeeVM.Name,
        //            Description = EmployeeVM.Description,
        //            CreationDate = EmployeeVM.CreationDate
        //        };
        //        var Updated = _employeeService.UpdateEmployee(UpdateEmployee) > 0;
        //        if (Updated)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            message = "An Error Has been Occured :(";
        //            ModelState.AddModelError(string.Empty, message);
        //            return View(EmployeeVM);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //1- Log Exception
        //        _logger.LogError(ex, ex.Message);
        //        //2- Set Message for User
        //        if (_environment.IsDevelopment())
        //        {
        //            message = ex.Message;
        //            return View(EmployeeVM);
        //        }
        //        else
        //        {
        //            message = "An Error Has been Occured :(";
        //            return View("Error", message);
        //        }
        //    }
        //}

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest();
            }
            var Employee = _employeeService.GetEmployeeById(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var deleted = _employeeService.DeleteEmployee(id);

                if (deleted)
                {
                    return RedirectToAction("Index");
                }
                message = "An Error Has been Occured :(";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "An Error Has been Occured :(";
            }
            return RedirectToAction(nameof(Delete), new { id });
        }

        #endregion

    }
}
