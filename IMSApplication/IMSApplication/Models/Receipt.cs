using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApplication.Models
{
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string Method { get; set; }
        public double Tendered { get; set; }
        public double Change { get; set; }
        public string Refference { get; set; }
        public int VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}