using System;

namespace RMS.Dto
{
    public class EmployeePayroll : Auditable
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        private decimal basicSalary;
        public decimal BasicSalary
        {
            get => basicSalary;
            set => basicSalary = Math.Round(value, 2);
        }

        private decimal ta;
        public decimal TA
        {
            get => ta;
            set => ta = Math.Round(value, 2);
        } // Travel Allowance

        private decimal da;
        public decimal DA
        {
            get => da;
            set => da = Math.Round(value, 2);
        } // Dearness Allowance

        private decimal hra;
        public decimal HRA
        {
            get => hra;
            set => hra = Math.Round(value, 2);
        } // House Rent Allowance

        private decimal otherAllowances;
        public decimal OtherAllowances
        {
            get => otherAllowances;
            set => otherAllowances = Math.Round(value, 2);
        }

        public decimal GrossSalary => Math.Round(BasicSalary + TA + DA + HRA + OtherAllowances, 2);

        private decimal taxPercentage;
        public decimal TaxPercentage
        {
            get => taxPercentage;
            set => taxPercentage = Math.Round(value, 2);
        }

        private decimal pfPercentage;
        public decimal PFPercentage
        {
            get => pfPercentage;
            set => pfPercentage = Math.Round(value, 2);
        } // Provident Fund Percentage

        private decimal incomeTaxPercentage;
        public decimal IncomeTaxPercentage
        {
            get => incomeTaxPercentage;
            set => incomeTaxPercentage = Math.Round(value, 2);
        }

        public decimal Tax => Math.Round(GrossSalary * (TaxPercentage / 100), 2);
        public decimal PF => Math.Round(GrossSalary * (PFPercentage / 100), 2);
        public decimal IncomeTax => Math.Round(GrossSalary * (IncomeTaxPercentage / 100), 2);

        public decimal NetSalary => Math.Round(GrossSalary - Tax - PF - IncomeTax, 2);

        private decimal advanceAmount;
        public decimal AdvanceAmount
        {
            get => advanceAmount;
            set => advanceAmount = Math.Round(value, 2);
        }

        private decimal payableSalary;
        public decimal PayableSalary
        {
            get => payableSalary;
            set => payableSalary = Math.Round(value, 2);
        }

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
