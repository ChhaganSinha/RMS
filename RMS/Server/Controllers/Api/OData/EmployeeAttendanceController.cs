using RMS.DataContext;
using RMS.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using RMS.Server.Intrastructure.ActionFilters;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IQueryable<EmployeeAttendance>> Get()
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Today);
            var attendanceExists = await DbContext.EmployeeAttendance
                                                  .AnyAsync(ea => ea.Date == currentDate);

            if (!attendanceExists)
            {
                var employees = await DbContext.Employee.ToListAsync();
                var attendances = employees.Select(e => new EmployeeAttendance
                {
                    EmployeeId = e.Id,
                    EmployeeName = e.Name,
                    EmpId = e.EmpId,
                    Date = currentDate,
                });

                await DbContext.EmployeeAttendance.AddRangeAsync(attendances);
                await DbContext.SaveChangesAsync();
            }

            return DbContext.EmployeeAttendance.AsQueryable();
        }

    }
}
