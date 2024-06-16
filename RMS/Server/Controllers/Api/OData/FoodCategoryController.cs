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
    public class FoodCategoryController : ODataController
    {
        public ILogger<FoodCategoryController> Logger { get; }
        public AppDbContext DbContext { get; }
        public FoodCategoryController(ILogger<FoodCategoryController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<FoodCategory> Get()
        {
            var data = DbContext.FoodCategory.AsQueryable();
            return data;
        }
    }
}
