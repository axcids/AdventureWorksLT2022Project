using Microsoft.AspNetCore.Mvc;
using EnigeeringEmployeeBasicInfo.Services;
using Customers.Services;

namespace AWLT2022.API.Controllers {
    [ApiController]
    [Route("api/EngineeringEmployeeBasicInfo/")]
    public class EngineeringEmployeeBasicInfoController : Controller {




        [HttpGet]
        [Route("GetAllEngineeringEmployee")]
        public async Task<IActionResult> GetAllEngineeringEmployee() {
            var employeeBasicInfoService = HttpContext.RequestServices.GetService<GetEnigeeringEmployeeBasicInfo>();
            if (employeeBasicInfoService == null) {
                return StatusCode(500, "employeeBasicInfo service is not available");
            }
            var data = await employeeBasicInfoService.GetAllEnigeeringEmployeeBasicInfo();
            if(data == null || data.Count == 0) {
                return NotFound("No Engineering Employee found");
            }
            else {
                return Ok(data);
            }
        }
    }
}
