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
    public class LeaveTypeController : ODataController
    {
        public ILogger<LeaveTypeController> Logger { get; }
        public AppDbContext DbContext { get; }
        public LeaveTypeController(ILogger<LeaveTypeController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<LeaveType> Get()
        {
            var data = DbContext.LeaveType.AsQueryable();
            return data;
        }
    }
}
