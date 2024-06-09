using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class EmployeePayroll : Auditable
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal TA { get; set; }
        public decimal DA { get; set; }
        public decimal HRA { get; set; }
        public decimal OtherAllowances { get; set; }

        public decimal GrossSalary => BasicSalary + TA + DA + HRA + OtherAllowances;

        public decimal TaxPercentage { get; set; }
        public decimal PFPercentage { get; set; }
        public decimal IncomeTaxPercentage { get; set; }

        public decimal Tax => GrossSalary * (TaxPercentage / 100);
        public decimal PF => GrossSalary * (PFPercentage / 100);
        public decimal IncomeTax => GrossSalary * (IncomeTaxPercentage / 100);

        public decimal NetSalary => GrossSalary - Tax - PF - IncomeTax;
    }
}
