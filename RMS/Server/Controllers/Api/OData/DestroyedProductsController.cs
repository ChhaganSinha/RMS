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
    public class DestroyedProductsController : ODataController
    {
        public ILogger<DestroyedProductsController> Logger { get; }
        public AppDbContext DbContext { get; }
        public DestroyedProductsController(ILogger<DestroyedProductsController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<DestroyedProducts> Get()
        {
            var data = DbContext.DestroyedProducts.AsQueryable();
            return data;
        }
    }
}
