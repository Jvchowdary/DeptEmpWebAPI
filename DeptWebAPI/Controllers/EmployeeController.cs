using DeptWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DeptWebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IHostingEnvironment _environment;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("GetEmp")]
        public async Task<IActionResult> GetEmp()
        {
          return Ok(await _employeeRepository.GetEmployees());
        }

        [HttpGet]
        [Route("GetEmployeeId/{id}")]
        public async Task<IActionResult> GetEmployeeByid(int id)
        {
            return Ok(await _employeeRepository.GetEmployeeById(id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post(Employee employee)
        {
            if (employee == null) {
                return BadRequest();
                    }
            var res= await _employeeRepository.InsertEmployee(employee);
            if(res.EmployeeID == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,"Some thing wrong");
            }

            return Ok("Added Successfully");
        }

        [HttpPut]
        public  async Task<IActionResult> Put(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);

            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _employeeRepository.DeleteEmployee(id);

            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _environment.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    stream.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetAllDepartmentNames()
        {
            return Ok(await _departmentRepository.GetDepartment());
        }
    }
}
