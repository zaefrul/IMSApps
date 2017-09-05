using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSApplication.Models
{
    public class Variety
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}