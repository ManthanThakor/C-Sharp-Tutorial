using System.Net;
using System.Text.RegularExpressions;
using Domain.Models;
using Domain.Helpers;
using Domain.ViewModels;
using WebAPI.Middleware.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using InfrastructureLayer.Service.CustomServices.CustomerServices;
using InfrastructureLayer.Service.CustomServices.SupplierServices;
using InfrastructureLayer.Service.GeneralServices;
using Services.common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISupplierService _supplierServices;
        private readonly ICustomerService _customerServices;
        private readonly IJWTAuthManager _authManager;
        private readonly IWebHostEnvironment _environment;
        private readonly IService<UserType> _serviceUserType;

        public LoginController(
            ILogger<LoginController> logger,
            ISupplierService supplierServices,
            ICustomerService customerServices,
            IService<UserType> serviceUserType,
            IJWTAuthManager authManager,
            IWebHostEnvironment environment)
        {
            _logger = logger;
            _supplierServices = supplierServices;
            _customerServices = customerServices;
            _authManager = authManager;
            _environment = environment;
            _serviceUserType = serviceUserType;
        }

        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin(LoginModel loginModel)
        {
            Response<string> response = new();

            if (!ModelState.IsValid)
            {
                response.Message = "Please Enter Valid Credentials...!";
                response.Status = (int)HttpStatusCode.NotAcceptable;
                return BadRequest(response);
            }

            var user = await _supplierServices.Find(x => x.UserName == loginModel.UserName && x.UserPassword == Encryptor.EncryptString(loginModel.Password));

            if (user == null)
            {
                response.Message = "Invalid UserName / Password Provided, Please Enter Valid Credentials...!";
                response.Status = (int)HttpStatusCode.NotFound;
                return NotFound(response);
            }

            response.Message = _authManager.GenerateJWT(user);
            response.Status = (int)HttpStatusCode.OK;
            return Ok(response);
        }

        [HttpPost("RegisterCustomer")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCustomer([FromForm] UserInsertModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Customer Information Provided, Please Try Again Later...!");
            }

            var userType = await _serviceUserType.Find(x => x.TypeName == "Customer");
            if (userType == null)
            {
                return BadRequest("Something Went Wrong On our End, Please Contact Admin for Support...!");
            }

            if (customerModel.UserPhoto == null)
            {
                return BadRequest("Please Upload Profile Photo as it is Mandatory...!");
            }

            var checkUser = await _customerServices.Find(x => x.UserId == customerModel.UserId);
            if (checkUser != null)
            {
                return BadRequest($"User ID : {customerModel.UserId} already Exists, Please use a different One.");
            }

            var checkUserName = await _customerServices.Find(x => x.UserName == customerModel.UserName);
            if (checkUserName != null)
            {
                return BadRequest($"UserName : {customerModel.UserName} already Exists, Please use a different UserName.");
            }

            var photo = await UploadPhoto(customerModel.UserPhoto, customerModel.UserName, DateTime.UtcNow.ToString("dd/MM/yyyy"));
            if (string.IsNullOrEmpty(photo))
            {
                return BadRequest("Error Uploading the Profile Photo, Please Try Again Later...!");
            }

            var result = await _customerServices.Insert(customerModel, photo);
            if (result)
            {
                return Ok("Customer Registered Successfully...!");
            }

            return BadRequest("Something Went Wrong on our End, Please Contact Admin for Support...!");
        }

        [HttpPost("RegisterSupplier")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterSupplier([FromForm] UserInsertModel supplierModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Supplier Information Provided, Please Try Again Later...!");
            }

            var userType = await _serviceUserType.Find(x => x.TypeName == "Supplier");
            if (userType == null)
            {
                return BadRequest("Something Went Wrong On our End, Please Contact Admin for Support...!");
            }

            if (supplierModel.UserPhoto == null)
            {
                return BadRequest("Please Upload Profile Photo as it is Mandatory...!");
            }

            var checkUser = await _supplierServices.Find(x => x.UserId == supplierModel.UserId);
            if (checkUser != null)
            {
                return BadRequest($"User ID : {supplierModel.UserId} already Exists, Please use a different One.");
            }

            var checkUserName = await _supplierServices.Find(x => x.UserName == supplierModel.UserName);
            if (checkUserName != null)
            {
                return BadRequest($"UserName : {supplierModel.UserName} already Exists, Please use a different UserName.");
            }

            var photo = await UploadPhoto(supplierModel.UserPhoto, supplierModel.UserName, DateTime.UtcNow.ToString("dd/MM/yyyy"));
            if (string.IsNullOrEmpty(photo))
            {
                return BadRequest("Error Uploading the Profile Photo, Please Try Again Later...!");
            }

            var result = await _supplierServices.Insert(supplierModel, photo);
            if (result)
            {
                return Ok("Supplier Registered Successfully...!");
            }

            return BadRequest("Something Went Wrong on our End, Please Contact Admin for Support...!");
        }

        private async Task<string> UploadPhoto(IFormFile file, string id, string date)
        {
            string contentPath = _environment.ContentRootPath;
            string extension = Path.GetExtension(file.FileName).ToLower();

            if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
            {
                return "";
            }

            string fileName = $"{id.ToLower()}-{date}{extension}";
            string outputFileName = Regex.Replace(fileName, @"[^0-9a-zA-Z.]+", "");
            string pathBuilt = Path.Combine(contentPath, "Images", "User");

            if (!Directory.Exists(pathBuilt))
            {
                Directory.CreateDirectory(pathBuilt);
            }

            string filePath = Path.Combine(pathBuilt, outputFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return outputFileName;
        }
    }
}
