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
    public class EmployeesController : ODataController
    {
        public ILogger<EmployeesController> Logger { get; }
        public AppDbContext DbContext { get; }
        public EmployeesController(ILogger<EmployeesController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<Employee> Get()
        {
            var data = DbContext.Employee.AsQueryable();
            return data;
        }
    }
}
