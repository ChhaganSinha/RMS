
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
    public class CleaningReportController : ODataController
    {
        public ILogger<CleaningReportController> Logger { get; }
        public AppDbContext DbContext { get; }
        public CleaningReportController(ILogger<CleaningReportController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<CleaningReport> Get()
        {
            var data = DbContext.RoomCleaning
                .GroupBy(rc => new { rc.EmpId, rc.Name })
                .Select(g => new CleaningReport
                {
                    Id = g.First().Id,
                    EmpId = g.Key.EmpId,
                    EmpName = g.Key.Name,
                    Complete = g.Count(rc => rc.Status == "Complete").ToString(),
                    Pending = g.Count(rc => rc.Status == "Pending").ToString(),
                    Underprocess = g.Count(rc => rc.Status == "Under Process").ToString(),
                }).AsQueryable();

            return data;
        }
    }
}
