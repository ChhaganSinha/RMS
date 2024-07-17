using Microsoft.AspNetCore.Http;
using RMS.Client.Services.Contracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class PermissionService
{
    private readonly HttpClient _httpClient;
    private readonly IAuthorizeApi _authorizeApi; // Corrected to use interface

    public PermissionService(HttpClient httpClient, IAuthorizeApi authorizeApi)
    {
        _httpClient = httpClient;
        _authorizeApi = authorizeApi;
    }

    public async Task<bool> HasPermission(string permission)
    {
        var response = await _authorizeApi.HasPermission(permission);
        return response;
    }
}
