﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS.Dto;

namespace RMS.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, bool ensureCreated = true) : base(options)
        {
            if (ensureCreated)
                Database.EnsureCreated();
        }

        public DbSet<Details> Details { get; set; }
        public DbSet<RoomCategories> RoomCategories { get; set; }
        public DbSet<RoomFacilities> RoomFacilities { get; set; }
        public DbSet<RoomFacilitiesMapping> RoomFacilitiesMapping { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<HallCategories> HallCategories { get; set; }
        public DbSet<HallFacilities> HallFacilities { get; set; }
        public DbSet<HallFacilitiesMapping> HallFacilitiesMapping { get; set; }
        public DbSet<Hall> Halls { get; set; }

        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<UnitNames> UnitNames { get; set; }
        public DbSet<ProductList> ProductList { get; set; }
        public DbSet<SupplierList> SupplierList { get; set; }
        public DbSet<DestroyedProducts> DestroyedProducts { get; set; }
        public DbSet<SaleProducts> SaleProducts { get; set; }
        public DbSet<PurchaseItem> PurchaseItem { get; set; }
        public DbSet<ItemDto> ItemDto { get; set; }

        public DbSet<EmployeeDesignation> EmployeeDesignation { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
        public DbSet<EmployeePayroll> EmployeePayroll { get; set; }
        public DbSet<SalaryType> SalaryType { get; set; }
        public DbSet<AdvanceSalary> AdvanceSalary { get; set; }
        public DbSet<CheckList> CheckList { get; set; }
        public DbSet<RoomCleaning> RoomCleaning { get; set; }
        public DbSet<AllRecord> AllRecord { get; set; }
        public DbSet<CleaningReport> CleaningReport { get; set; }
        public DbSet<BookingType> BookingType { get; set; }
        public DbSet<ReservationDetailsDto> ReservationDetails { get; set; }
        public DbSet<MenuType> MenuType { get; set; }
        public DbSet<FoodCategory> FoodCategory { get; set; }
        public DbSet<AddVariants> AddVariants { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodMenuTypeMapping> FoodMenuTypeMapping { get; set; }
        public DbSet<FoodVarientMapping> FoodVarientMapping { get; set; }
        public DbSet<CustomerDetailsDTO> CustomerDetailsDTO { get; set; }
        public DbSet<PosDTO> PosDTO { get; set; }
        public DbSet<TableCon> TableCon { get; set; }
        public DbSet<UserProfilePicUpld> UserProfilePicUpld { get; set; }
        public DbSet<RoomCleaningAssignmentModel> RoomCleaningAssignmentModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CleaningReport>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomCleaningAssignmentModel>()
                .Ignore(e => e.StartDate)
                .Ignore(e => e.EndDate)
                .Ignore(e => e.IsSelected)
                .Ignore(e => e.RoomNo)
                .Ignore(e => e.Status);

            modelBuilder.Entity<ReservationDetailsDto>()
               .Ignore(e => e.RoomNos);

            SeedEmployeeDesignations(modelBuilder);
            SeedEmployeeDepartments(modelBuilder);
        }

        private void SeedEmployeeDesignations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDesignation>().HasData(
                new EmployeeDesignation { Id = 1, Name = "Hotel Manager" },
                new EmployeeDesignation { Id = 2, Name = "Restaurant Manager" },
                new EmployeeDesignation { Id = 3, Name = "Chef" },
                new EmployeeDesignation { Id = 4, Name = "Sous Chef" },
                new EmployeeDesignation { Id = 5, Name = "Housekeeping Staff" },
                new EmployeeDesignation { Id = 6, Name = "Bartender" },
                new EmployeeDesignation { Id = 7, Name = "Waitstaff" },
                new EmployeeDesignation { Id = 8, Name = "Event Coordinator" },
                new EmployeeDesignation { Id = 9, Name = "Maintenance Worker" }
            );
        }

        private void SeedEmployeeDepartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDepartment>().HasData(
                new EmployeeDepartment { Id = 1, Name = "Management" },
                new EmployeeDepartment { Id = 2, Name = "Reception" },
                new EmployeeDepartment { Id = 3, Name = "Restaurant" },
                new EmployeeDepartment { Id = 4, Name = "Housekeeping" },
                new EmployeeDepartment { Id = 5, Name = "Cleaning" },
                new EmployeeDepartment { Id = 6, Name = "Maintenance" }
            );
        }
    }
}
