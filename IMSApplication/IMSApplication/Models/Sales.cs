using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApplication.Models
{
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int VarietyId { get; set; }
        public virtual Variety Variety { get; set; }
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
        public int Salesperson { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
    }
}