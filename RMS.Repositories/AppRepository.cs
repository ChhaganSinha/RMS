using RMS.DataContext;
using RMS.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Threading.Tasks.Dataflow;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace RMS.Repositories
{
    public class AppRepository : BaseRepository, IAppRepository
    {
        public AppDbContext AppDbCxt { get; set; }

        public AppRepository(ILogger<AppRepository> logger, AppDbContext appContext) : base(logger)
        {
            AppDbCxt = appContext;
        }

        #region Details
        public async Task<Details> GetDetailsById(int id)
        {
            Details result = null;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            result = AppDbCxt.Details.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Details>> GetAllDetails()
        {
            IEnumerable<Details> result = null;

            result = AppDbCxt.Details.ToList();
            return result;
        }
        public async Task<Details> UpsertDetails(Details details)
        {
            Details result = null;

            if (details == null)
                throw new ArgumentNullException("Invalid Details data");

            if (details.Id > 0)
            {


                AppDbCxt.Details.Update(details);

            }
            else
            {
                AppDbCxt.Details.Add(details);
            }

            AppDbCxt.SaveChanges();

            return details;
        }
        #endregion

        #region Room Section
        public async Task<RoomCategories> GetRoomCategoryById(int id)
        {
            RoomCategories result = null;

#pragma warning disable CS8600
             result =  AppDbCxt.RoomCategories.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<RoomCategories>> GetAllRoomCategory()
        {
            IEnumerable<RoomCategories> result = null;

            result = AppDbCxt.RoomCategories.ToList();
            return result;
        }
        public async Task<ApiResponse<RoomCategories>> UpsertRoomCategory(RoomCategories data)
        {
            var result = new ApiResponse<RoomCategories>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Room Categories data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.RoomCategories.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.RoomCategories.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.RoomCategories.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Room Category not found!";
                    return result;
                }

                AppDbCxt.RoomCategories.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess= false;
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<RoomFacilities> GetRoomFacilityById(int id)
        {
            RoomFacilities result = null;

#pragma warning disable CS8600
            result = AppDbCxt.RoomFacilities.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<RoomFacilities>> GetAllRoomFacility()
        {
            IEnumerable<RoomFacilities> result = null;

            result = AppDbCxt.RoomFacilities.ToList();
            return result;
        }
        public async Task<ApiResponse<RoomFacilities>> UpsertRoomFacility(RoomFacilities data)
        {
            var result = new ApiResponse<RoomFacilities>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Room Facility data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.RoomFacilities.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.RoomFacilities.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.RoomFacilities.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Room Facility not found!";
                    return result;
                }

                AppDbCxt.RoomFacilities.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<bool> UpsertRoomFacilitiesMapping(Dictionary<int, List<int>> dict)
        {
            foreach (var kvp in dict)
            {
                var roomId = kvp.Key;
                var facilityId = kvp.Value;

                var existingfacilityIds = await AppDbCxt.RoomFacilitiesMapping
                    .Where(o => o.RoomId == roomId)
                    .Select(o => o.FacilityId)
                    .ToListAsync();

                var facilityIdsToAdd = facilityId.Except(existingfacilityIds);
                var facilityIdsToRemove = existingfacilityIds.Except(facilityId);
                var facilityIdsToKeep = facilityId.Intersect(existingfacilityIds);

                if (facilityIdsToRemove.Any())
                {
                    var mappingsToRemove = await AppDbCxt.RoomFacilitiesMapping
                        .Where(tcm => tcm.RoomId == roomId && facilityIdsToRemove.Contains(tcm.FacilityId))
                        .ToListAsync();
                    AppDbCxt.RemoveRange(mappingsToRemove);
                }

                if (facilityIdsToAdd.Any())
                {
                    var mappingsToAdd = facilityIdsToAdd.Select(c => new RoomFacilitiesMapping
                    {
                        RoomId = roomId,
                        FacilityId = c
                    });
                    AppDbCxt.AddRange(mappingsToAdd);
                }

                await AppDbCxt.SaveChangesAsync();
            }

            return true;
        }

        public async Task<List<RoomFacilitiesMapping>> GetFacilitiesMappingByRoomId(int id)
        {
            var dataMapping = AppDbCxt.RoomFacilitiesMapping.Where(o => o.RoomId == id);
            return dataMapping.ToList();
        }

        public async Task<Room> GetRoomById(int id)
        {
            Room result = null;

#pragma warning disable CS8600
            result = AppDbCxt.Room.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            IEnumerable<Room> result = null;

            result = AppDbCxt.Room.ToList();
            return result;
        }
        public async Task<ApiResponse<Room>> UpsertRoom(Room data)
        {
            var result = new ApiResponse<Room>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Room data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.Room.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.Room.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.Room.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Room not found!";
                    return result;
                }

                AppDbCxt.Room.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
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
            EmployeeDesignation result = null;

#pragma warning disable CS8600
            result = AppDbCxt.EmployeeDesignation.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<EmployeeDesignation>> GetAllEmployeeDesignation()
        {
            IEnumerable<EmployeeDesignation> result = null;

            result = AppDbCxt.EmployeeDesignation.ToList();
            return result;
        }
        public async Task<ApiResponse<EmployeeDesignation>> UpsertEmployeeDesignation(EmployeeDesignation data)
        {
            var result = new ApiResponse<EmployeeDesignation>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Room Categories data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.EmployeeDesignation.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.EmployeeDesignation.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.EmployeeDesignation.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Room Category not found!";
                    return result;
                }

                AppDbCxt.EmployeeDesignation.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
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
            EmployeeDepartment result = null;

#pragma warning disable CS8600
            result = AppDbCxt.EmployeeDepartment.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<EmployeeDepartment>> GetAllEmployeeDepartment()
        {
            IEnumerable<EmployeeDepartment> result = null;

            result = AppDbCxt.EmployeeDepartment.ToList();
            return result;
        }
        public async Task<ApiResponse<EmployeeDepartment>> UpsertEmployeeDepartment(EmployeeDepartment data)
        {
            var result = new ApiResponse<EmployeeDepartment>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Employee Department data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.EmployeeDepartment.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.EmployeeDepartment.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.EmployeeDepartment.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Room Category not found!";
                    return result;
                }

                AppDbCxt.EmployeeDepartment.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
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
            Employee result = null;

#pragma warning disable CS8600
            result = AppDbCxt.Employee.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            IEnumerable<Employee> result = null;

            result = AppDbCxt.Employee.ToList();
            return result;
        }
        public async Task<ApiResponse<Employee>> UpsertEmployee(Employee data)
        {
            var result = new ApiResponse<Employee>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Employee data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.Employee.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.Employee.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.Employee.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Employee not found!";
                    return result;
                }

                AppDbCxt.Employee.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
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
            HallCategories result = null;

#pragma warning disable CS8600
            result = AppDbCxt.HallCategories.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<HallCategories>> GetAllHallCategory()
        {
            IEnumerable<HallCategories> result = null;

            result = AppDbCxt.HallCategories.ToList();
            return result;
        }
        public async Task<ApiResponse<HallCategories>> UpsertHallCategory(HallCategories data)
        {
            var result = new ApiResponse<HallCategories>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Hall Categories data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.HallCategories.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.HallCategories.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.HallCategories.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Hall Category not found!";
                    return result;
                }

                AppDbCxt.HallCategories.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
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
            HallFacilities result = null;

#pragma warning disable CS8600
            result = AppDbCxt.HallFacilities.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<HallFacilities>> GetAllHallFacility()
        {
            IEnumerable<HallFacilities> result = null;

            result = AppDbCxt.HallFacilities.ToList();
            return result;
        }
        public async Task<ApiResponse<HallFacilities>> UpsertHallFacility(HallFacilities data)
        {
            var result = new ApiResponse<HallFacilities>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Hall Facility data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.HallFacilities.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.HallFacilities.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.HallFacilities.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Hall Facility not found!";
                    return result;
                }

                AppDbCxt.HallFacilities.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        #endregion

        #region Attendence  Section

        #endregion



        #region Product Section
        public async Task<ProductCategories> GetProductCategoryById(int id)
        {
            ProductCategories result = null;

#pragma warning disable CS8600
            result = AppDbCxt.ProductCategories.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ProductCategories>> GetAllProductCategory()
        {
            IEnumerable<ProductCategories> result = null;

            result = AppDbCxt.ProductCategories.ToList();
            return result;
        }
        public async Task<ApiResponse<ProductCategories>> UpsertProductCategory(ProductCategories data)
        {
            var result = new ApiResponse<ProductCategories>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Product Categories data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.ProductCategories.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.ProductCategories.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                AppDbCxt.SaveChanges();
                result.IsSuccess = true;
                result.Result = data;
                return result;
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
                var existing = AppDbCxt.ProductCategories.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Product Category not found!";
                    return result;
                }

                AppDbCxt.ProductCategories.Remove(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Deleted!";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        #endregion
    }
}
