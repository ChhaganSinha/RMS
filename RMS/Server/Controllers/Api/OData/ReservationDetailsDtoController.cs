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
    public class ReservationDetailsDtoController : ODataController
    {
        public ILogger<ReservationDetailsDtoController> Logger { get; }
        public AppDbContext DbContext { get; }
        public ReservationDetailsDtoController(ILogger<ReservationDetailsDtoController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<ReservationDetailsDto> Get()
        {
            var data = DbContext.ReservationDetails.AsQueryable();
            return data;
        }
    }
}
