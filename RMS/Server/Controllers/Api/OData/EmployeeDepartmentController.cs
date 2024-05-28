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
    public class EmployeeDepartmentController : ODataController
    {
        public ILogger<EmployeeDepartmentController> Logger { get; }
        public AppDbContext DbContext { get; }
        public EmployeeDepartmentController(ILogger<EmployeeDepartmentController> logger, AppDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        [EnableQuery]
        [ODataAuthorize]
        public IQueryable<EmployeeDepartment> Get()
        {
            var data = DbContext.EmployeeDepartment.AsQueryable();
            return data;
        }
    }
}
