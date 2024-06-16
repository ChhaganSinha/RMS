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
    public class BookingTypeController : ODataController
    {
        public ILogger<BookingTypeController> Logger { get; }
        public AppDbContext DbContext { get; }
        public BookingTypeController(ILogger<BookingTypeController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<BookingType> Get()
        {
            var data = DbContext.BookingType.AsQueryable();
            return data;
        }
    }
}
