﻿using RMS.DataContext;
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
    public class AdvanceSalaryController : ODataController
    {
        public ILogger<AdvanceSalaryController> Logger { get; }
        public AppDbContext DbContext { get; }
        public AdvanceSalaryController(ILogger<AdvanceSalaryController> logger, AppDbContext dbContext)
        {
            Logger = logger;  
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<AdvanceSalary> Get()
        {
            var data = DbContext.AdvanceSalary.AsQueryable();
            return data;
        }
    }
}
