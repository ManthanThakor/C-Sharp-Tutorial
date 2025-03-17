using Domain.ViewModels;
using InfrastructureLayer.Service.CustomServices.UserTypeServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/user-types")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserTypeViewModel>>> GetAllUserTypes()
        {
            try
            {
                var userTypes = await _userTypeService.GetAll();
                return Ok(userTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserTypeViewModel>> GetUserTypeById(Guid id)
        {
            try
            {
                var userType = await _userTypeService.Get(id);
                if (userType == null)
                    return NotFound("UserType not found.");

                return Ok(userType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUserType([FromBody] UserTypeInsertModel model)
        {
            try
            {
                var result = await _userTypeService.Insert(model);
                if (!result)
                    return BadRequest("Failed to create UserType.");

                return Ok("UserType created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateUserType([FromBody] UserTypeUpdateModel model)
        {
            try
            {
                var result = await _userTypeService.Update(model);
                if (!result)
                    return BadRequest("Failed to update UserType.");

                return Ok("UserType updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult> DeleteUserType(Guid id)
        {
            try
            {
                var result = await _userTypeService.Delete(id);
                if (!result)
                    return NotFound("UserType not found or deletion failed.");

                return Ok("UserType deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
