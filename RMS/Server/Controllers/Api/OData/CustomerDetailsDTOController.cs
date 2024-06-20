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
    public class CustomerDetailsDTOController : ODataController
    {
        public ILogger<CustomerDetailsDTOController> Logger { get; }
        public AppDbContext DbContext { get; }
        public CustomerDetailsDTOController(ILogger<CustomerDetailsDTOController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<CustomerDetailsDTO> Get()
        {
            var data = DbContext.CustomerDetailsDTO.AsQueryable();
            return data;
        }
    }
}
