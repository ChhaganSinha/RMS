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
    public class SalaryTypeController : ODataController
    {
        public ILogger<SalaryTypeController> Logger { get; }
        public AppDbContext DbContext { get; }
        public SalaryTypeController(ILogger<SalaryTypeController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<SalaryType> Get()
        {
            var data = DbContext.SalaryType.AsQueryable();
            return data;
        }
    }
}
