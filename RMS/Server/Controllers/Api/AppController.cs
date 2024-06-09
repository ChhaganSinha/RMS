﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using RMS.DataContext.Models;
using RMS.Dto;
using RMS.Dto.Dashboard;
using RMS.Repositories;
using System.Net.Http;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using Serilog.Core;



namespace RMS.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppController : ControllerBase
    {
        readonly AppRepository _appRepository;
        readonly ILogger _logger;
        readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public AppController(ILogger<AppController> logger, IConfiguration appConfig, IAppRepository appRepository, IWebHostEnvironment env) : base()
        {
            _appRepository = (AppRepository?)appRepository;
            _logger = logger;
            _configuration = appConfig;
            _env = env;
            // Retrieve username and roles in the constructor and store them in _userName and _userRoles

        }

        #region Details
        [HttpGet]
        [Route("details/{id}")]
        public async Task<Details> GetDetailsById(int id)
        {
            return await _appRepository.GetDetailsById(id);
        }

        [HttpGet]
        [Route("all-details")]
        [AllowAnonymous]
        public async Task<IEnumerable<Details>> GetAllDetails()
        {
            return await _appRepository.GetAllDetails();
        }

        [HttpPost]
        [Route("UpsertDetails")]
        public async Task<Details> UpsertDetails(Details details)
        {

            return await _appRepository.UpsertDetails(details);
        }
        #endregion

        #region Room Setion
        [HttpGet]
        [Route("RoomCategory/{id}")]
        public async Task<RoomCategories> GetRoomCategoryById(int id)
        {
            return await _appRepository.GetRoomCategoryById(id);
        }

        [HttpGet]
        [Route("all-room-category")]
        public async Task<IEnumerable<RoomCategories>> GetAllRoomCategory()
        {
            return await _appRepository.GetAllRoomCategory();
        }

        [HttpPost]
        [Route("UpsertRoomCategory")]
        public async Task<ApiResponse<RoomCategories>> UpsertRoomCategory(RoomCategories data)
        {
            return await _appRepository.UpsertRoomCategory(data);
        }
        [HttpPost]
        [Route("DeleteRoomCategory/{id}")]
        public async Task<ApiResponse<RoomCategories>> DeleteRoomCategory(int id)
        {
                return await _appRepository.DeleteRoomCategory(id);
        }



        [HttpGet]
        [Route("RoomFacility/{id}")]
        public async Task<RoomFacilities> GetRoomFacilityById(int id)
        {
            return await _appRepository.GetRoomFacilityById(id);
        }

        [HttpGet]
        [Route("all-room-facility")]
        public async Task<IEnumerable<RoomFacilities>> GetAllRoomFacility()
        {
            return await _appRepository.GetAllRoomFacility();
        }

        [HttpPost]
        [Route("UpsertRoomFacility")]
        public async Task<ApiResponse<RoomFacilities>> UpsertRoomFacility(RoomFacilities data)
        {
            return await _appRepository.UpsertRoomFacility(data);
        }

        [HttpGet]
        [Route("GetFacilitiesMappingByRoomId/{RoomId}")]
        public async Task<List<RoomFacilitiesMapping>> GetFacilitiesMappingByRoomId(int RoomId)
        {
            var data = await _appRepository.GetFacilitiesMappingByRoomId(RoomId);
            return data;
        }

        [HttpPost]
        [Route("UpsertRoomFacilitiesMapping")]
        public async Task<ApiResponse<string>> UpsertRoomFacilitiesMapping(Dictionary<int, List<int>> dict)
        {
            var result = new ApiResponse<string>();
            try
            {
                var outcome = await _appRepository.UpsertRoomFacilitiesMapping(dict);
                result.Message = "Success";
            }
            catch (Exception ex)
            {
               // Logger.LogError(ex, "Error while uploading data to TrainingCampIdMapping");
            }

            return result;
        }


        [HttpPost]
        [Route("DeleteRoomFacility/{id}")]
        public async Task<ApiResponse<RoomFacilities>> DeleteRoomFacility(int id)
        {
            return await _appRepository.DeleteRoomFacility(id);
        }



        [HttpGet]
        [Route("Room/{id}")]
        public async Task<Room> GetRoomById(int id)
        {
            return await _appRepository.GetRoomById(id);
        }

        [HttpGet]
        [Route("all-room")]
        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            return await _appRepository.GetAllRoom();
        }

        [HttpPost]
        [Route("UpsertRoom")]
        public async Task<ApiResponse<Room>> UpsertRoom(Room data)
        {
            return await _appRepository.UpsertRoom(data);
        }
        [HttpPost]
        [Route("DeleteRoom/{id}")]
        public async Task<ApiResponse<Room>> DeleteRoom(int id)
        {
            return await _appRepository.DeleteRoom(id);
        }
        #endregion

        #region Employee Setion
        [HttpGet]
        [Route("EmployeeDesignation/{id}")]
        public async Task<EmployeeDesignation> GetEmployeeDesignationById(int id)
        {
            return await _appRepository.GetEmployeeDesignationById(id);
        }

        [HttpGet]
        [Route("all-EmployeeDesignation")]
        public async Task<IEnumerable<EmployeeDesignation>> GetAllEmployeeDesignation()
        {
            return await _appRepository.GetAllEmployeeDesignation();
        }

        [HttpPost]
        [Route("UpsertEmployeeDesignation")]
        public async Task<ApiResponse<EmployeeDesignation>> UpsertEmployeeDesignation(EmployeeDesignation data)
        {
            return await _appRepository.UpsertEmployeeDesignation(data);
        }
        [HttpPost]
        [Route("DeleteEmployeeDesignation/{id}")]
        public async Task<ApiResponse<EmployeeDesignation>> DeleteEmployeeDesignation(int id)
        {
            return await _appRepository.DeleteEmployeeDesignation(id);
        }


        [HttpGet]
        [Route("EmployeeDepartment/{id}")]
        public async Task<EmployeeDepartment> GetEmployeeDepartmentById(int id)
        {
            return await _appRepository.GetEmployeeDepartmentById(id);
        }

        [HttpGet]
        [Route("all-EmployeeDepartment")]
        public async Task<IEnumerable<EmployeeDepartment>> GetAllEmployeeDepartment()
        {
            return await _appRepository.GetAllEmployeeDepartment();
        }

        [HttpPost]
        [Route("UpsertEmployeeDepartment")]
        public async Task<ApiResponse<EmployeeDepartment>> UpsertEmployeeDepartment(EmployeeDepartment data)
        {
            return await _appRepository.UpsertEmployeeDepartment(data);
        }
        [HttpPost]
        [Route("DeleteEmployeeDepartment/{id}")]
        public async Task<ApiResponse<EmployeeDepartment>> DeleteEmployeeDepartment(int id)
        {
            return await _appRepository.DeleteEmployeeDepartment(id);
        }


        [HttpGet]
        [Route("Employee/{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _appRepository.GetEmployeeById(id);
        }

        [HttpGet]
        [Route("all-Employee")]
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _appRepository.GetAllEmployee();
        }

        [HttpPost]
        [Route("UpsertEmployee")]
        public async Task<ApiResponse<Employee>> UpsertEmployee(Employee data)
        {
            return await _appRepository.UpsertEmployee(data);
        }
        [HttpPost]
        [Route("DeleteEmployee/{id}")]
        public async Task<ApiResponse<Employee>> DeleteEmployee(int id)
        {
            return await _appRepository.DeleteEmployee(id);
        }
        #endregion


        #region Hall Setion
        [HttpGet]
        [Route("HallCategory/{id}")]
        public async Task<HallCategories> GetHallCategoryById(int id)
        {
            return await _appRepository.GetHallCategoryById(id);
        }

        [HttpGet]
        [Route("all-hall-category")]
        public async Task<IEnumerable<HallCategories>> GetAllHallCategory()
        {
            return await _appRepository.GetAllHallCategory();
        }

        [HttpPost]
        [Route("UpsertHallCategory")]
        public async Task<ApiResponse<HallCategories>> UpsertHallCategory(HallCategories data)
        {
            return await _appRepository.UpsertHallCategory(data);
        }
        [HttpPost]
        [Route("DeleteHallCategory/{id}")]
        public async Task<ApiResponse<HallCategories>> DeleteHallCategory(int id)
        {
            return await _appRepository.DeleteHallCategory(id);
        }



        [HttpGet]
        [Route("HallFacility/{id}")]
        public async Task<HallFacilities> GetHallFacilityById(int id)
        {
            return await _appRepository.GetHallFacilityById(id);
        }

        [HttpGet]
        [Route("all-hall-facility")]
        public async Task<IEnumerable<HallFacilities>> GetAllHallFacility()
        {
            return await _appRepository.GetAllHallFacility();
        }

        [HttpPost]
        [Route("UpsertHallFacility")]
        public async Task<ApiResponse<HallFacilities>> UpsertHallFacility(HallFacilities data)
        {
            return await _appRepository.UpsertHallFacility(data);
        }
        [HttpPost]
        [Route("DeleteHallFacility/{id}")]
        public async Task<ApiResponse<HallFacilities>> DeleteHallFacility(int id)
        {
            return await _appRepository.DeleteHallFacility(id);
        }
        #endregion

        #region Employee Attendance
        [HttpPost]
        [Route("EmployeeCheckIn")]
        public async Task<ApiResponse<EmployeeAttendance>> EmployeeCheckInAsync(EmployeeAttendance data)
        {
            return await _appRepository.EmployeeCheckInAsync(data);
        }
        [HttpPost]
        [Route("EmployeeCheckOut")]
        public async Task<ApiResponse<EmployeeAttendance>> EmployeeCheckOutAsync(EmployeeAttendance data)
        {
            return await _appRepository.EmployeeCheckOutAsync(data);
        }
        [HttpPost]
        [Route("UpdateEmployeeAttendance")]
        public async Task<ApiResponse<EmployeeAttendance>> UpdateEmployeeAttendance(EmployeeAttendance data)
        {
            return await _appRepository.UpdateEmployeeAttendance(data);
        }
        [HttpGet]
        [Route("all-EmployeeAttendance")]
        public async Task<IEnumerable<EmployeeAttendance>> GetAllEmployeeAttendance()
        {
            return await _appRepository.GetAllEmployeeAttendance();
        }
        #endregion

        #region Leave Section
        [HttpGet]
        [Route("LeaveType/{id}")]
        public async Task<LeaveType> GetLeaveTypeById(int id)
        {
            return await _appRepository.GetLeaveTypeById(id);
        }

        [HttpGet]
        [Route("all-LeaveType")]
        public async Task<IEnumerable<LeaveType>> GetAllLeaveType()
        {
            return await _appRepository.GetAllLeaveType();
        }

        [HttpPost]
        [Route("UpsertLeaveType")]
        public async Task<ApiResponse<LeaveType>> UpsertLeaveTypeAsync(LeaveType data)
        {
            return await _appRepository.UpsertLeaveTypeAsync(data);
        }
        [HttpPost]
        [Route("DeleteLeaveType/{id}")]
        public async Task<ApiResponse<LeaveType>> DeleteLeaveType(int id)
        {
            return await _appRepository.DeleteLeaveType(id);
        }



        [HttpGet]
        [Route("Leave/{id}")]
        public async Task<Leave> GetLeaveById(int id)
        {
            return await _appRepository.GetLeaveById(id);
        }
        [HttpPost]
        [Route("UpsertLeave")]
        public async Task<ApiResponse<Leave>> UpsertLeaveAsync(Leave data)
        {
            return await _appRepository.UpsertLeaveAsync(data);
        }
        [HttpGet]
        [Route("all-Leave")]
        public async Task<IEnumerable<Leave>> GetAllLeave()
        {
            return await _appRepository.GetAllLeave();
        }
        [HttpPost]
        [Route("DeleteLeave/{id}")]
        public async Task<ApiResponse<Leave>> DeleteLeave(int id)
        {
            return await _appRepository.DeleteLeave(id);
        }
        [HttpPost]
        [Route("ApproveLeave")]
        public async Task<ApiResponse<Leave>> ApproveLeaveAsync(Leave data)
        {
            return await _appRepository.ApproveLeaveAsync(data);
        }

        #endregion
    }
}
