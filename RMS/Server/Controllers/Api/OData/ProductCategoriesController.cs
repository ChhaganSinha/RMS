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
    public class ProductCategoriesController : ODataController
    {
        public ILogger<ProductCategoriesController> Logger { get; }
        public AppDbContext DbContext { get; }
        public ProductCategoriesController(ILogger<ProductCategoriesController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<ProductCategories> Get()
        {
            var data = DbContext.ProductCategories.AsQueryable();
            return data;
        }
    }
}
