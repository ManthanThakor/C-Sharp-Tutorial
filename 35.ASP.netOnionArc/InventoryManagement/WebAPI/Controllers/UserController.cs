using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

using InfrastructureLayer.Service.CustomServices.CustomerServices;
using InfrastructureLayer.Service.CustomServices.SupplierServices;
using WebAPI.Controllers;
using InfrastructureLayer.Service.CustomServices.UserTypeServices;

namespace WebApi.Controllers
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

        private string NoRecordsFound = "No Records Found, Please Try Again Later...!";
        private string InvalidId = "Invalid Id, Please Entering a Valid One...!";
        private string SomethingWentWrong = "Something Went Wrong on our end, Please Try After Sometime...!";
        private string UpdationSuccess = "Record Updated Successfully...!";
        private string DeletionSuccess = "Record Deleted Successfully...!";
        private string UplodePhotoError = "Error While Uploding Profile Photo, Please Try Again Later..!";

        public UserController(ILogger<LoginController> logger, IWebHostEnvironment environment, ISupplierService supplierServices, ICustomerService customerServices, IUserTypeService userTypeServices)
        {
            _logger = logger;
            _environment = environment;
            _supplierServices = supplierServices;
            _customerServices = customerServices;
            _userTypeServices = userTypeServices;
        }
   
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

        [HttpPut(nameof(EditSupplier))]
        public async Task<IActionResult> EditSupplier([FromForm] UserUpdateModel supplierUpdateMoedl)
        {
            if (ModelState.IsValid)
            {
                var checkUser = await _supplierServices.Find(x => x.UserId == supplierUpdateMoedl.UserId && x.Id == supplierUpdateMoedl.Id);
                if (checkUser != null)
                    return BadRequest("User ID : " + supplierUpdateMoedl.UserId + "Already Exists...!");
                else
                {
                    var checkUserName = await _supplierServices.Find(x => x.UserName == supplierUpdateMoedl.UserName && x.Id == supplierUpdateMoedl.Id);
                    if (checkUserName != null)
                    {
                        return BadRequest("UserName : " + supplierUpdateMoedl.UserName + "Already Exists...!");
                    }
                }
                if (supplierUpdateMoedl.UserPhoto != null)
                {
                    var photo = await UploadPhoto(supplierUpdateMoedl.UserPhoto, supplierUpdateMoedl.UserName, DateTime.UtcNow.ToString("dd/MM/yyyy"));
                    if (string.IsNullOrEmpty(photo))
                        return BadRequest(UplodePhotoError);
                    var result = await _supplierServices.Update(supplierUpdateMoedl, photo);
                    if (result == true)
                        return Ok(UpdationSuccess);
                    else
                        return BadRequest(SomethingWentWrong);
                }
                else
                {
                    var result = await _supplierServices.Update(supplierUpdateMoedl, " ");
                    if (result == true)
                        return Ok(UpdationSuccess);
                    else
                        return BadRequest(SomethingWentWrong);
                }
            }
            else
                return BadRequest("Supplier Not Found With Id : " + supplierUpdateMoedl.Id + "Please Try Again Later..!");
        }

        [HttpDelete(nameof(DeleteSupplier))]
        public async Task<IActionResult> DeleteSupplier(Guid Id)
        {
            var result = await _supplierServices.Delete(Id)
;
            if (result != true)
                return Ok(DeletionSuccess);
            return BadRequest(SomethingWentWrong);
        }



        [HttpGet(nameof(GetAllCustomer))]
        public async Task<ActionResult<UserViewModel>> GetAllCustomer()
        {
            var result = await _customerServices.GetAll();
            if (result == null)
                return BadRequest(NoRecordsFound);
            return Ok(result);
        }

        [HttpGet(nameof(GetCustomer))]
        public async Task<IActionResult> GetCustomer(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var result = await _customerServices.Get(Id)
;
                if (result == null)
                    return BadRequest(NoRecordsFound);
                return Ok(result);
            }
            else
                return BadRequest(InvalidId);
        }

        [HttpPut(nameof(EditCustomer))]
        public async Task<IActionResult> EditCustomer([FromForm] UserUpdateModel customerUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var checkUser = await _supplierServices.Find(x => x.UserId == customerUpdateModel.UserId && x.Id == customerUpdateModel.Id);
                if (checkUser != null)
                    return BadRequest("User ID : " + customerUpdateModel.UserId + "Already Exists...!");
                else
                {
                    var checkUserName = await _supplierServices.Find(x => x.UserName == customerUpdateModel.UserName && x.Id == customerUpdateModel.Id);
                    if (checkUserName != null)
                    {
                        return BadRequest("UserName : " + customerUpdateModel.UserName + "Already Exists...!");
                    }
                }
                if (customerUpdateModel.UserPhoto != null)
                {
                    var photo = await UploadPhoto(customerUpdateModel.UserPhoto, customerUpdateModel.UserName, DateTime.UtcNow.ToString("dd/MM/yyyy"));
                    if (string.IsNullOrEmpty(photo))
                        return BadRequest(UplodePhotoError);
                    var result = await _supplierServices.Update(customerUpdateModel, photo);
                    if (result == true)
                        return Ok(UpdationSuccess);
                    else
                        return BadRequest(SomethingWentWrong);
                }
                else
                {
                    var result = await _supplierServices.Update(customerUpdateModel, " ");
                    if (result == true)
                        return Ok(UpdationSuccess);
                    else
                        return BadRequest(SomethingWentWrong);
                }
            }
            else
                return BadRequest("Supplier Not Found With Id : " + customerUpdateModel.Id + "Please Try Again Later..!");
        }

        [HttpDelete(nameof(DeleteCustomer))]
        public async Task<IActionResult> DeleteCustomer(Guid Id)
        {
            var result = await _customerServices.Delete(Id)
;
            if (result != true)
                return Ok(DeletionSuccess);
            return BadRequest(SomethingWentWrong);
        }

        private async Task<string> UploadPhoto(IFormFile file, string Id, string date)
        {
            string fileName;
            _logger.LogInformation("Started Uploading The Profile Photo...!");
            string contentPath = this._environment.ContentRootPath;

            var extention = "." + file.FileName.Split('.')[^1];

            if (extention == ".jpg" || extention == ".jpeg" || extention == ".png")
            {
                fileName = Id.ToLower() + "-" + date + extention;

                string outputFileName = Regex.Replace(fileName, @"[^0-9a-zA-Z.]+", "");

                var pathBuilt = Path.Combine(contentPath, "Images\\User");

                if (!Directory.Exists(pathBuilt))
                    Directory.CreateDirectory(pathBuilt);

                var path = Path.Combine(contentPath, "Images\\User", outputFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream)
;
                }

                _logger.LogInformation("Successfully uploaded Profile photo with the file Name : " + outputFileName + "...!");
                return outputFileName;
            }
            else
            {
                return "";
            }
        }
    }
}