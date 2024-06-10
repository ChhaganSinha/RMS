﻿
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using RMS.Dto;
using RMS.Client.Client;
using RMS.Dto.Dashboard;
using RMS.Dto.Auth;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using System;

namespace RMS.Client.Client
{
    public class AppClient : BaseHttpClient
    {
        public AppClient(ILogger<AppClient> logger, HttpClient httpClient) : base(logger, httpClient)
        {

        }

        #region Details
        public async Task<Details> GetDetailsById(int id)
        {
            Details details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/details/{id}");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<Details>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }
        public async Task<IEnumerable<Details>> GetAllDetails()
        {
            IEnumerable<Details> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-details");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<Details>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<Details> UpsertDetailsAsync(Details details)
        {

            Details result = null;

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertDetails", details);

                res.EnsureSuccessStatusCode();

                result = await res.Content.ReadFromJsonAsync<Details>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return result;

        }
        #endregion

        #region Room Section

        public async Task<RoomCategories> GetRoomCategoryById(int id)
        {
            RoomCategories data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/RoomCategory/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<RoomCategories>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<RoomCategories>> GetAllRoomCategory()
        {
            IEnumerable<RoomCategories> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-room-category");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<RoomCategories>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<RoomCategories>> UpsertRoomCategoryAsync(RoomCategories data)
        {
            var result = new ApiResponse<RoomCategories>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertRoomCategory", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<RoomCategories>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }



        }
        public async Task<ApiResponse<RoomCategories>> DeleteRoomCategory(int id)
        {
            var result = new ApiResponse<RoomCategories>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteRoomCategory/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<RoomCategories>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }




        public async Task<RoomFacilities> GetRoomFacilityById(int id)
        {
            RoomFacilities data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/RoomFacility/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<RoomFacilities>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<RoomFacilities>> GetAllRoomFacility()
        {
            IEnumerable<RoomFacilities> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-room-facility");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<RoomFacilities>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<bool> UpsertRoomFacilitiesMapping(Dictionary<int, List<int>> dict)
        {
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertRoomFacilitiesMapping", dict);
                res.EnsureSuccessStatusCode();

                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

        }

        public async Task<List<RoomFacilitiesMapping>> GetFacilitiesMappingByRoomId(int id)
        {
            List<RoomFacilitiesMapping> Trainingcampaign = new();
            try
            {
                var res = await HttpClient.GetAsync($"api/App/GetFacilitiesMappingByRoomId/{id}");

                res.EnsureSuccessStatusCode();

                Trainingcampaign = await res.Content.ReadFromJsonAsync<List<RoomFacilitiesMapping>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }
            return Trainingcampaign;
        }


        public async Task<ApiResponse<RoomFacilities>> UpsertRoomFacilityAsync(RoomFacilities data)
        {
            var result = new ApiResponse<RoomFacilities>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertRoomFacility", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<RoomFacilities>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<RoomFacilities>> DeleteRoomFacility(int id)
        {
            var result = new ApiResponse<RoomFacilities>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteRoomFacility/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<RoomFacilities>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }


        public async Task<Room> GetRoomById(int id)
        {
            Room data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/Room/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<Room>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            IEnumerable<Room> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-room");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<Room>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<Room>> UpsertRoomAsync(Room data)
        {
            var result = new ApiResponse<Room>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertRoom", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<Room>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<Room>> DeleteRoom(int id)
        {
            var result = new ApiResponse<Room>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteRoom/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<Room>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }
        #endregion
        #region Hall Section

        public async Task<HallCategories> GetHallCategoryById(int id)
        {
            HallCategories data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/HallCategory/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<HallCategories>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<HallCategories>> GetAllHallCategory()
        {
            IEnumerable<HallCategories> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-hall-category");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<HallCategories>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<HallCategories>> UpsertHallCategoryAsync(HallCategories data)
        {
            var result = new ApiResponse<HallCategories>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertHallCategory", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<HallCategories>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<HallCategories>> DeleteHallCategory(int id)
        {
            var result = new ApiResponse<HallCategories>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteHallCategory/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<HallCategories>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }




        public async Task<HallFacilities> GetHallFacilityById(int id)
        {
            HallFacilities data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/HallFacility/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<HallFacilities>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<HallFacilities>> GetAllHallFacility()
        {
            IEnumerable<HallFacilities> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-hall-facility");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<HallFacilities>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<HallFacilities>> UpsertHallFacilityAsync(HallFacilities data)
        {
            var result = new ApiResponse<HallFacilities>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertHallFacility", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<HallFacilities>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<HallFacilities>> DeleteHallFacility(int id)
        {
            var result = new ApiResponse<HallFacilities>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteHallFacility/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<HallFacilities>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }
        #endregion
        #region Employee Section
        public async Task<EmployeeDesignation> GetEmployeeDesignationById(int id)
        {
            EmployeeDesignation data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/EmployeeDesignation/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<EmployeeDesignation>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<EmployeeDesignation>> GetAllEmployeeDesignation()
        {
            IEnumerable<EmployeeDesignation> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-EmployeeDesignation");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<EmployeeDesignation>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<EmployeeDesignation>> UpsertEmployeeDesignationAsync(EmployeeDesignation data)
        {
            var result = new ApiResponse<EmployeeDesignation>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertEmployeeDesignation", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<EmployeeDesignation>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<EmployeeDesignation>> DeleteEmployeeDesignation(int id)
        {
            var result = new ApiResponse<EmployeeDesignation>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteEmployeeDesignation/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<EmployeeDesignation>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }



        public async Task<EmployeeDepartment> GetEmployeeDepartmentById(int id)
        {
            EmployeeDepartment data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/EmployeeDepartment/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<EmployeeDepartment>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<EmployeeDepartment>> GetAllEmployeeDepartment()
        {
            IEnumerable<EmployeeDepartment> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-EmployeeDepartment");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<EmployeeDepartment>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<EmployeeDepartment>> UpsertEmployeeDepartmentAsync(EmployeeDepartment data)
        {
            var result = new ApiResponse<EmployeeDepartment>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertEmployeeDepartment", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<EmployeeDepartment>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<EmployeeDepartment>> DeleteEmployeeDepartment(int id)
        {
            var result = new ApiResponse<EmployeeDepartment>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteEmployeeDepartment/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<EmployeeDepartment>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }


        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/Employee/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<Employee>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            IEnumerable<Employee> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-Employee");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<Employee>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<Employee>> UpsertEmployeeAsync(Employee data)
        {
            var result = new ApiResponse<Employee>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertEmployee", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<Employee>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<Employee>> DeleteEmployee(int id)
        {
            var result = new ApiResponse<Employee>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteEmployee/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<Employee>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }
        #endregion


        #region Product Section

        public async Task<ProductCategories> GetProductCategoryById(int id)
        {
            ProductCategories data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/ProductCategory/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<ProductCategories>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<ProductCategories>> GetAllProductCategory()
        {
            IEnumerable<ProductCategories> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-product-category");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<ProductCategories>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<ProductCategories>> UpsertProductCategoryAsync(ProductCategories data)
        {
            var result = new ApiResponse<ProductCategories>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertProductCategory", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<ProductCategories>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }



        }
        public async Task<ApiResponse<ProductCategories>> DeleteProductCategory(int id)
        {
            var result = new ApiResponse<ProductCategories>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteProductCategory/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<ProductCategories>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }

        }




        public async Task<UnitNames> GetUnitNamesById(int id)
        {
            UnitNames data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/UnitNames/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<UnitNames>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<UnitNames>> GetAllUnitNames()
        {
            IEnumerable<UnitNames> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-unit-names");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<UnitNames>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<UnitNames>> UpsertUnitNamesAsync(UnitNames data)
        {
            var result = new ApiResponse<UnitNames>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertUnitNames", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<UnitNames>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }



        }
        public async Task<ApiResponse<UnitNames>> DeleteUnitNames(int id)
        {
            var result = new ApiResponse<UnitNames>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteUnitNames/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<UnitNames>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }

        }



        public async Task<ProductList> GetProductListById(int id)
        {
            ProductList data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/ProductList/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<ProductList>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<ProductList>> GetAllProductList()
        {
            IEnumerable<ProductList> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-ProductList");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<ProductList>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<ProductList>> UpsertProductListAsync(ProductList data)
        {
            var result = new ApiResponse<ProductList>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertProductList", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<ProductList>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<ProductList>> DeleteProductList(int id)
        {
            var result = new ApiResponse<ProductList>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteProductList/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<ProductList>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }



        public async Task<SupplierList> GetSupplierListById(int id)
        {
            SupplierList data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/SupplierList/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<SupplierList>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<SupplierList>> GetAllSupplierList()
        {
            IEnumerable<SupplierList> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-supplier-list");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<SupplierList>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<SupplierList>> UpsertSupplierListAsync(SupplierList data)
        {
            var result = new ApiResponse<SupplierList>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertSupplierList", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<SupplierList>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }



        }
        public async Task<ApiResponse<SupplierList>> DeleteSupplierList(int id)
        {
            var result = new ApiResponse<SupplierList>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteSupplierList/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<SupplierList>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }

        }




        public async Task<DestroyedProducts> GetDestroyedProductsById(int id)
        {
            DestroyedProducts data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/DestroyedProducts/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<DestroyedProducts>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<DestroyedProducts>> GetAllDestroyedProducts()
        {
            IEnumerable<DestroyedProducts> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-DestroyedProducts");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<DestroyedProducts>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<DestroyedProducts>> UpsertDestroyedProductsAsync(DestroyedProducts data)
        {
            var result = new ApiResponse<DestroyedProducts>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertDestroyedProducts", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<DestroyedProducts>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<DestroyedProducts>> DeleteDestroyedProducts(int id)
        {
            var result = new ApiResponse<DestroyedProducts>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteDestroyedProducts/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<DestroyedProducts>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }





        /* public async Task<SaleProducts> GetSaleProductsById(int id)
         {
             SaleProducts data = null;
             try
             {
                 var res = await HttpClient.GetAsync($"api/App/SaleProducts/{id}");

                 res.EnsureSuccessStatusCode();

                 data = await res.Content.ReadFromJsonAsync<SaleProducts>();

             }
             catch (Exception ex)
             {
                 Logger.LogCritical(ex, ex.Message);
                 throw;
             }

             return data;
         }*/

        public async Task<SaleProducts> GetSaleProductsById(int id)
        {
            SaleProducts data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/SaleProducts/{id}");
                res.EnsureSuccessStatusCode();

                // Log the raw response content
                var rawContent = await res.Content.ReadAsStringAsync();
                Logger.LogInformation($"Response Content: {rawContent}");

                // Deserialize the content
                data = JsonSerializer.Deserialize<SaleProducts>(rawContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }

        public async Task<IEnumerable<SaleProducts>> GetAllSaleProducts()
        {
            IEnumerable<SaleProducts> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-SaleProducts");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<SaleProducts>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<SaleProducts>> UpsertSaleProductsAsync(SaleProducts data)
        {
            var result = new ApiResponse<SaleProducts>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertSaleProducts", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<SaleProducts>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<SaleProducts>> DeleteSaleProducts(int id)
        {
            var result = new ApiResponse<SaleProducts>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteSaleProducts/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<SaleProducts>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }




        public async Task<PurchaseItem> GetPurchaseItemById(int id)
        {
            PurchaseItem data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/PurchaseItem/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<PurchaseItem>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<PurchaseItem>> GetAllPurchaseItem()
        {
            IEnumerable<PurchaseItem> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-PurchaseItem");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<PurchaseItem>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<PurchaseItem>> UpsertPurchaseItemAsync(PurchaseItem data)
        {
            var result = new ApiResponse<PurchaseItem>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertPurchaseItem", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<PurchaseItem>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<PurchaseItem>> DeletePurchaseItem(int id)
        {
            var result = new ApiResponse<PurchaseItem>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeletePurchaseItem/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<PurchaseItem>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }
        #endregion


        #region HouseKeeping


        public async Task<CheckList> GetCheckListById(int id)
        {
            CheckList data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/CheckList/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<CheckList>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<CheckList>> GetAllCheckList()
        {
            IEnumerable<CheckList> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-CheckList");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<CheckList>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<CheckList>> UpsertCheckListAsync(CheckList data)
        {
            var result = new ApiResponse<CheckList>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertCheckList", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<CheckList>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<CheckList>> DeleteCheckList(int id)
        {
            var result = new ApiResponse<CheckList>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteCheckList/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<CheckList>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }



        public async Task<RoomCleaning> GetRoomCleaningById(int id)
        {
            RoomCleaning data = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/RoomCleaning/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<RoomCleaning>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
        public async Task<IEnumerable<RoomCleaning>> GetAllRoomCleaning()
        {
            IEnumerable<RoomCleaning> details = null;
            try
            {
                var res = await HttpClient.GetAsync($"api/App/all-RoomCleaning");

                res.EnsureSuccessStatusCode();

                details = await res.Content.ReadFromJsonAsync<IEnumerable<RoomCleaning>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return details;
        }

        public async Task<ApiResponse<RoomCleaning>> UpsertRoomCleaningAsync(RoomCleaning data)
        {
            var result = new ApiResponse<RoomCleaning>();

            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/UpsertRoomCleaning", data);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<RoomCleaning>>();
                return json;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }


        }
        public async Task<ApiResponse<RoomCleaning>> DeleteRoomCleaning(int id)
        {
            var result = new ApiResponse<RoomCleaning>();
            try
            {
                var res = await HttpClient.PostAsJsonAsync($"api/App/DeleteRoomCleaning/{id}", new { });
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadFromJsonAsync<ApiResponse<RoomCleaning>>();
                return json;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        #endregion


        public async Task<List<ItemDto>> GetPurchaseItemListById(int id)
        {
           List<ItemDto> data = new();
            try
            {
                var res = await HttpClient.GetAsync($"api/App/PurchaseItemList/{id}");

                res.EnsureSuccessStatusCode();

                data = await res.Content.ReadFromJsonAsync<List<ItemDto>>();

            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }

            return data;
        }
    }
}
