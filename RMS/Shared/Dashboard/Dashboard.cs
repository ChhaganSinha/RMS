using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto.Dashboard
{
    public enum ChartType
    {
        pie,
        doughnut,
        polarArea,
        bar,
        line
    }

    public enum Months
    {
        Jan = 1,
        Feb,
        Mar,
        Apr,
        May,
        June,
        Jul,
        August,
        Sep,
        Oct,
        Nove,
        December,
    }

    public class ChartJsDataset
    {
        public string Label { get; set; } = "Default Label";
        public string[] Data { get; set; }
        public string[] BackgroundColor { get; set; }
        public string Stack { get; set; }
        public string[] Labels { get; set; }

    }
    public class Statistic
    {
        public int TotalBookings { get; set; }
        public int TodaysBookings { get; set; }
        public int ThisMonthBookings { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal TodaysAmount { get; set; }
        public decimal ThisMonthAmount { get; set; }

        public int TotalCustomer { get; set; }
        public int TodaysCustomer { get; set; }
        public int ThisMonthCustomer { get; set; }

        public decimal ResTotalAmount { get; set; }
        public decimal ResTodaysAmount { get; set; }
        public decimal ResThisMonthAmount { get; set; }
    }
    public class CustomersEntry
    {
        public CustomerDetailsDTO Customers { get; set; }
        public int Total { get; set; }
        public int Today { get; set; }
        public int ThisMonth { get; set; }

        public int Reported { get; set; }
    }

    public class MonthlyReportData
    {
        public Months Month { get; set; }
        public int Total { get; set; }
        public int Ready { get; set; }
        public int Booked { get; set; }
       
    }
    public class MonthlyBarChart
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<MonthlyReportData> MonthwiseEntry { get; set; }
    }
}
