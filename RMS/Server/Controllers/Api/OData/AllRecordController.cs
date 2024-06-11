using RMS.DataContext;
using RMS.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using RMS.Server.Intrastructure.ActionFilters;
using RMS.Client.Pages.App_Pages.Housekeeping;

namespace RMS.Server.Controllers.Api.OData
{
    [Authorize]
    public class AllRecordsController : ODataController
    {
        public ILogger<AllRecordsController> Logger { get; }
        public AppDbContext DbContext { get; }
        public AllRecordsController(ILogger<AllRecordsController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<AllRecord> Get()
        {
            var data = DbContext.AllRecord.AsQueryable();
            return data;
        }
    }
}
