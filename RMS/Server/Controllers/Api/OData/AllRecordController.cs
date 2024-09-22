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
    public class AllRecordController : ODataController
    {
        public ILogger<AllRecordController> Logger { get; }
        public AppDbContext DbContext { get; }
        public AllRecordController(ILogger<AllRecordController> logger, AppDbContext dbContext)
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
