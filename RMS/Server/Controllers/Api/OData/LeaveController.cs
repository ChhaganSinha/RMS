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
    public class LeaveController : ODataController
    {
        public ILogger<LeaveController> Logger { get; }
        public AppDbContext DbContext { get; }
        public LeaveController(ILogger<LeaveController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<Leave> Get()
        {
            var data = DbContext.Leave.AsQueryable();
            return data;
        }
    }
}
