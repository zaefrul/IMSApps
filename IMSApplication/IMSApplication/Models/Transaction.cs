using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApplication.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public int VarietyId { get; set; }
        public virtual Variety Variety { get; set; }
        public int? InvoiceItemId { get; set; }
        public int Quantity { get; set; }
    }
}