namespace InfinysBreakfastOrders.Data.Models
{
    using InfinysBreakfastOrders.Data.Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public string OrderText { get; set; }

        public DateTime OrderDate { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
