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
    public class PurchaseItemController : ODataController
    {
        public ILogger<PurchaseItemController> Logger { get; }
        public AppDbContext DbContext { get; }
        public PurchaseItemController(ILogger<PurchaseItemController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<PurchaseItem> Get()
        {
            var data = DbContext.PurchaseItem.AsQueryable();
            return data;
        }
    }
}
