﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RMS.Client.Services.Contracts;
using RMS.Dto.Auth;
using RMS.Dto.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RMS.Client.Services.Implementations
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;

        public AuthorizeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Login(LoginParameters loginParameters)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/Login", loginParameters);
            if (result.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/Authorize/Logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterParameters registerParameters)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/Register", registerParameters);
            if (result.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<UserInfo> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserInfo>("api/Authorize/UserInfo");
        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<UserViewModel>>("api/Authorize/GetUsers");
        }

        public async Task UpdateUserRole(UserViewModel userViewModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/UpdateUserRole", userViewModel);
            if (result.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<int> GetUserCount()
        {
            var result = await _httpClient.GetAsync("api/Authorize/UserCount");
            result.EnsureSuccessStatusCode();

            var responseContent = await result.Content.ReadAsStringAsync();
            var countObject = JsonSerializer.Deserialize<Dictionary<string, int>>(responseContent);
            if (countObject != null && countObject.TryGetValue("count", out int count))
            {
                return count;
            }

            throw new Exception("Invalid response format");
        }

        public async Task<List<RoleViewModel>> GetRoles()
        {
            var result = await _httpClient.GetAsync("api/Authorize/GetRoles");
            result.EnsureSuccessStatusCode();

            var responseContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine("Response Content:");
            Console.WriteLine(responseContent); // Log the JSON response for debugging

            try
            {
                var roles = JsonSerializer.Deserialize<List<RoleViewModel>>(responseContent);
                return roles;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing roles: {ex.Message}");
                throw; // Rethrow the exception or handle it accordingly
            }
        }



        public async Task ChangePassword(ResetPassword resetPassword)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/ChangePassword", resetPassword);
            if (result.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception(await result.Content.ReadAsStringAsync());

            result.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserDetails(UserDetailsUpdateParameters updateParameters)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("api/Authorize/UpdateUserDetails", updateParameters);
                if (result.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception(await result.Content.ReadAsStringAsync());

                result.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user details: {ex.Message}");
            }
        }

        public async Task RequestPasswordResetByEmail(ResetPasswordByAdmin Parameters)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("api/Authorize/RequestPasswordResetByEmail", Parameters);
                if (result.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception(await result.Content.ReadAsStringAsync());

                result.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to reset the password: {ex.Message}");
            }
        }

        public async Task<(bool, string)> ForgetPassword(ForgetPasswordRequest param)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/forgetpassword", param);

            if (result.IsSuccessStatusCode)
            {
                return (true, "Success");
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorMessage = await result.Content.ReadAsStringAsync();
                Console.WriteLine(errorMessage);
                return (false, errorMessage);
            }
            else
            {
                return (false, "Unexpected error occurred.");
            }
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest param)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/resetpassword", param);
            result.EnsureSuccessStatusCode();
            return result.IsSuccessStatusCode;
        }


        public async Task<bool> HasPermission(string permission)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Authorize/GetUserPermissions", new { Permission = permission });
            response.EnsureSuccessStatusCode();
            var hasPermission = await response.Content.ReadFromJsonAsync<bool>();
            return hasPermission;
        }




    }
}
