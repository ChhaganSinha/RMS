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
    public class TableConfController : ODataController
    {
        public ILogger<TableConfController> Logger { get; }
        public AppDbContext DbContext { get; }
        public TableConfController(ILogger<TableConfController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<TableCon> Get()
        {
            var data = DbContext.TableCon.AsQueryable();
            return data;
        }
    }
}
