using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baiktr03_04.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double amount { get; set; }
        [Required]
        public string? status { get; set; }
        public int supplierId { get; set; }
        [ForeignKey("supplierId")]
        [ValidateNever]
        public supplier supplier { get; set; }
    }
}

