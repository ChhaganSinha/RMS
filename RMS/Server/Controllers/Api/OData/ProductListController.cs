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
    public class ProductListController : ODataController
    {
        public ILogger<ProductListController> Logger { get; }
        public AppDbContext DbContext { get; }
        public ProductListController(ILogger<ProductListController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<ProductList> Get()
        {
            var data = DbContext.ProductList.AsQueryable();
            return data;
        }
    }
}
