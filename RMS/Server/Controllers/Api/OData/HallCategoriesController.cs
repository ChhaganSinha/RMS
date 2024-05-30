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
    public class HallCategoriesController : ODataController
    {
        public ILogger<HallCategoriesController> Logger { get; }
        public AppDbContext DbContext { get; }
        public HallCategoriesController(ILogger<HallCategoriesController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<HallCategories> Get()
        {
            var data = DbContext.HallCategories.AsQueryable();
            return data;
        }
    }
}
