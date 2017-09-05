using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApplication.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Addresses { get; set; }
        public string Type { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}