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
    public class SaleProductsController : ODataController
    {
        public ILogger<SaleProductsController> Logger { get; }
        public AppDbContext DbContext { get; }
        public SaleProductsController(ILogger<SaleProductsController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<SaleProducts> Get()
        {
            var data = DbContext.SaleProducts.AsQueryable();
            return data;
        }
    }
}
