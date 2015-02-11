using InfinysBreakfastOrders.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinysBreakfastOrders.Data.Models
{
    public class Order:AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string OrderText { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
