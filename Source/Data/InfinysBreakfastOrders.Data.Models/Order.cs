namespace InfinysBreakfastOrders.Data.Models
{
    using InfinysBreakfastOrders.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string OrderText { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
