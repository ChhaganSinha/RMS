using System;
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
        public DbSet<BookingList> BookingList { get; set; }
        public DbSet<MenuType> MenuType { get; set; }
        public DbSet<FoodCategory> FoodCategory { get; set; }
        public DbSet<AddVariants> AddVariants { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodMenuTypeMapping> FoodMenuTypeMapping { get; set; }
        public DbSet<CustomerDetailsDTO> CustomerDetailsDTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CleaningReport>();
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<EmployeeAttendance>()
            //    .HasOne(ea => ea.Employee)
            //    .WithMany()
            //    .HasForeignKey(ea => ea.EmployeeId);
        }
    }
}
