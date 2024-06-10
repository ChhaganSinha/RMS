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
    public class RoomCleaningController : ODataController
    {
        public ILogger<RoomCleaningController> Logger { get; }
        public AppDbContext DbContext { get; }
        public RoomCleaningController(ILogger<RoomCleaningController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<RoomCleaning> Get()
        {
            var data = DbContext.RoomCleaning.AsQueryable();
            return data;
        }
    }
}
