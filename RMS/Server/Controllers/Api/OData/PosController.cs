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
    public class PosController : ODataController
    {
        public ILogger<PosController> Logger { get; }
        public AppDbContext DbContext { get; }
        public PosController(ILogger<PosController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<PosDTO> Get()
        {
            var data = DbContext.PosDTO.AsQueryable();
            return data;
        }
    }
}
