using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class Employee : Auditable
    {
        public string EmployeeDesignation { get; set; } = string.Empty;
        public int ? DesignationId { get; set; }
        public string EmployeeDepartment { get; set; } = string.Empty;
        public int ? DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmpId { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; } 
        public string AadharNumber { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public DateTime joiningDate { get; set; } 
    }
}
