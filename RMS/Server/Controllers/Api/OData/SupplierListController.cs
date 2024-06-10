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
    public class SupplierListController : ODataController
    {
        public ILogger<SupplierListController> Logger { get; }
        public AppDbContext DbContext { get; }
        public SupplierListController(ILogger<SupplierListController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<SupplierList> Get()
        {
            var data = DbContext.SupplierList.AsQueryable();
            return data;
        }
    }
}
