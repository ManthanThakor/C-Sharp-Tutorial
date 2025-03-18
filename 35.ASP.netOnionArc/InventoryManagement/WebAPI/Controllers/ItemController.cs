using Domain.Models;
using Domain.ViewModels;
using Infrastructure.Services.CustomServices.ItemServices;
using InfrastructureLayer.Service.CustomServices.CategoryServices;
using InfrastructureLayer.Service.CustomServices.SupplierServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Text.RegularExpressions;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemService _itemServices;
        private readonly ISupplierService _supplierServices;
        private readonly ICategoryService _categoryServices;
        private readonly IWebHostEnvironment _environment;
        public ItemController(ILogger<ItemController> logger, IItemService itemServices, ISupplierService supplierService, ICategoryService categoryServices, IWebHostEnvironment environment)
        {
            _logger = logger;
            _itemServices = itemServices;
            _supplierServices = supplierService;
            _categoryServices = categoryServices;
            _environment = environment;
        }

        [HttpGet(nameof(GetAllItemBySupplier))]
        public async Task<ActionResult<ItemViewModel>> GetAllItemBySupplier(Guid Id)
        {

            ICollection<ItemViewModel> items = await _itemServices.GetAllItemByUser(Id);
            if (items == null)
                return BadRequest("No Records Found, Please Try Again After Sometime...!"); return Ok(items);
        }

        [HttpGet(nameof(GetAllItemByCustomer))]
        public async Task<ActionResult<ItemViewModel>> GetAllItemByCustomer(Guid Id)
        {
            ICollection<ItemViewModel> items = await _itemServices.GetAllItemByUser(Id);
            if (items.ToList().Count() == 0)
                return BadRequest("Customer id is Not Valid, Please Enter Valid Customer Details...!");
            return Ok(items);
        }


        [HttpGet(nameof(GetItem))]
        public async Task<ActionResult<ItemViewModel>> GetItem(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var result = await _itemServices.Get(Id);
                if (result == null)
                {
                    return BadRequest("No Records Found, Please Check the Id and Try Again Later...!");
                }
                return Ok(result);
            }
            else
            {
                return NotFound("Invalid Id Provided, Please Enter a Valid Id and Try Again...!");

            }
        }


        [HttpPost(nameof(AddSupplierItem))]
        public async Task<IActionResult> AddSupplierItem([FromForm] ItemInsertModel itemModel)
        {

            if (ModelState.IsValid)
            {
                User supplier = await _supplierServices.Find(x => x.Id == itemModel.UserId);
                if (supplier != null)
                {
                    var checkItem = await _itemServices.Find(x => x.ItemCode == itemModel.ItemCode);

                    if (checkItem != null)
                    {
                        return BadRequest("Item already Exists with the ItemCode: " + itemModel.ItemCode + ", Plz verify the item code");
                    }
                    else
                    {
                        var checkItemName = await _itemServices.Find(x => x.ItemName == itemModel.ItemName);
                        if (checkItemName != null)
                            return BadRequest("Item already Exists With the ItemName:" + itemModel.ItemName + ", Plz verify the ItemName");
                    }

                    var category = await _categoryServices.Get(itemModel.CategoryId);
                    if (category == null)
                    {
                        return BadRequest("Category Not Found, Please Provide Valid Category Information and Try Again later");
                    }

                    var photo = await UploadPhoto(itemModel.ItemImage, itemModel.ItemName);
                    var result = await _itemServices.Insert(itemModel, photo);
                    if (result == true)
                    {
                        return Ok("Item Inserted Successfully");
                    }
                    else
                    {
                        return BadRequest("Something Went wrong on our end , plz try again later ");
                    }
                }
                else
                {
                    return BadRequest("Unauthorized Supplier, Please Verify the Information Provided and Try Again.");
                }
            }
            else
            {
                _logger.LogWarning("Invalid Supplier Infromation Provided, Please Verigy it and Try Again...!"); return BadRequest("Invalid Supplier Infromation Provided, Please Verigy it and Try Again...!");
            }
        }


        private async Task<string> UploadPhoto(IFormFile file, string Id)
        {
            string fileName;
            try
            {
                _logger.LogInformation("Started uploading Item Image...1");
                string contentPath = this._environment.ContentRootPath;
                var extension = "," + file.FileName.Split('.')[^1];
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    fileName = Id.ToLower() + extension;
                    string outputFileName = Regex.Replace(fileName, @"[^0-9a-zA-Z._]+", "");
                    var pathBuilt = Path.Combine(contentPath, "Images\\Item");

                    if (!Directory.Exists(pathBuilt))
                    {
                        Directory.CreateDirectory(pathBuilt);
                    }
                    var path = Path.Combine(contentPath, "Images\\Item", outputFileName);
                    Console.WriteLine(path);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                    }
                    _logger.LogInformation("Successfully uploaded Item Image with Name" + outputFileName); 
                 return outputFileName;
                }
                else
                {
                    return "";
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Error while uploaded Item Image" + ex.StackTrace);
            }
            return ""; 
         }  




    

        [HttpPost(nameof(AddCustomerItem))]
        public async Task<IActionResult> AddCustomerItem([FromForm] ItemInsertModel itemModel)
        {
            if (ModelState.IsValid)
            {
                User customer = await _supplierServices.Find(x => x.Id == itemModel.UserId);
                if (customer != null)
                {
                    var checkItem = await _itemServices.Find(x => x.ItemCode == itemModel.ItemCode);

                    if (checkItem != null)
                    {
                        return BadRequest("Item already Exists with the ItemCode: " + itemModel.ItemCode + ", Plz verify the item code");
                    }
                    else
                    {
                        var checkItemName = await _itemServices.Find(x => x.ItemName == itemModel.ItemName);
                        if (checkItemName != null)
                            return BadRequest("Item already Exists With the ItemName:" + itemModel.ItemName + ", Plz verify the ItemName");
                    }

                    var category = await _categoryServices.Get(itemModel.CategoryId);
                    if (category == null)
                    {
                        return BadRequest("Category Not Found, Please Provide Valid Category Information and Try Again later");
                    }

                    var photo = await UploadPhoto(itemModel.ItemImage, itemModel.ItemName);
                    var result = await _itemServices.Insert(itemModel, photo);
                    if (result == true)
                    {
                        return Ok("Item Inserted Successfully");
                    }
                    else
                    {
                        return BadRequest("Something Went wrong on our end , plz try again later ");
                    }
                }
                else
                {
                    return BadRequest("Unauthorized Supplier, Please Verify the Information Provided and Try Again.");
                }
            }
            else
            {
                _logger.LogWarning("Invalid Supplier Infromation Provided, Please Verigy it and Try Again...!"); return BadRequest("Invalid Supplier Infromation Provided, Please Verigy it and Try Again...!");
            }
        }

        [HttpPut(nameof(EditItem))]
        public async Task<IActionResult> EditItem([FromForm] ItemUpdateModel itemModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid item data provided.");
                return BadRequest("Invalid item data provided.");
            }

            var existingItem = await _itemServices.Get(itemModel.Id);
            if (existingItem == null)
            {
                return NotFound("Item not found. Please check the Item ID and try again.");
            }

            var checkItemCode = await _itemServices.Find(x => x.ItemCode == itemModel.ItemCode && x.Id != itemModel.Id);
            if (checkItemCode != null)
            {
                return BadRequest("Item with the given ItemCode already exists. Please use a different ItemCode.");
            }

            var checkItemName = await _itemServices.Find(x => x.ItemName == itemModel.ItemName && x.Id != itemModel.Id);
            if (checkItemName != null)
            {
                return BadRequest("Item with the given ItemName already exists. Please use a different ItemName.");
            }



            if (itemModel.ItemImage == null)
            {
                var result = await _itemServices.Update(itemModel, null);
                if (result == true)
                {
                    _logger.LogInformation("Item Updated Successfully...!");
                    return Ok("Item Updated Successfully...!");

                }
                else
                {

                    _logger.LogWarning("Something Went Wrong On Our End, Please Try Again Later...!");
                    return BadRequest("Something Went Wrong On Our End, Please Try Again Later...!");
                }
            }
            else
            {
                var photo = await UploadPhoto(itemModel.ItemImage, itemModel.ItemName);
                 
                var result = await _itemServices.Update(itemModel, photo);
                if (result == true) 
                {
                    _logger.LogInformation("Item Updated Successfully...!");
                    return Ok("Item Updated Successfully...!");

                }
                else
                {

                    _logger.LogWarning("Something Went Wrong On Our End, Please Try Again Later...!");
                    return BadRequest("Something Went Wrong On Our End, Please Try Again Later...!");
                }
            }

         
        }


        [HttpDelete(nameof(DeleteItem))]
        public async Task<IActionResult> DeleteItem(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var result = await _itemServices.Delete(Id);
                if (result == true)
                {
                    return Ok("Item Deleted Successfully...!");
                }
                return BadRequest("Something Went Wrong on our End, Please Try Again Later...!");
            }
            else
            {
                return BadRequest("Invalid Id Provided, Please Enter a Valid Id and Try Again...!");

            }
        }
    }
}
