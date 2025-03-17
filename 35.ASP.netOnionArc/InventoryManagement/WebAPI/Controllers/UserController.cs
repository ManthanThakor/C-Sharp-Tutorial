using Domain.ViewModels;
using InfrastructureLayer.Service.CustomServices.CustomerServices;
using InfrastructureLayer.Service.CustomServices.SupplierServices;
using InfrastructureLayer.Service.CustomServices.UserTypeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ISupplierService _supplierServices;
        private readonly ICustomerService _customerServices;
        private readonly IUserTypeService _userTypeServices;

        public UserController(ILogger<LoginController> logger, IWebHostEnvironment environment, ISupplierService supplierServices, ICustomerService customerServices, IUserTypeService userTypeServices)
        {
            _logger = logger;
            _environment = environment;
            _supplierServices = supplierServices;
            _customerServices = customerServices;
            _userTypeServices = userTypeServices;
        }


        private string NoRecordsFound = "No Records Found, Please Try Again Later...!";
        private string InvalidId = "Invalid Id, Please Entering a Valid One...!";
        private string SomethingWentWrong = "Something Went Wrong on our end, Please Try After Sometime...!"; 
        private string InsertionSuccess = "Record Inserted Successfully...!";
        private string UpdationSuccess = "Record Updated Successfully...!";
        private string DeletionSuccess = "Record Deleted Successfully...!";

        [HttpGet(nameof(GetAllSupplier))]
        public async Task<ActionResult<UserViewModel>> GetAllSupplier()
        {
            var result = await _supplierServices.GetAll();
            if (result == null)
                return BadRequest(NoRecordsFound);
            return Ok(result);
        }

        [HttpGet(nameof(GetSupplier))]
        public async Task<IActionResult> GetSupplier(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var result = await _supplierServices.Get(Id)
        ;
                if (result == null)
                    return BadRequest(NoRecordsFound);
                return Ok(result);
            }
            else
                return BadRequest(InvalidId);
        }

        //[HttpPut(nameof(EditSupplier))]
        //public async Task<IActionResult> EditSupplier([FromForm] UserUpdateModel customerUpdateMoedl)
        //{

        //}

        //[HttpDelete(nameof(DeleteSupplier))]
        //public async Task<IActionResult> DeleteSupplier(Guid Id)
        //{

        //}
        //#endregion

        //#region Customer Section API'S

        //[HttpGet(nameof(GetAllCustomer))]
        //public async Task<ActionResult<UserViewModel>> GetAllCustomer()
        //{

        //}

        //[HttpGet(nameof(GetCustomer))]
        //public async Task<IActionResult> GetCustomer(Guid Id)
        //{

        //}

        //[HttpPut(nameof(EditCustomer))]
        //public async Task<IActionResult> EditCustomer([FromForm] UserUpdateModel customerUpdateModel)
        //{

        //}

        //[HttpDelete(nameof(DeleteCustomer))]
        //public async Task<IActionResult> DeleteCustomer(Guid Id)
        //{

        //}
    }
}