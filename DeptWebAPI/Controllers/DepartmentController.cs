using DeptWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeptWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository department)
        {
            _departmentRepository = department;
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetDept()
        {
            return Ok(await _departmentRepository.GetDepartment());
        }

        [HttpGet]
        [Route("GetDepartmentById/{id}")]
        public async Task<IActionResult> GetDeptById(int id)
        {
            return Ok(await _departmentRepository.GetDepartmentByID(id));
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post(Department department)
        { 
            var result=_departmentRepository.InsertDepartment(department);
            if(result.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpGet]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> Put(Department department)
        {
           await _departmentRepository.UpdateDepartment(department);
            return Ok("Updated successfully");
        }

        [HttpDelete]
        [Route("DeleteDept")]
        public JsonResult DeleteDept(string id)
        {
            _departmentRepository.DeleteDepartment(id);
            return new JsonResult("Deleted Successfully");
        }


    }
}
