using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppToGetProductsFromSQLDB.Model;
using WebAppToGetProductsFromSQLDB.Services;
using static WebAppToGetProductsFromSQLDB.Services.ProductsServices;

namespace WebAppToGetProductsFromSQLDB.Pages
{
    public class IndexModel : PageModel
    {
       public List<Products> Products;

        public void OnGet()
        {
            ProductServices productsServices = new ProductServices();
            Products = productsServices.GetProducts();
        }
    }
}