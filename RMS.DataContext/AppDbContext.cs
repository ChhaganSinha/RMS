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
        public DbSet<EmployeeDesignation> EmployeeDesignation { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
        public DbSet<EmployeePayroll> EmployeePayroll { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<EmployeeAttendance>()
            //    .HasOne(ea => ea.Employee)
            //    .WithMany()
            //    .HasForeignKey(ea => ea.EmployeeId);
        }
    }
}
