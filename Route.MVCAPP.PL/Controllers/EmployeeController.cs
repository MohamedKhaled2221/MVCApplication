using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Route.MVCAPP.BLL.DTOs.Departments;
using Route.MVCAPP.BLL.DTOs.Employees;
using Route.MVCAPP.BLL.Services.Departments;
using Route.MVCAPP.BLL.Services.Employees;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.PL.ViewModels.Departments;

namespace Route.MVCAPP.PL.Controllers
{
    #region Part 2 ValidateAntiForgeryToken
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        #region Part 6 Employee Controller
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger
            , IWebHostEnvironment environment , IMapper mapper)
        {;
            _logger = logger;
            _employeeService = employeeService;
            _environment = environment;
            _mapper = mapper;

            
        }  
        [HttpGet]
        #region Part 2 Search By EmployeeName
        public async Task<IActionResult> Index(string search)
        {
            var Employees =await _employeeService.GetAllEmployeesAsync(search);

            return View(Employees);
        } 
        #endregion

        #region Part 7 Employee Controller - Create

        [HttpGet]
        public IActionResult Create()
        {
           

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatedEmployeeDto EmployeeDto)
        {
            if (!ModelState.IsValid) //Server Side Validation
            {
                return View(EmployeeDto);
            }
            var message = string.Empty;

            try
            {
                var result =await _employeeService.CreateEmployeeAsync(EmployeeDto);
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
        #region Part 8 Employee Controller - Details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)

        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var Employee =await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
        #endregion



        #region Part 9 Employee Controller - Edit
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest();
            }
            var Employee =await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (Employee == null)
            {
                return NotFound();

            }
            var CreatedEmpoyee = _mapper.Map<EmployeeDetailsDto, CreatedEmployeeDto>(Employee);

            //return View(new CreatedEmployeeDto()
            //{
            //    Name = Employee.Name,
            //    Address = Employee.Address,
            //    Age = Employee.Age,
            //    Email = Employee.Email,
            //    PhoneNumber = Employee.PhoneNumber,
            //    Salary = Employee.Salary,
            //    IsActive = Employee.IsActive,
            //    EmployeeType = Employee.EmployeeType,
            //    Gender = Employee.Gender,
            //    HiringDate = Employee.HiringDate,
            //});
            return View(CreatedEmpoyee);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, CreatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }
            var message = string.Empty;
            try
            {
                var updatedemployee = _mapper.Map<CreatedEmployeeDto, UpdatedEmployeeDto>(employeeDto);
                //var updatedemployee = new UpdatedEmployeeDto()
                //{
                //    Name = employeeDto.Name,
                //    Address = employeeDto.Address,
                //    Age = employeeDto.Age,
                //    Salary = employeeDto.Salary,
                //    IsActive = employeeDto.IsActive,
                //    Email = employeeDto.Email,
                //    PhoneNumber = employeeDto.PhoneNumber,
                //    HiringDate = employeeDto.HiringDate,
                //    Gender = employeeDto.Gender,
                //    EmployeeType = employeeDto.EmployeeType,
                //    Id = id
                //};

                var Updated =await _employeeService.UpdateEmployeeAsync(updatedemployee) > 0;
                if (Updated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    message = "An Error Has been Occured :(";
                    ModelState.AddModelError(string.Empty, message);
                    return View(employeeDto);
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
                    return View(employeeDto);
                }
                else
                {
                    message = "An Error Has been Occured :(";
                    return View("Error", message);
                }
            }
        }
        #endregion

        #region Part 10 - Employee Controller - Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest();
            }
            var Employee =await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var deleted =await _employeeService.DeleteEmployeeAsync(id);

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
        #endregion

    } 
    #endregion
}
