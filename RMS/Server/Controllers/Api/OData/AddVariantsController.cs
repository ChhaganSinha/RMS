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
    public class AddVariantsController : ODataController
    {
        public ILogger<AddVariantsController> Logger { get; }
        public AppDbContext DbContext { get; }
        public AddVariantsController(ILogger<AddVariantsController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<AddVariants> Get()
        {
            var data = DbContext.AddVariants.AsQueryable();
            return data;
        }
    }
}
