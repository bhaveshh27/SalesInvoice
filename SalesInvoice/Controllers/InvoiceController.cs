using Microsoft.AspNetCore.Mvc;
using SalesInvoice.Models;

namespace SalesInvoice.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

    }
}
