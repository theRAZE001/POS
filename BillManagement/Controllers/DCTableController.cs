using BillManagement.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using BillManagement.Data;
using BillManagement.DTO;

namespace BillManagement.Controllers
{
    public class DCTableController : Controller
    {
        private readonly DataContext _context;
        public static List<Product> productsList  = new List<Product>();

        public DCTableController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dcs = await _context.Dctables.ToListAsync();
            return View(dcs);
        }

        public IActionResult Create()
        {
            NewDC newDC = new NewDC();
            return View(newDC);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Dctable dctable, List<Dcproduct> dcProducts)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Dctables.Add(dctable);
                    await _context.SaveChangesAsync();

                    foreach (var dcProduct in dcProducts)
                    {
                        dcProduct.DcFk = dctable.DcPk; // Use the generated DcPk value
                        _context.Dcproducts.Add(dcProduct);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", $"Unable to save changes. {ex.Message}");
                }
            }
            ViewBag.Products = _context.Products.ToList();
            return View(dctable);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var dcTable = await _context.Dctables.FindAsync(id);
            if (dcTable == null)
            {
                return NotFound();
            }
            ViewBag.Products = _context.Products.ToList();
            var dcProducts = await _context.Dcproducts.Where(dp => dp.DcFk == id).ToListAsync();
            ViewBag.DCProducts = dcProducts;
            return View(dcTable);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Dctable dcTable, List<Dcproduct> dcProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Update(dcTable);
                await _context.SaveChangesAsync();

                var existingProducts = _context.Dcproducts.Where(dp => dp.DcFk == dcTable.DcPk).ToList();
                _context.Dcproducts.RemoveRange(existingProducts);
                await _context.SaveChangesAsync();

                foreach (var dcProduct in dcProducts)
                {
                    dcProduct.DcFk = dcTable.DcPk;
                    _context.Dcproducts.Add(dcProduct);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dcTable);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dcTable = await _context.Dctables.FindAsync(id);
            if (dcTable == null)
            {
                return NotFound();
            }
            return View(dcTable);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dcTable = await _context.Dctables.FindAsync(id);
            if (dcTable != null)
            {
                _context.Dctables.Remove(dcTable);
                var dcProducts = _context.Dcproducts.Where(dp => dp.DcFk == id).ToList();
                _context.Dcproducts.RemoveRange(dcProducts);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public void AddProductToList(Product product)
        {
            productsList.Add(product);
        }
    }
}
