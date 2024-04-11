using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniShopRazor.Data;
using MiniShopRazor.Models;
using MiniShopRazor.ModelView;
namespace MiniShopRazor.Pages
{
    public class CreateProductModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]

        public Product p { get; set; }
        public ProdectCompany? pc = new ProdectCompany();
        
        public IActionResult OnGet()
        {
            pc._company = _db.Companies.ToList();
            return Page();
            
        }
        
		public IActionResult OnPost()
		{
            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToPage("ViewProduct");
		}
	}
}
