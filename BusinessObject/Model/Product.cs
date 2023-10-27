using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Model
{
    public class Product
    {
        [Key] public int ProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get;set;}
        [Required] public int CategoryId { get; set; }
        [Required] public int UnitINStock { get; set; }
        [Required] public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public virtual Category? Category { get; set; }
    }
}