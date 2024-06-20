using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class FoodCategoryMapping : BaseEntity
    {
        public int FoodId { get; set; }
        public int FoodCategoryId { get; set; }
    }
}
