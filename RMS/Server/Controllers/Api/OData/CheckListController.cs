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
    public class CheckListController : ODataController
    {
        public ILogger<CheckListController> Logger { get; }
        public AppDbContext DbContext { get; }
        public CheckListController(ILogger<CheckListController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<CheckList> Get()
        {
            var data = DbContext.CheckList.AsQueryable();
            return data;
        }
    }
}
