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
    public class EmployeeAttendanceController : ODataController
    {
        public ILogger<EmployeeAttendanceController> Logger { get; }
        public AppDbContext DbContext { get; }
        public EmployeeAttendanceController(ILogger<EmployeeAttendanceController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<EmployeeAttendance> Get()
        {
            var data = DbContext.EmployeeAttendance.AsQueryable();
            return data;
        }
    }
}
