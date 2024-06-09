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
    public class EmployeePayrollController : ODataController
    {
        public ILogger<EmployeePayrollController> Logger { get; }
        public AppDbContext DbContext { get; }
        public EmployeePayrollController(ILogger<EmployeePayrollController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<EmployeePayroll> Get()
        {
            var data = DbContext.EmployeePayroll.AsQueryable();
            return data;
        }
    }
}
