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
    public class UnitNamesController : ODataController
    {
        public ILogger<UnitNamesController> Logger { get; }
        public AppDbContext DbContext { get; }
        public UnitNamesController(ILogger<UnitNamesController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<UnitNames> Get()
        {
            var data = DbContext.UnitNames.AsQueryable();
            return data;
        }
    }
}
