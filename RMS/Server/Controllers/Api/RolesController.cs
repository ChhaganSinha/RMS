using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using RMS.DataContext.Models;
using RMS.Dto.RBAC;

namespace RMS.Server.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await Task.Run(() => _roleManager.Roles.ToList());
            var roleViewModels = roles.Select(r => new RoleViewModel { Name = r.Name }).ToList();
            return Ok(roleViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var role = new ApplicationRole { Name = request.Name };
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }
            return Ok();
        }

        [HttpPost("assign-permission")]
        public async Task<IActionResult> AssignPermission([FromBody] AssignPermissionRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            // Handle permission assignment logic here.

            return Ok();
        }

        public class CreateRoleRequest
        {
            public string Name { get; set; }
        }

        public class AssignPermissionRequest
        {
            public string RoleName { get; set; }
            public string Permission { get; set; }
        }
    }
}
