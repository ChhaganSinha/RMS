using RMS.DataContext;
using RMS.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using RMS.Server.Intrastructure.ActionFilters;

namespace RMS.Server.Controllers.Api.OData
{
    [Authorize]
    public class AssignRoomCleaningController : ODataController
    {
        public ILogger<AssignRoomCleaningController> Logger { get; }
        public AppDbContext DbContext { get; }
        public AssignRoomCleaningController(ILogger<AssignRoomCleaningController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<RoomCleaningAssignmentModel> Get()
        {
            var data = DbContext.RoomCleaningAssignmentModel.AsQueryable();
            return data;
        }
    }
}
