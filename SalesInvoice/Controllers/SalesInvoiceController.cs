using Microsoft.AspNetCore.Mvc;
using SalesInvoice.Data;
using SalesInvoice.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesInvoice.Controllers
{
    public class SalesInvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesInvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesInvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var salesInvoice = new SaleInvoice
                {
                    SalesInvoiceNo = model.SalesInvoiceNo,
                    SalesInvoiceDate = model.SalesInvoiceDate,
                    Customer = model.Customer,
                    Products = model.Products,
                    TotalAmount = model.Products.Sum(p => (p.Quantity * p.Price) - p.Discount)
                };

                _context.SalesInvoices.Add(salesInvoice);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dashboard));
            }

            return View(model);
        }

        public async Task<IActionResult> Dashboard()
        {
            var invoices = await _context.SalesInvoices.Include(si => si.Customer).ToListAsync();
            return View(invoices);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _context.SalesInvoices.Include(si => si.Customer).Include(si => si.Products).FirstOrDefaultAsync(si => si.SalesInvoiceNo == id);
            if (invoice == null)
            {
                return NotFound();
            }

            var model = new SalesInvoiceViewModel
            {
                SalesInvoiceNo = invoice.SalesInvoiceNo,
                SalesInvoiceDate = invoice.SalesInvoiceDate,
                Customer = invoice.Customer,
                Products = invoice.Products
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SalesInvoiceViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var invoice = await _context.SalesInvoices.Include(si => si.Customer).Include(si => si.Products).FirstOrDefaultAsync(si => si.SalesInvoiceNo == id);
                if (invoice == null)
                {
                    return NotFound();
                }

                invoice.SalesInvoiceNo = model.SalesInvoiceNo;
                invoice.SalesInvoiceDate = model.SalesInvoiceDate;
                invoice.Customer = model.Customer;
                invoice.Products = model.Products;
                invoice.TotalAmount = model.Products.Sum(p => (p.Quantity * p.Price) - p.Discount);

                _context.Update(invoice);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dashboard));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _context.SalesInvoices.Include(si => si.Customer).Include(si => si.Products).FirstOrDefaultAsync(si => si.SalesInvoiceNo == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.SalesInvoices.Include(si => si.Customer).Include(si => si.Products).FirstOrDefaultAsync(si => si.SalesInvoiceNo == id);
            if (invoice != null)
            {
                _context.SalesInvoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Dashboard));
        }
    }
}
