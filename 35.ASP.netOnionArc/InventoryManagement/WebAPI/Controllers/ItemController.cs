using Infrastructure.Services.CustomServices.ItemServices;
using InfrastructureLayer.Service.CustomServices.CategoryServices;
using InfrastructureLayer.Service.CustomServices.SupplierServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
