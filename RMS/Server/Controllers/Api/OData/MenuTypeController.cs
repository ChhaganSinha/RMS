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
    public class MenuTypeController : ODataController
    {
        public ILogger<MenuTypeController> Logger { get; }
        public AppDbContext DbContext { get; }
        public MenuTypeController(ILogger<MenuTypeController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<MenuType> Get()
        {
            var data = DbContext.MenuType.AsQueryable();
            return data;
        }
    }
}
