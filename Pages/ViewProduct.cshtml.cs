using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniShopRazor.Data;
using System.Reflection.Metadata;
using MiniShopRazor.Models;
namespace MiniShopRazor.Pages
{
    public class ViewProductModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public List<Product>? products { get; set; }
        
        public void OnGet()
        {
            products = _db.Products.ToList();
        }
        
        public IActionResult OnPostDelete(int id)
        {
            var product =_db.Products.SingleOrDefault(p => p.Id == id);
            if(product != null) 
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return RedirectToPage("ViewProduct");
            }
        }
    }
}
