using System;

namespace RMS.Dto
{
    public class EmployeePayroll : Auditable
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public decimal BasicSalary { get; set; }
        public decimal TA { get; set; } // Travel Allowance
        public decimal DA { get; set; } // Dearness Allowance
        public decimal HRA { get; set; } // House Rent Allowance
        public decimal OtherAllowances { get; set; }

        public decimal GrossSalary => BasicSalary + TA + DA + HRA + OtherAllowances;

        public decimal TaxPercentage { get; set; }
        public decimal PFPercentage { get; set; } // Provident Fund Percentage
        public decimal IncomeTaxPercentage { get; set; }

        public decimal Tax => GrossSalary * (TaxPercentage / 100);
        public decimal PF => GrossSalary * (PFPercentage / 100);
        public decimal IncomeTax => GrossSalary * (IncomeTaxPercentage / 100);

        public decimal NetSalary => GrossSalary - Tax - PF - IncomeTax;
        public decimal AdvanceAmount { get; set; }
        public decimal PayableSalary { get; set; }

        // Optional: Validation method to ensure consistency
        public void Validate()
        {
            if (BasicSalary < 0)
                throw new InvalidOperationException("Basic Salary cannot be negative.");
            if (TA < 0 || DA < 0 || HRA < 0 || OtherAllowances < 0)
                throw new InvalidOperationException("Allowances cannot be negative.");
            if (TaxPercentage < 0 || PFPercentage < 0 || IncomeTaxPercentage < 0)
                throw new InvalidOperationException("Percentages cannot be negative.");
        }
    }
}
