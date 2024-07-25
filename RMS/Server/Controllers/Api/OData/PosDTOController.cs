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
    public class PosDTOController : ODataController
    {
        public ILogger<PosDTOController> Logger { get; }
        public AppDbContext DbContext { get; }
        public PosDTOController(ILogger<PosDTOController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<PosDTO> Get()
        {
            var data = DbContext.PosDTO.Include(x=>x.OrderItems).AsQueryable();
            return data;
        }
    }
}
