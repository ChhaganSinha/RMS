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
        public int TotalBokking { get; set; }
        public int TodaysBokking { get; set; }
        public int ThisMonthBokking { get; set; }

        public int TotalAmount { get; set; }
        public int TodaysAmount { get; set; }
        public int ThisMonthAmount { get; set; }

        public int TotalCustomer { get; set; }
        public int TodaysCustomer { get; set; }
        public int ThisMonthCustomer { get; set; }

        public int TotalSales { get; set; }
        public int TodaysSales { get; set; }
        public int ThisMonthSales { get; set; }
    }
    public class CustomersEntry
    {
        public CustomerDetailsDTO Customers { get; set; }
        public int Total { get; set; }
        public int Today { get; set; }
        public int Reported { get; set; }
    }
}
