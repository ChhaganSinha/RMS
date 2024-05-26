using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class Employee : Auditable
    {
        public EmployeeDesignation EmployeeDesignation { get; set; }

        public EmployeeDepartment EmployeeDepartment { get; set; }
        public string Name { get; set; } = string.Empty;
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
