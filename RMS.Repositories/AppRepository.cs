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
using RMS.Dto.Enum;
using RMS.Dto.Dashboard;

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
            result = AppDbCxt.RoomCategories.FirstOrDefault(o => o.Id == id);
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
                result.IsSuccess = false;
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

        public async Task<ApiResponse<RoomCleaningAssignmentModel>> UpsertRoomCleaningAssignment(RoomCleaningAssignmentModel data)
        {
            var result = new ApiResponse<RoomCleaningAssignmentModel>();
            try
            {
                if (data == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Invalid Room Cleaning Assignment data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    // Update logic
                    var existingAssignment = await AppDbCxt.RoomCleaningAssignmentModel
                        .Include(r => r.SelectedRooms)
                        .FirstOrDefaultAsync(r => r.Id == data.Id);

                    if (existingAssignment != null)
                    {
                        // Update existing properties
                        existingAssignment.HouseKeeper = data.HouseKeeper;
                        existingAssignment.RoomType = data.RoomType;
                        existingAssignment.Status = RoomHallStatus.AssignedToClean.ToString();
                        existingAssignment.ModifiedBy = data.ModifiedBy;
                        existingAssignment.ModifiedOn = data.ModifiedOn;

                        // Clear and update the selected rooms
                        existingAssignment.SelectedRooms.Clear();
                        foreach (var roomModel in data.SelectedRooms)
                        {
                            roomModel.Status = RoomHallStatus.AssignedToClean.ToString();
                            existingAssignment.SelectedRooms.Add(roomModel);
                        }

                        AppDbCxt.RoomCleaningAssignmentModel.Update(existingAssignment);
                    }
                }
                else
                {
                    // Insert logic
                    data.CreatedBy = data.CreatedBy;
                    data.CreatedOn = data.CreatedOn;
                    data.Status = RoomHallStatus.AssignedToClean.ToString(); 

                    foreach (var roomModel in data.SelectedRooms)
                    {
                        roomModel.Status = RoomHallStatus.AssignedToClean.ToString(); 
                    }

                    AppDbCxt.RoomCleaningAssignmentModel.Add(data);
                }

                foreach (var roomBooking in data.SelectedRooms)
                {
                    var room = AppDbCxt.Room.FirstOrDefault(r => r.RoomNumber == roomBooking.RoomNo);
                    if (room != null)
                    {
                        room.Status = RoomHallStatus.AssignedToClean;
                        AppDbCxt.Room.Update(room);
                    }
                }

                /* foreach (var roomBooking in data.RoomBookings)
                 {
                     var room = AppDbCxt.Room.FirstOrDefault(r => r.Id == roomBooking.RoomId);
                     if (room != null) { room.Status = RoomHallStatus.Booked; AppDbCxt.Room.Update(room); }
                 }*/


                await AppDbCxt.SaveChangesAsync();

                result.IsSuccess = true;
                result.Result = data;
                result.Message = data.Id > 0 ? "Data Successfully Updated." : "Data Successfully Inserted.";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ApiResponse<RoomCleaningAssignmentModel>> DeleteRoomCleaningAssignmentModel(int id)
        {
            var result = new ApiResponse<RoomCleaningAssignmentModel>();
            try
            {
                var existing = AppDbCxt.RoomCleaningAssignmentModel.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Room Category not found!";
                    return result;
                }

                AppDbCxt.RoomCleaningAssignmentModel.Remove(existing);
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

        public async Task<RoomCleaningAssignmentModel> GetRoomCleaningAssignmentModelById(int id)
        {
            RoomCleaningAssignmentModel result = null;

#pragma warning disable CS8600
            result = AppDbCxt.RoomCleaningAssignmentModel.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
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

        #region Payrolls
        public async Task<AdvanceSalary> GetAdvanceSalaryById(int id)
        {
            AdvanceSalary result = null;

#pragma warning disable CS8600
            result = AppDbCxt.AdvanceSalary.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<AdvanceSalary>> GetAllAdvanceSalary()
        {
            IEnumerable<AdvanceSalary> result = null;

            result = AppDbCxt.AdvanceSalary.ToList();
            return result;
        }
        public async Task<ApiResponse<AdvanceSalary>> UpsertAdvanceSalary(AdvanceSalary data)
        {
            var result = new ApiResponse<AdvanceSalary>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    data.ModifiedDate = DateTime.Now;
                    AppDbCxt.AdvanceSalary.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    data.PaymentDate = DateTime.Now;
                    AppDbCxt.AdvanceSalary.Add(data);
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

        public async Task<ApiResponse<AdvanceSalary>> DeleteAdvanceSalary(int id)
        {
            var result = new ApiResponse<AdvanceSalary>();
            try
            {
                var existing = AppDbCxt.AdvanceSalary.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Advance Salary not found!";
                    return result;
                }

                AppDbCxt.AdvanceSalary.Remove(existing);
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


        public async Task<SalaryType> GetSalaryTypeById(int id)
        {
            SalaryType result = null;

#pragma warning disable CS8600
            result = AppDbCxt.SalaryType.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<SalaryType>> GetAllSalaryType()
        {
            IEnumerable<SalaryType> result = null;

            result = AppDbCxt.SalaryType.ToList();
            return result;
        }
        public async Task<ApiResponse<SalaryType>> UpsertSalaryType(SalaryType data)
        {
            var result = new ApiResponse<SalaryType>();
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
                    AppDbCxt.SalaryType.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.SalaryType.Add(data);
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

        public async Task<ApiResponse<SalaryType>> DeleteSalaryType(int id)
        {
            var result = new ApiResponse<SalaryType>();
            try
            {
                var existing = AppDbCxt.SalaryType.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Advance Salary not found!";
                    return result;
                }

                AppDbCxt.SalaryType.Remove(existing);
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


        public async Task<EmployeePayroll> GetEmployeePayrollById(int id)
        {
            EmployeePayroll result = null;

#pragma warning disable CS8600
            result = AppDbCxt.EmployeePayroll.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<EmployeePayroll>> GetAllEmployeePayroll()
        {
            IEnumerable<EmployeePayroll> result = null;

            result = AppDbCxt.EmployeePayroll.ToList();
            return result;
        }
        public async Task<ApiResponse<EmployeePayroll>> UpsertEmployeePayroll(EmployeePayroll data)
        {
            var result = new ApiResponse<EmployeePayroll>();
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
                    AppDbCxt.EmployeePayroll.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.EmployeePayroll.Add(data);
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

        public async Task<ApiResponse<EmployeePayroll>> GenerateSalaryAsync(EmployeePayroll data)
        {
            var result = new ApiResponse<EmployeePayroll>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid data!";
                    return result;
                }
                var advanceAmount = await AppDbCxt.AdvanceSalary.Where(o => o.EmployeeId == data.EmployeeId).Select(o => o.AdvanceAmount).FirstAsync();
                data.PayableSalary = data.NetSalary - advanceAmount;
                data.AdvanceAmount = advanceAmount;
                AppDbCxt.EmployeePayroll.Update(data);
                result.Message = "Salary Successfully Generated.";

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

        public async Task<ApiResponse<EmployeePayroll>> DeleteEmployeePayroll(int id)
        {
            var result = new ApiResponse<EmployeePayroll>();
            try
            {
                var existing = AppDbCxt.EmployeePayroll.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Advance Salary not found!";
                    return result;
                }

                AppDbCxt.EmployeePayroll.Remove(existing);
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

        public async Task<bool> UpsertHallFacilitiesMapping(Dictionary<int, List<int>> dict)
        {
            foreach (var kvp in dict)
            {
                var hallId = kvp.Key;
                var facilityId = kvp.Value;

                var existingfacilityIds = await AppDbCxt.HallFacilitiesMapping
                    .Where(o => o.HallId == hallId)
                    .Select(o => o.FacilityId)
                    .ToListAsync();

                var facilityIdsToAdd = facilityId.Except(existingfacilityIds);
                var facilityIdsToRemove = existingfacilityIds.Except(facilityId);
                var facilityIdsToKeep = facilityId.Intersect(existingfacilityIds);

                if (facilityIdsToRemove.Any())
                {
                    var mappingsToRemove = await AppDbCxt.HallFacilitiesMapping
                        .Where(tcm => tcm.HallId == hallId && facilityIdsToRemove.Contains(tcm.FacilityId))
                        .ToListAsync();
                    AppDbCxt.RemoveRange(mappingsToRemove);
                }

                if (facilityIdsToAdd.Any())
                {
                    var mappingsToAdd = facilityIdsToAdd.Select(c => new HallFacilitiesMapping
                    {
                        HallId = hallId,
                        FacilityId = c
                    });
                    AppDbCxt.AddRange(mappingsToAdd);
                }

                await AppDbCxt.SaveChangesAsync();
            }

            return true;
        }

        public async Task<List<HallFacilitiesMapping>> GetFacilitiesMappingByHallId(int id)
        {
            var dataMapping = AppDbCxt.HallFacilitiesMapping.Where(o => o.HallId == id);
            return dataMapping.ToList();
        }

        public async Task<Hall> GetHallById(int id)
        {
            Hall result = null;

#pragma warning disable CS8600
            result = AppDbCxt.Halls.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Hall>> GetAllHall()
        {
            IEnumerable<Hall> result = null;

            result = AppDbCxt.Halls.ToList();
            return result;
        }
        public async Task<ApiResponse<Hall>> UpsertHall(Hall data)
        {
            var result = new ApiResponse<Hall>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Hall data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.Halls.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.Halls.Add(data);
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

        public async Task<ApiResponse<Hall>> DeleteHall(int id)
        {
            var result = new ApiResponse<Hall>();
            try
            {
                var existing = AppDbCxt.Halls.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Hall not found!";
                    return result;
                }

                AppDbCxt.Halls.Remove(existing);
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
        public async Task<ApiResponse<EmployeeAttendance>> EmployeeCheckInAsync(EmployeeAttendance data)
        {
            var result = new ApiResponse<EmployeeAttendance>();
            try
            {
                if (data == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Invalid Employee data!";
                    return result;
                }

                var today = DateOnly.FromDateTime(DateTime.Now);
                //var existingAttendance = AppDbCxt.EmployeeAttendance
                //    .FirstOrDefault(o => o.EmployeeId == data.EmployeeId && o.Date == today);

                var existingAttendance = AppDbCxt.EmployeeAttendance
                    .FirstOrDefault(o => o.EmployeeId == data.EmployeeId);

                if (existingAttendance != null && existingAttendance.CheckIn != TimeOnly.MinValue)
                {
                    result.IsSuccess = false;
                    result.Message = "Employee has already checked in today.";
                    return result;
                }

                data.Date = today;
                data.CheckIn = TimeOnly.FromDateTime(DateTime.Now);
                AppDbCxt.EmployeeAttendance.Update(data);
                AppDbCxt.SaveChanges();

                result.IsSuccess = true;
                result.Message = "Successfully Checked In.";
                //result.Result = data;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ApiResponse<EmployeeAttendance>> EmployeeCheckOutAsync(EmployeeAttendance data)
        {
            var result = new ApiResponse<EmployeeAttendance>();
            try
            {
                if (data == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Invalid Employee data!";
                    return result;
                }

                var today = DateOnly.FromDateTime(DateTime.Now);
                var existingAttendance = AppDbCxt.EmployeeAttendance
                    .FirstOrDefault(o => o.EmployeeId == data.EmployeeId && o.Date == today);

                if (existingAttendance == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No check-in record found for today.";
                    return result;
                }

                existingAttendance.CheckOut = TimeOnly.FromDateTime(DateTime.Now);
                existingAttendance.StayTime = existingAttendance.CheckOut.ToTimeSpan() - existingAttendance.CheckIn.ToTimeSpan();
                AppDbCxt.Update(existingAttendance);
                AppDbCxt.SaveChanges();

                result.IsSuccess = true;
                result.Message = "Successfully Checked Out.";
                result.Result = existingAttendance;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ApiResponse<EmployeeAttendance>> UpdateEmployeeAttendance(EmployeeAttendance data)
        {
            var result = new ApiResponse<EmployeeAttendance>();
            try
            {
                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Employee data!";
                    return result;
                }

                var checkAttendance = AppDbCxt.EmployeeAttendance.Where(o => o.EmployeeId == data.EmployeeId).FirstOrDefault();
                if (checkAttendance != null)
                {
                    AppDbCxt.EmployeeAttendance.Update(data);
                    result.Message = "Data Successfully Updated.";
                    AppDbCxt.SaveChanges();
                    result.IsSuccess = true;
                    result.Result = data;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<IEnumerable<EmployeeAttendance>> GetAllEmployeeAttendance()
        {
            IEnumerable<EmployeeAttendance> result = null;

            result = AppDbCxt.EmployeeAttendance.ToList();
            return result;
        }
        #endregion

        #region Leave Section
        public async Task<LeaveType> GetLeaveTypeById(int id)
        {
            LeaveType result = null;

#pragma warning disable CS8600
            result = AppDbCxt.LeaveType.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<LeaveType>> GetAllLeaveType()
        {
            IEnumerable<LeaveType> result = null;

            result = AppDbCxt.LeaveType.ToList();
            return result;
        }
        public async Task<ApiResponse<LeaveType>> UpsertLeaveTypeAsync(LeaveType data)
        {
            var result = new ApiResponse<LeaveType>();
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
                    AppDbCxt.LeaveType.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.LeaveType.Add(data);
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

        public async Task<ApiResponse<LeaveType>> DeleteLeaveType(int id)
        {
            var result = new ApiResponse<LeaveType>();
            try
            {
                var existing = AppDbCxt.LeaveType.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Leave Type not found!";
                    return result;
                }

                AppDbCxt.LeaveType.Remove(existing);
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

        public async Task<Leave> GetLeaveById(int id)
        {
            Leave result = null;

#pragma warning disable CS8600
            result = AppDbCxt.Leave.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Leave>> GetAllLeave()
        {
            IEnumerable<Leave> result = null;

            result = AppDbCxt.Leave.ToList();
            return result;
        }
        public async Task<ApiResponse<Leave>> UpsertLeaveAsync(Leave data)
        {
            var result = new ApiResponse<Leave>();
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
                    AppDbCxt.Leave.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.Leave.Add(data);
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

        public async Task<ApiResponse<Leave>> DeleteLeave(int id)
        {
            var result = new ApiResponse<Leave>();
            try
            {
                var existing = AppDbCxt.Leave.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Leave Type not found!";
                    return result;
                }

                AppDbCxt.Leave.Remove(existing);
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

        public async Task<ApiResponse<Leave>> ApproveLeaveAsync(Leave data)
        {
            var result = new ApiResponse<Leave>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.Leave.Update(data);
                    result.Message = "Successfully Approved.";
                }
                else
                {
                    AppDbCxt.Leave.Add(data);
                    result.Message = "Successfully Approved.";
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




        public async Task<UnitNames> GetUnitNamesById(int id)
        {
            UnitNames result = null;

#pragma warning disable CS8600
            result = AppDbCxt.UnitNames.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<UnitNames>> GetAllUnitNames()
        {
            IEnumerable<UnitNames> result = null;

            result = AppDbCxt.UnitNames.ToList();
            return result;
        }
        public async Task<ApiResponse<UnitNames>> UpsertUnitNames(UnitNames data)
        {
            var result = new ApiResponse<UnitNames>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Unit Names data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.UnitNames.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.UnitNames.Add(data);
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

        public async Task<ApiResponse<UnitNames>> DeleteUnitNames(int id)
        {
            var result = new ApiResponse<UnitNames>();
            try
            {
                var existing = AppDbCxt.UnitNames.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Unit Names not found!";
                    return result;
                }

                AppDbCxt.UnitNames.Remove(existing);
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



        public async Task<ProductList> GetProductListById(int id)
        {
            ProductList result = null;

#pragma warning disable CS8600
            result = AppDbCxt.ProductList.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ProductList>> GetAllProductList()
        {
            IEnumerable<ProductList> result = null;

            result = AppDbCxt.ProductList.ToList();
            return result;
        }
        public async Task<ApiResponse<ProductList>> UpsertProductList(ProductList data)
        {
            var result = new ApiResponse<ProductList>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Product List data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.ProductList.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.ProductList.Add(data);
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

        public async Task<ApiResponse<ProductList>> DeleteProductList(int id)
        {
            var result = new ApiResponse<ProductList>();
            try
            {
                var existing = AppDbCxt.ProductList.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Produc tList not found!";
                    return result;
                }

                AppDbCxt.ProductList.Remove(existing);
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




        public async Task<SupplierList> GetSupplierListById(int id)
        {
            SupplierList result = null;

#pragma warning disable CS8600
            result = AppDbCxt.SupplierList.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<SupplierList>> GetAllSupplierList()
        {
            IEnumerable<SupplierList> result = null;

            result = AppDbCxt.SupplierList.ToList();
            return result;
        }
        public async Task<ApiResponse<SupplierList>> UpsertSupplierList(SupplierList data)
        {
            var result = new ApiResponse<SupplierList>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Supplier List data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.SupplierList.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.SupplierList.Add(data);
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

        public async Task<ApiResponse<SupplierList>> DeleteSupplierList(int id)
        {
            var result = new ApiResponse<SupplierList>();
            try
            {
                var existing = AppDbCxt.SupplierList.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Supplier List not found!";
                    return result;
                }

                AppDbCxt.SupplierList.Remove(existing);
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







        public async Task<DestroyedProducts> GetDestroyedProductsById(int id)
        {
            DestroyedProducts result = null;

#pragma warning disable CS8600
            result = AppDbCxt.DestroyedProducts.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<DestroyedProducts>> GetAllDestroyedProducts()
        {
            IEnumerable<DestroyedProducts> result = null;

            result = AppDbCxt.DestroyedProducts.ToList();
            return result;
        }
        public async Task<ApiResponse<DestroyedProducts>> UpsertDestroyedProducts(DestroyedProducts data)
        {
            var result = new ApiResponse<DestroyedProducts>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Destroyed Products data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.DestroyedProducts.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.DestroyedProducts.Add(data);
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

        public async Task<ApiResponse<DestroyedProducts>> DeleteDestroyedProducts(int id)
        {
            var result = new ApiResponse<DestroyedProducts>();
            try
            {
                var existing = AppDbCxt.DestroyedProducts.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "DestroyedProducts not found!";
                    return result;
                }

                AppDbCxt.DestroyedProducts.Remove(existing);
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




        public async Task<SaleProducts> GetSaleProductsById(int id)
        {
            SaleProducts result = null;

#pragma warning disable CS8600
            result = AppDbCxt.SaleProducts.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<SaleProducts>> GetAllSaleProducts()
        {
            IEnumerable<SaleProducts> result = null;

            result = AppDbCxt.SaleProducts.ToList();
            return result;
        }
        public async Task<ApiResponse<SaleProducts>> UpsertSaleProducts(SaleProducts data)
        {
            var result = new ApiResponse<SaleProducts>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Sale Products data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.SaleProducts.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.SaleProducts.Add(data);
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

        public async Task<ApiResponse<SaleProducts>> DeleteSaleProducts(int id)
        {
            var result = new ApiResponse<SaleProducts>();
            try
            {
                var existing = AppDbCxt.SaleProducts.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Sale Products not found!";
                    return result;
                }

                AppDbCxt.SaleProducts.Remove(existing);
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





        public async Task<PurchaseItem> GetPurchaseItemById(int id)
        {
            PurchaseItem result = null;

#pragma warning disable CS8600
            result = AppDbCxt.PurchaseItem.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PurchaseItem>> GetAllPurchaseItem()
        {
            IEnumerable<PurchaseItem> result = null;

            result = AppDbCxt.PurchaseItem.ToList();
            return result;
        }
        public async Task<ApiResponse<PurchaseItem>> UpsertPurchaseItem(PurchaseItem data)
        {
            var result = new ApiResponse<PurchaseItem>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid PurchaseItem data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.PurchaseItem.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.PurchaseItem.Add(data);
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

        public async Task<ApiResponse<PurchaseItem>> DeletePurchaseItem(int id)
        {
            var result = new ApiResponse<PurchaseItem>();
            try
            {
                var existing = AppDbCxt.PurchaseItem.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "PurchaseItem not found!";
                    return result;
                }

                AppDbCxt.PurchaseItem.Remove(existing);
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

        #region HouseKeeping
        public async Task<CheckList> GetCheckListById(int id)
        {
            CheckList result = null;

#pragma warning disable CS8600
            result = AppDbCxt.CheckList.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<CheckList>> GetAllCheckList()
        {
            IEnumerable<CheckList> result = null;

            result = AppDbCxt.CheckList.ToList();
            return result;
        }
        public async Task<ApiResponse<CheckList>> UpsertCheckList(CheckList data)
        {
            var result = new ApiResponse<CheckList>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid CheckList data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.CheckList.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.CheckList.Add(data);
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

        public async Task<ApiResponse<CheckList>> DeleteCheckList(int id)
        {
            var result = new ApiResponse<CheckList>();
            try
            {
                var existing = AppDbCxt.CheckList.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "CheckList not found!";
                    return result;
                }

                AppDbCxt.CheckList.Remove(existing);
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



        public async Task<RoomCleaning> GetRoomCleaningById(int id)
        {
            RoomCleaning result = null;

#pragma warning disable CS8600
            result = AppDbCxt.RoomCleaning.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<RoomCleaning>> GetAllRoomCleaning()
        {
            IEnumerable<RoomCleaning> result = null;

            result = AppDbCxt.RoomCleaning.ToList();
            return result;
        }
        public async Task<ApiResponse<RoomCleaning>> UpsertRoomCleaning(RoomCleaning data)
        {
            var result = new ApiResponse<RoomCleaning>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid RoomCleaning data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.RoomCleaning.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.RoomCleaning.Add(data);
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

        public async Task<ApiResponse<RoomCleaning>> DeleteRoomCleaning(int id)
        {
            var result = new ApiResponse<RoomCleaning>();
            try
            {
                var existing = AppDbCxt.RoomCleaning.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "RoomCleaning not found!";
                    return result;
                }

                AppDbCxt.RoomCleaning.Remove(existing);
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


        public async Task<List<ItemDto>> GetPurchaseItemListById(int id)
        {
            List<ItemDto> result = new();

#pragma warning disable CS8600
            result = AppDbCxt.ItemDto.Where(o => o.PurchaseItemId == id).ToList();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }
        #endregion

        #region Booking Section
        public async Task<BookingType> GetBookingTypeById(int id)
        {
            BookingType result = null;

#pragma warning disable CS8600
            result = AppDbCxt.BookingType.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<BookingType>> GetAllBookingType()
        {
            IEnumerable<BookingType> result = null;

            result = AppDbCxt.BookingType.ToList();
            return result;
        }
        public async Task<ApiResponse<BookingType>> UpsertBookingType(BookingType data)
        {
            var result = new ApiResponse<BookingType>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Booking Type data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.BookingType.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.BookingType.Add(data);
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

        public async Task<ApiResponse<BookingType>> DeleteBookingType(int id)
        {
            var result = new ApiResponse<BookingType>();
            try
            {
                var existing = AppDbCxt.BookingType.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Booking Type not found!";
                    return result;
                }

                AppDbCxt.BookingType.Remove(existing);
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


        public async Task<List<ReservationDetailsDto>> GetTodaysBookingsAsync()
        {
            try
            {
                var todaysCustomerInfo = await AppDbCxt.ReservationDetails.Include(o=>o.CustomerInfo)
                    .Where(r => r.CheckIn.Date == DateTime.Today.Date)
                   // .SelectMany(r => r.CustomerInfo)
                    .ToListAsync();

                //return todaysCustomerInfo.Select(ci => new CustomerInfoDto
                //{
                //    SL = ci.SL,
                //    Name = ci.Name,
                //    MobileNo = ci.MobileNo,
                //    Email = ci.Email
                //}).ToList();
                return todaysCustomerInfo;
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<ReservationDetailsDto>> GetNextDaysBookingsAsync()
        {


            try
            {
                var nextDaysCustomerInfo = await AppDbCxt.ReservationDetails.Include(o => o.CustomerInfo)
                    .Where(r => r.CheckIn.Date == DateTime.Today.AddDays(1))
                    
                    .ToListAsync();

                return nextDaysCustomerInfo;
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
                throw;
            }
        }



        public async Task<ReservationDetailsDto> GetReservationDetailsById(int id)
        {
            ReservationDetailsDto result = null;

#pragma warning disable CS8600
            result = AppDbCxt.ReservationDetails.Include(o => o.RoomBookings).Include(o => o.CustomerInfo).Include(o => o.PaymentDetails).Include(o => o.BillingDetails).FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ReservationDetailsDto>> GetAllReservationDetails()
        {
            IEnumerable<ReservationDetailsDto> result = null;

            result = AppDbCxt.ReservationDetails.ToList();
            return result;
        }
        public async Task<ApiResponse<ReservationDetailsDto>> UpsertReservationDetails(ReservationDetailsDto data)
        {
            var result = new ApiResponse<ReservationDetailsDto>();
            try
            {
                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Booking Type data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    data.Status = RoomHallStatus.Booked;
                    AppDbCxt.ReservationDetails.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    data.Status = RoomHallStatus.Booked;
                    AppDbCxt.ReservationDetails.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }
                // Save changes to ReservationDetails first
                await AppDbCxt.SaveChangesAsync();
                // Update room status to Booked for each room in RoomBookings
                foreach(var roomBooking in data.RoomBookings)
                {
                    var room = AppDbCxt.Room.FirstOrDefault(r => r.Id == roomBooking.RoomId);
                    if (room != null) { room.Status = RoomHallStatus.Booked; AppDbCxt.Room.Update(room); }
                }
      

                

                // Save changes to room status
                await AppDbCxt.SaveChangesAsync();

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


        public async Task<ApiResponse<ReservationDetailsDto>> DeleteReservationDetails(int id)
        {
            var result = new ApiResponse<ReservationDetailsDto>();
            try
            {
                var existing = AppDbCxt.ReservationDetails.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Booking Type not found!";
                    return result;
                }

                AppDbCxt.ReservationDetails.Remove(existing);
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

        public async Task<ApiResponse<ReservationDetailsDto>> CheckOutReservations(ReservationDetailsDto reservationDetailsDto)
        {
            var result = new ApiResponse<ReservationDetailsDto>();
            try
            {
                var existing = AppDbCxt.ReservationDetails.Include(rd => rd.RoomBookings).FirstOrDefault(x => x.Id == reservationDetailsDto.Id);

                if (existing == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Booking not found!";
                    return result;
                }

                // Update reservation status
                existing.Status = RoomHallStatus.Dirty;
                existing.CheckOut = DateTime.Now;
                AppDbCxt.ReservationDetails.Update(existing);

                /* // Get all room numbers involved in the booking
                 var roomNumbers = reservationDetailsDto.RoomBookings.Select(rb => rb.RoomNo).ToList();

                 // Update the status of each room to Dirty
                 var roomsToUpdate = AppDbCxt.Room.Where(r => roomNumbers.Contains(r.RoomNumber)).ToList();
                 foreach (var room in roomsToUpdate)
                 {
                     room.Status = RoomHallStatus.Dirty;
                     AppDbCxt.Room.Update(room);
                 }*/

                foreach (var roomBooking in existing.RoomBookings)
                {
                    var room = AppDbCxt.Room.FirstOrDefault(r => r.RoomNumber == roomBooking.RoomNo);
                    if (room != null) { room.Status = RoomHallStatus.Dirty; AppDbCxt.Room.Update(room); }
                }


                await AppDbCxt.SaveChangesAsync();

                result.Result = existing;
                result.IsSuccess = true;
                result.Message = "Successfully Checked Out!";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }


        public async Task<ApiResponse<ReservationDetailsDto>> DeleteBookingList(int id)
        {
            var result = new ApiResponse<ReservationDetailsDto>();
            try
            {
                var existing = AppDbCxt.ReservationDetails
                    .Include(rd => rd.CustomerInfo)
                    .Include(rd => rd.RoomBookings)
                    .Include(rd => rd.PaymentDetails)
                    .Include(rd => rd.BillingDetails)
                    .FirstOrDefault(x => x.Id == id);

                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Reservation not found!";
                    return result;
                }

                

                // Remove the reservation
                AppDbCxt.ReservationDetails.Remove(existing);
                
                await AppDbCxt.SaveChangesAsync();

                foreach (var roomBooking in existing.RoomBookings)
                {
                    var room = AppDbCxt.Room.FirstOrDefault(r => r.Id == roomBooking.RoomId);
                    if (room != null) { room.Status = RoomHallStatus.Available; AppDbCxt.Room.Update(room); }
                }
                await AppDbCxt.SaveChangesAsync();
                result.Result = existing;
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

        #region Restaurant

        public async Task<MenuType> GetMenuTypeById(int id)
        {
            MenuType result = null;

#pragma warning disable CS8600
            result = AppDbCxt.MenuType.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<MenuType>> GetAllMenuType()
        {
            IEnumerable<MenuType> result = null;

            result = AppDbCxt.MenuType.ToList();
            return result;
        }
        public async Task<ApiResponse<MenuType>> UpsertMenuType(MenuType data)
        {
            var result = new ApiResponse<MenuType>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid MenuType data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.MenuType.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.MenuType.Add(data);
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

        public async Task<ApiResponse<MenuType>> DeleteMenuType(int id)
        {
            var result = new ApiResponse<MenuType>();
            try
            {
                var existing = AppDbCxt.MenuType.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "MenuType not found!";
                    return result;
                }

                AppDbCxt.MenuType.Remove(existing);
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

        public async Task<FoodCategory> GetFoodCategoryById(int id)
        {
            FoodCategory result = null;

#pragma warning disable CS8600
            result = AppDbCxt.FoodCategory.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<FoodCategory>> GetAllFoodCategory()
        {
            IEnumerable<FoodCategory> result = null;

            result = AppDbCxt.FoodCategory.ToList();
            return result;
        }
        public async Task<ApiResponse<FoodCategory>> UpsertFoodCategory(FoodCategory data)
        {
            var result = new ApiResponse<FoodCategory>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid FoodCategory data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.FoodCategory.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.FoodCategory.Add(data);
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

        public async Task<ApiResponse<FoodCategory>> DeleteFoodCategory(int id)
        {
            var result = new ApiResponse<FoodCategory>();
            try
            {
                var existing = AppDbCxt.FoodCategory.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "FoodCategory not found!";
                    return result;
                }

                AppDbCxt.FoodCategory.Remove(existing);
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


        public async Task<AddVariants> GetAddVariantsById(int id)
        {
            AddVariants result = null;

#pragma warning disable CS8600
            result = AppDbCxt.AddVariants.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<AddVariants>> GetAllAddVariants()
        {
            IEnumerable<AddVariants> result = null;

            result = AppDbCxt.AddVariants.ToList();
            return result;
        }
        public async Task<ApiResponse<AddVariants>> UpsertAddVariants(AddVariants data)
        {
            var result = new ApiResponse<AddVariants>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid AddVariants data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.AddVariants.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.AddVariants.Add(data);
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

        public async Task<ApiResponse<AddVariants>> DeleteAddVariants(int id)
        {
            var result = new ApiResponse<AddVariants>();
            try
            {
                var existing = AppDbCxt.AddVariants.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "AddVariants not found!";
                    return result;
                }

                AppDbCxt.AddVariants.Remove(existing);
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


        //public async Task<bool> UpsertFoodMenuTypeMapping(Dictionary<int, List<int>> dict)
        //{
        //    foreach (var kvp in dict)
        //    {
        //        var foodId = kvp.Key;
        //        var menuTypeId = kvp.Value;

        //        var existingfacilityIds = await AppDbCxt.FoodMenuTypeMapping
        //            .Where(o => o.FoodId == foodId)
        //            .Select(o => o.MenuTypeId)
        //            .ToListAsync();

        //        var facilityIdsToAdd = menuTypeId.Except(existingfacilityIds);
        //        var facilityIdsToRemove = existingfacilityIds.Except(menuTypeId);
        //        var facilityIdsToKeep = menuTypeId.Intersect(existingfacilityIds);

        //        if (facilityIdsToRemove.Any())
        //        {
        //            var mappingsToRemove = await AppDbCxt.FoodMenuTypeMapping
        //                .Where(tcm => tcm.FoodId == foodId && facilityIdsToRemove.Contains(tcm.MenuTypeId))
        //                .ToListAsync();
        //            AppDbCxt.RemoveRange(mappingsToRemove);
        //        }

        //        if (facilityIdsToAdd.Any())
        //        {
        //            var mappingsToAdd = facilityIdsToAdd.Select(c => new FoodMenuTypeMapping
        //            {
        //                FoodId = foodId,
        //                MenuTypeId = c
        //            });
        //            AppDbCxt.AddRange(mappingsToAdd);
        //        }

        //        await AppDbCxt.SaveChangesAsync();
        //    }

        //    return true;
        //}

        public async Task<bool> UpsertFoodMenuTypeMapping(Dictionary<int, List<int>> dict)
        {
            foreach (var kvp in dict)
            {
                var hallId = kvp.Key;
                var facilityId = kvp.Value;

                var existingfacilityIds = await AppDbCxt.FoodMenuTypeMapping
                    .Where(o => o.FoodId == hallId)
                    .Select(o => o.MenuTypeId)
                    .ToListAsync();

                var facilityIdsToAdd = facilityId.Except(existingfacilityIds);
                var facilityIdsToRemove = existingfacilityIds.Except(facilityId);
                var facilityIdsToKeep = facilityId.Intersect(existingfacilityIds);

                if (facilityIdsToRemove.Any())
                {
                    var mappingsToRemove = await AppDbCxt.FoodMenuTypeMapping
                        .Where(tcm => tcm.FoodId == hallId && facilityIdsToRemove.Contains(tcm.MenuTypeId))
                        .ToListAsync();
                    AppDbCxt.RemoveRange(mappingsToRemove);
                }

                if (facilityIdsToAdd.Any())
                {
                    var mappingsToAdd = facilityIdsToAdd.Select(c => new FoodMenuTypeMapping
                    {
                        FoodId = hallId,
                        MenuTypeId = c
                    });
                    AppDbCxt.AddRange(mappingsToAdd);
                }

                await AppDbCxt.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> UpsertFoodVarientMapping(Dictionary<int, List<int>> dict)
        {
            foreach (var kvp in dict)
            {
                var hallId = kvp.Key;
                var facilityId = kvp.Value;

                var existingfacilityIds = await AppDbCxt.FoodVarientMapping
                    .Where(o => o.FoodId == hallId)
                    .Select(o => o.FoodVarientId)
                    .ToListAsync();

                var facilityIdsToAdd = facilityId.Except(existingfacilityIds);
                var facilityIdsToRemove = existingfacilityIds.Except(facilityId);
                var facilityIdsToKeep = facilityId.Intersect(existingfacilityIds);

                if (facilityIdsToRemove.Any())
                {
                    var mappingsToRemove = await AppDbCxt.FoodVarientMapping
                        .Where(tcm => tcm.FoodId == hallId && facilityIdsToRemove.Contains(tcm.FoodVarientId))
                        .ToListAsync();
                    AppDbCxt.RemoveRange(mappingsToRemove);
                }

                if (facilityIdsToAdd.Any())
                {
                    var mappingsToAdd = facilityIdsToAdd.Select(c => new FoodVarientMapping
                    {
                        FoodId = hallId,
                        FoodVarientId = c
                    });
                    AppDbCxt.AddRange(mappingsToAdd);
                }

                await AppDbCxt.SaveChangesAsync();
            }

            return true;
        }


        public async Task<List<FoodMenuTypeMapping>> GetFoodMenuTypeByFoodId(int id)
        {
            var dataMapping = AppDbCxt.FoodMenuTypeMapping.Where(o => o.FoodId == id);
            return dataMapping.ToList();
        }

        public async Task<List<FoodVarientMapping>> GetFoodVarientByFoodId(int id)
        {
            var dataMapping = AppDbCxt.FoodVarientMapping.Where(o => o.FoodId == id);
            return dataMapping.ToList();
        }
        public async Task<Food> GetFoodById(int id)
        {
            Food result = null;

#pragma warning disable CS8600
            result = AppDbCxt.Food.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Food>> GetAllFood()
        {
            IEnumerable<Food> result = null;

            result = AppDbCxt.Food.ToList();
            return result;
        }
        public async Task<ApiResponse<Food>> UpsertFood(Food data)
        {
            var result = new ApiResponse<Food>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Food data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.Food.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.Food.Add(data);
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

        public async Task<ApiResponse<Food>> DeleteFood(int id)
        {
            var result = new ApiResponse<Food>();
            try
            {
                var existing = AppDbCxt.Food.FirstOrDefault(x => x.Id == id);
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Food not found!";
                    return result;
                }

                // Remove related FoodVarientMapping entries
                var varientMappings = AppDbCxt.FoodVarientMapping.Where(vm => vm.FoodId == id).ToList();
                AppDbCxt.FoodVarientMapping.RemoveRange(varientMappings);

                // Remove related FoodMenuTypeMapping entries
                var menuTypeMappings = AppDbCxt.FoodMenuTypeMapping.Where(mm => mm.FoodId == id).ToList();
                AppDbCxt.FoodMenuTypeMapping.RemoveRange(menuTypeMappings);

                // Remove the food item
                AppDbCxt.Food.Remove(existing);
                await AppDbCxt.SaveChangesAsync();

                result.Result = existing;
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

        #region Customer Section
        public async Task<CustomerDetailsDTO> GetCustomerById(int id)
        {
            CustomerDetailsDTO result = null;

#pragma warning disable CS8600
            result = AppDbCxt.CustomerDetailsDTO.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<CustomerDetailsDTO>> GetAllCustomer()
        {
            IEnumerable<CustomerDetailsDTO> result = null;

            result = AppDbCxt.CustomerDetailsDTO.ToList();
            return result;
        }
        public async Task<ApiResponse<CustomerDetailsDTO>> UpsertCustomer(CustomerDetailsDTO data)
        {
            var result = new ApiResponse<CustomerDetailsDTO>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Customer Details data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.CustomerDetailsDTO.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.CustomerDetailsDTO.Add(data);
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

        public async Task<ApiResponse<CustomerDetailsDTO>> DeleteCustomer(int id)
        {
            var result = new ApiResponse<CustomerDetailsDTO>();
            try
            {
                var existing = AppDbCxt.CustomerDetailsDTO.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Customer Details not found!";
                    return result;
                }

                AppDbCxt.CustomerDetailsDTO.Remove(existing);
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

        public async Task<TableCon> GetTableConById(int id)
        {
            TableCon result = null;

#pragma warning disable CS8600
            result = AppDbCxt.TableCon.FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<TableCon>> GetAllTableCon()
        {
            IEnumerable<TableCon> result = null;

            result = AppDbCxt.TableCon.ToList();
            return result;
        }
        public async Task<ApiResponse<TableCon>> UpsertTableCon(TableCon data)
        {
            var result = new ApiResponse<TableCon>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid TableConf data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.TableCon.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.TableCon.Add(data);
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

        public async Task<ApiResponse<TableCon>> DeleteTableCon(int id)
        {
            var result = new ApiResponse<TableCon>();
            try
            {
                var existing = AppDbCxt.TableCon.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "TableConf not found!";
                    return result;
                }

                AppDbCxt.TableCon.Remove(existing);
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

        #region POS Section
        public async Task<PosDTO> GetPosById(int id)
        {
            PosDTO result = null;

#pragma warning disable CS8600
            result = AppDbCxt.PosDTO.Include(x=>x.OrderItems).FirstOrDefault(o => o.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PosDTO>> GetAllPos()
        {
            IEnumerable<PosDTO> result = null;

            result = AppDbCxt.PosDTO.ToList();
            return result;
        }
        public async Task<ApiResponse<PosDTO>> UpsertPos(PosDTO data)
        {
            var result = new ApiResponse<PosDTO>();
            try
            {

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid Pos Details data!";
                    return result;
                }

                if (data.Id > 0)
                {
                    AppDbCxt.PosDTO.Update(data);
                    result.Message = "Data Successfully Updated.";
                }
                else
                {
                    AppDbCxt.PosDTO.Add(data);
                    result.Message = "Data Successfully Inserted.";
                }

                var table = AppDbCxt.TableCon.First(x => x.Id == data.TableId);
                table.Status = TableStatus.Reserved;
                AppDbCxt.TableCon.Update(table);

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

        public async Task<ApiResponse<PosDTO>> DeletePos(int id)
        {
            var result = new ApiResponse<PosDTO>();
            try
            {
                var existing = AppDbCxt.PosDTO.First(x => x.Id == id);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Pos Details not found!";
                    return result;
                }

                AppDbCxt.PosDTO.Remove(existing);
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

        #region DashBoard
        public async Task<Statistic> GetBookingStatsAsync()
        {
            try
            {
                var today = DateTime.Today;
                var startOfMonth = new DateTime(today.Year, today.Month, 1);

                var totalBookings = await AppDbCxt.ReservationDetails
                    .SelectMany(r => r.RoomBookings)
                    .CountAsync();

                var todaysBookings = await AppDbCxt.ReservationDetails
                    .Where(r => r.CheckIn.Date == today)
                    .SelectMany(r => r.RoomBookings)
                    .CountAsync();

                var thisMonthsBookings = await AppDbCxt.ReservationDetails
                    .Where(r => r.CheckIn.Date >= startOfMonth)
                    .SelectMany(r => r.RoomBookings)
                    .CountAsync();

                var totalCharge = await AppDbCxt.ReservationDetails
                    .Select(r => (double)r.BillingDetails.TotalCharge)
                    .SumAsync();

                var todaysTotalCharge = await AppDbCxt.ReservationDetails
                    .Where(r => r.CheckIn.Date == today)
                    .Select(r => (double)r.BillingDetails.TotalCharge)
                    .SumAsync();

                var thisMonthsTotalCharge = await AppDbCxt.ReservationDetails
                    .Where(r => r.CheckIn.Date >= startOfMonth)
                    .Select(r => (double)r.BillingDetails.TotalCharge)
                    .SumAsync();

                var restotalCharge = await AppDbCxt.PosDTO
                    .Select(r => (double)r.GrandTotal)
                    .SumAsync();

                var restodaysTotalCharge = await AppDbCxt.PosDTO
                    .Where(r => r.CreatedOn.Date == today)
                    .Select(r => (double)r.GrandTotal)
                    .SumAsync();

                var resthisMonthsTotalCharge = await AppDbCxt.PosDTO
                    .Where(r => r.CreatedOn.Date >= startOfMonth)
                    .Select(r => (double)r.GrandTotal)
                    .SumAsync();

                return new Statistic
                {
                    TotalBookings = totalBookings,
                    TodaysBookings = todaysBookings,
                    ThisMonthBookings = thisMonthsBookings,

                    TotalAmount = (decimal)totalCharge,
                    TodaysAmount = (decimal)todaysTotalCharge,
                    ThisMonthAmount = (decimal)thisMonthsTotalCharge,

                    ResTotalAmount = (decimal)restotalCharge,
                    ResTodaysAmount = (decimal)restodaysTotalCharge,
                    ResThisMonthAmount = (decimal)resthisMonthsTotalCharge
                };
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return null;
            }
        }



        public async Task<CustomersEntry> GetCustomerStatsAsync()
        {
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);

            var totalCustomers = await AppDbCxt.ReservationDetails
                .SelectMany(r => r.CustomerInfo)
                .CountAsync();

            var todaysCustomers = await AppDbCxt.ReservationDetails
                .Where(r => r.CheckIn.Date == today)
                .SelectMany(r => r.CustomerInfo)
                .CountAsync();

            var thisMonthsCustomers = await AppDbCxt.ReservationDetails
                .Where(r => r.CheckIn.Date >= startOfMonth)
                .SelectMany(r => r.CustomerInfo)
                .CountAsync();

            return new CustomersEntry
            {
                Total = totalCustomers,
                Today = todaysCustomers,
                ThisMonth = thisMonthsCustomers
            };


        }

        public async Task<ApiResponse<PosDTO>> CompletePos(int id)
        {
            var result = new ApiResponse<PosDTO>();
            try
            {
                var existing = AppDbCxt.PosDTO.First(x => x.Id == id);
                existing.Status = PosStatus.Complete;

                var table = AppDbCxt.TableCon.First(x => x.Id == existing.TableId);
                table.Status = TableStatus.Available;
                AppDbCxt.TableCon.Update(table);
                result.Result = existing;
                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Pos Details not found!";
                    return result;
                }

                AppDbCxt.PosDTO.Update(existing);
                await AppDbCxt.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Successfully Completed!";
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

        #region Dashboard
        public async Task<MonthlyBarChart> GetReportData(int year)
        {
            MonthlyBarChart data = new MonthlyBarChart();
            data.MonthwiseEntry = new List<MonthlyReportData>();
            data.Year = year;
            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year, 12, 31).AddHours(24).AddSeconds(-1);

            try
            {
                var chartData = AppDbCxt.ReservationDetails
                 .Where(i => i.CheckIn >= start && i.CheckIn < end);

     


                var trainingGroup = chartData.ToList().GroupBy(i => i.CheckIn.Month, (key, entries) => new
                {
                    Month = (Months)key,
                    Total = entries.Count(),
                    Ready = entries.Count(i => i.Status == (RoomHallStatus.Ready)),
                    Booked = entries.Count(i => i.Status == (RoomHallStatus.Booked)),

                });


                foreach (Months month in Enum.GetValues(typeof(Months)))
                {

                    var log = trainingGroup.FirstOrDefault(i => i.Month == month);

                    var entry = new MonthlyReportData
                    {
                        Month = month,
                    };

                    if (log != null)
                    {
                        entry.Total = log.Total;
                        entry.Booked = log.Booked;
                        entry.Ready = log.Ready;
                        

                    }


                    data.MonthwiseEntry.Add(entry);
                }




            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, ex.Message);
            }
            return await Task.FromResult(data);
        }

        #endregion

        #region Update User Profile Images
        public async Task<ApiResponse<UserProfilePicUpld>> UpsertProfilePic(UserProfilePicUpld data)
        {
            var result = new ApiResponse<UserProfilePicUpld>();



            try
            {
                var profilepicList = await AppDbCxt.UserProfilePicUpld.Where(o => o.Email == data.Email).FirstOrDefaultAsync();

                if (data == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Invalid ProfilePic data!";
                    return result;
                }

                if (profilepicList != null)
                {
                    if (data.ProfileImage != null && data.ProfileImage.Length > 0)
                    {
                        profilepicList.ProfileImage = data.ProfileImage;

                    }

                    if (data.BackgroundImage != null && data.BackgroundImage.Length > 0)
                    {
                        profilepicList.BackgroundImage = data.BackgroundImage;

                    }

                    AppDbCxt.Update(profilepicList);
                    result.Message = "ProfilePic Successfully Updated.";
                }
                else
                {

                    AppDbCxt.UserProfilePicUpld.Add(data);
                    result.Message = "ProfilePic Successfully Inserted.";
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

        public async Task<UserProfilePicUpld> GetProfilePicByEmail(string userEmail)
        {
            UserProfilePicUpld result = null;

#pragma warning disable CS8600
            result = AppDbCxt.UserProfilePicUpld.FirstOrDefault(o => o.Email == userEmail);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (result == null)
            {
                result = new UserProfilePicUpld
                {
                    Email = userEmail,
                    ProfileImage = Array.Empty<byte>(),
                    BackgroundImage = Array.Empty<byte>()
                };
            }

            return await Task.FromResult(result);
        }

        public async Task<ApiResponse<UserProfilePicUpld>> DeleteProfBgPic(UserProfilePicUpld userProfilePicUpld)
        {
            var result = new ApiResponse<UserProfilePicUpld>();
            try
            {
                var existing = AppDbCxt.UserProfilePicUpld.First(x => x.Email == userProfilePicUpld.Email);
                result.Result = existing;

                if (existing == null)
                {
                    result.IsSuccess = true;
                    result.Message = "Product Category not found!";
                    return result;
                }
                if (userProfilePicUpld.removePp == true)
                {
                    existing.ProfileImage = null;
                    AppDbCxt.Update(existing);
                }
                else
                {
                    existing.BackgroundImage = null;
                    AppDbCxt.Update(existing);
                }

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
