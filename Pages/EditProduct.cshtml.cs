using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using MiniShopRazor.Data;
using MiniShopRazor.Models;
using MiniShopRazor.ModelView;
using System.Collections.Generic;

namespace MiniShopRazor.Pages
{
    public class EditProductModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Product p { get; set; }
        public List<Company> c= _db.Companies.ToList();
        
        public void OnGet(int id)
        {
            if (id != null && id != 0)
            {
                p=_db.Products.FirstOrDefault(p => p.Id == id);
            }
        }
        public IActionResult OnPost()
        {
            Product pd = _db.Products.FirstOrDefault(p => p.Id == p.Id);
            pd.Name = p.Name;
            pd.Description = p.Description;
            pd.Price = p.Price;
            pd.Quantity = p.Quantity;
            pd.EnableSize = p.EnableSize;
            pd.CompanyId = p.CompanyId;
            _db.Products.Update(p);
            _db.SaveChanges();
            return RedirectToPage("ViewProduct");
        }
    }
}
