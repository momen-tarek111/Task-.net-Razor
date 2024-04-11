
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MiniShopRazor.Models
{
    public class Product
    {
        [Key]
       
        public int? Id { get; set; }
       
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        
        public float Price { get; set; }
        public bool EnableSize { get; set; }
        
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; }
    }
}
