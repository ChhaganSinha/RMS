using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class PosDTO : Auditable
    {
        public int CustomerId { get; set; } 
        public string CustomerName { get; set; } 
        public string CustomerType { get; set; } 
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public int TableId { get; set; }  
        public string Table { get; set; }  
        public DateTime CookingTime { get; set; } 
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
        public decimal VatTax { get; set; }  
        public decimal ServiceCharge { get; set; }  
        public decimal GrandTotal { get; set; }  
    }

    public class OrderItemDTO : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Price * Quantity; } }
    }
}

