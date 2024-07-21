using RMS.Dto.RBAC;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class RoleService : IRoleService
{
    private readonly HttpClient _httpClient;

    public RoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<RoleViewModel>> GetRoles()
    {
        return await _httpClient.GetFromJsonAsync<List<RoleViewModel>>("api/Authorize/GetRoles");
    }

    public async Task CreateRole(string roleName)
    {
        await _httpClient.PostAsJsonAsync("api/Authorize/CreateRole", new RoleViewModel { Name = roleName });
    }

    public async Task AssignPermission(string roleName, string selectedPermission, List<PagePermissionViewModel> pagePermissions)
    {
        var roleViewModel = new RoleViewModel
        {
            Name = roleName,
            SelectedPermission = selectedPermission,
            PagePermissions = pagePermissions
        };

        await _httpClient.PostAsJsonAsync("api/Authorize/AssignPermission", roleViewModel);
    }

    public async Task<List<RoleViewModel>> GetRolesWithPermissions()
    {
        return await _httpClient.GetFromJsonAsync<List<RoleViewModel>>("api/roles/with-permissions");
    }
}
