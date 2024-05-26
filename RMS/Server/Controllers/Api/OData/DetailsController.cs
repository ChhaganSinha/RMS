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
    public class DetailsController : ODataController
    {
        public ILogger<DetailsController> Logger { get; }
        public AppDbContext DbContext { get; }
        public DetailsController(ILogger<DetailsController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<Details> Get()
        {
            var data = DbContext.Details.AsQueryable();
            return data;
        }
    }
}
