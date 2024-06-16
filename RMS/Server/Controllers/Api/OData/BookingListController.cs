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
    public class BookingListController : ODataController
    {
        public ILogger<BookingListController> Logger { get; }
        public AppDbContext DbContext { get; }
        public BookingListController(ILogger<BookingListController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<BookingList> Get()
        {
            var data = DbContext.BookingList.AsQueryable();
            return data;
        }
    }
}
