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
    public class RoomController : ODataController
    {
        public ILogger<RoomController> Logger { get; }
        public AppDbContext DbContext { get; }
        public RoomController(ILogger<RoomController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<Room> Get()
        {
            var data = DbContext.Room.AsQueryable();
            return data;
        }
    }
}
