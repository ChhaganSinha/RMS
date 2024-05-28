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
    public class RoomCategoriesController : ODataController
    {
        public ILogger<RoomCategoriesController> Logger { get; }
        public AppDbContext DbContext { get; }
        public RoomCategoriesController(ILogger<RoomCategoriesController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<RoomCategories> Get()
        {
            var data = DbContext.RoomCategories.AsQueryable();
            return data;
        }
    }
}
