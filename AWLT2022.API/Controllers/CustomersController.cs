using Microsoft.AspNetCore.Mvc;

namespace AWLT2022.API.Controllers;
public class CustomersController : Controller {
    [HttpGet]
    [Route("GetAllCustomers")]
    public async Task<IActionResult> GetAllCustomers() {
        Customers.Services.CustomerService customerService = HttpContext.RequestServices.GetService(typeof(Customers.Services.CustomerService)) as Customers.Services.CustomerService;
        if (customerService == null) {
            return StatusCode(500, "Customer service not available");
        }
        else {
            var customers = await customerService.GetAllCustomers();
            if (customers == null || customers.Count == 0) {
                return NotFound("No customers found");
            }
            else {
                return Ok(customers);
            }
        }
    }
}