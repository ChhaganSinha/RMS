
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

    }
}
