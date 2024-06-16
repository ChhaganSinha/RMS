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
    public class FoodController : ODataController
    {
        public ILogger<FoodController> Logger { get; }
        public AppDbContext DbContext { get; }
        public FoodController(ILogger<FoodController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<AddFood> Get()
        {
            var data = DbContext.AddFood.AsQueryable();
            return data;
        }
    }
}
