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
    public class EmployeeDesignationController : ODataController
    {
        public ILogger<EmployeeDesignationController> Logger { get; }
        public AppDbContext DbContext { get; }
        public EmployeeDesignationController(ILogger<EmployeeDesignationController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<EmployeeDesignation> Get()
        {
            var data = DbContext.EmployeeDesignation.AsQueryable();
            return data;
        }
    }
}
