﻿
namespace RMS.Server.Intrastructure
{
 
    using Microsoft.AspNetCore.OData;
    using Microsoft.OData.Edm;
    using Microsoft.OData.ModelBuilder;
    using Microsoft.AspNetCore.Authorization;
    using RMS.Dto;
  

    public static class ODataHelper
    {
        public static IMvcBuilder AddODataControllers(this IMvcBuilder builder)
        {
            return builder.AddOData(option =>
            {
                option.Select();
                option.Expand();
                option.Filter();
                option.OrderBy();
                option.Count();
                option.SetMaxTop(100);
                option.SkipToken();
                option.AddRouteComponents("Odata", GetModel());
            });
        }
        [Authorize]
        private static IEdmModel GetModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Details>("Details");
            builder.EntitySet<RoomCategories>("RoomCategories");
            builder.EntitySet<RoomFacilities>("RoomFacilities");
            builder.EntitySet<Room>("Room");
            builder.EntitySet<HallCategories>("HallCategories");
            builder.EntitySet<HallFacilities>("HallFacilities");
            builder.EntitySet<Hall>("Hall");
            builder.EntitySet<ProductCategories>("ProductCategories");
            builder.EntitySet<UnitNames>("UnitNames");
            builder.EntitySet<ProductList>("ProductList");
            builder.EntitySet<SupplierList>("SupplierList");
            builder.EntitySet<DestroyedProducts>("DestroyedProducts");
            builder.EntitySet<SaleProducts>("SaleProducts");
            builder.EntitySet<PurchaseItem>("PurchaseItem");
            builder.EntitySet<EmployeeDesignation>("EmployeeDesignation");
            builder.EntitySet<EmployeeDepartment>("EmployeeDepartment");
            builder.EntitySet<Employee>("Employee");
            builder.EntitySet<EmployeeAttendance>("EmployeeAttendance");
            builder.EntitySet<EmployeePayroll>("EmployeePayroll");
            builder.EntitySet<AdvanceSalary>("AdvanceSalary");
            builder.EntitySet<SalaryType>("SalaryType");
            builder.EntitySet<Leave>("Leave");
            builder.EntitySet<LeaveType>("LeaveType");
            builder.EntitySet<CheckList>("CheckList");
            builder.EntitySet<RoomCleaning>("RoomCleaning");
            builder.EntitySet<AllRecord>("AllRecord");
            builder.EntitySet<CleaningReport>("CleaningReport");
            builder.EntitySet<BookingType>("BookingType");
            builder.EntitySet<MenuType>("MenuType");
            builder.EntitySet<FoodCategory>("FoodCategory");
            builder.EntitySet<AddVariants>("AddVariants");
            builder.EntitySet<Food>("Food");
            builder.EntitySet<CustomerDetailsDTO>("CustomerDetailsDTO");
            builder.EntitySet<ReservationDetailsDto>("ReservationDetailsDto");
            builder.EntitySet<TableCon>("TableCon");
            builder.EntitySet<RoomCleaningAssignmentModel>("RoomCleaningAssignmentModel");
            builder.EntitySet<PosDTO>("PosDTO");

            return builder.GetEdmModel();
        }
    }

    
}
