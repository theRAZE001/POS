using BillManagement.Data;
using BillManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _datacontext;
        public ProductsController(DataContext context)
        {
            _datacontext = context;
        }
        public async  Task<IActionResult> Index()
        {
            List<Product>  products = await _datacontext.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product != null)
            {
                await _datacontext.Products.AddAsync(product);
                await _datacontext.SaveChangesAsync();
            }
            return View();
        }
        [Route("{controller}/View/{Id}")]
        public IActionResult ViewProduct(int Id)
        {
            Product product = _datacontext.Products.FirstOrDefault(x => x.Id == Id);
            return View("View", product);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            Product product = await _datacontext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (product != null)
            {
                await _datacontext.Products.AddAsync(product);
                await _datacontext.SaveChangesAsync();
            }
            return View();
        }


    }
}
