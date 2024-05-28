﻿using RMS.DataContext;
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
        #endregion

    }
}
