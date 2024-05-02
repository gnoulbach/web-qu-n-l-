using demoapp.Data;
using demoapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private demoappContext _context;
        public InvoiceController(demoappContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsInvoice = _context.Invoices.ToList();
            return Ok(dsInvoice);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var invoice = _context.Invoices.SingleOrDefault(lo => lo.Idhd == id);
            if (invoice != null)
            {
                return Ok(invoice);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(InvoiceModel model)
        {
            try
            {

                var invoice = new Invoice
                {
                    UserId = model.UserId,
                    Date = model.Date,
                    Amount = model.Amount

                };
                _context.Add(invoice);
                _context.SaveChanges();
                return Ok(invoice);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, InvoiceModel model)
        {
            var invoice = _context.Invoices.SingleOrDefault(lo => lo.Idhd == id);
            if (invoice != null)
            {
                invoice.UserId = model.UserId;
                invoice.Date = model.Date;
                invoice.Amount = model.Amount;
                _context.SaveChanges();
                return Ok( invoice);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var invoice = _context.Invoices.SingleOrDefault(lo => lo.Idhd == id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
                return Ok(invoice);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
