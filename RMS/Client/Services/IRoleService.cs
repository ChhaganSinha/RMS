using RMS.Dto.RBAC;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoleService
{
    Task<List<RoleViewModel>> GetRoles();
    Task CreateRole(string roleName);
    Task AssignPermission(string roleName, string selectedPermission, List<PagePermissionViewModel> pagePermissions);
}
