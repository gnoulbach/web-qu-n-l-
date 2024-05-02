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
    public class InvoicedetailController : ControllerBase
    {
        private demoappContext _context;
        public InvoicedetailController(demoappContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsDetail = _context.Invoicedetails.ToList();
            return Ok(dsDetail);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var detail = _context.Invoicedetails.SingleOrDefault(lo => lo.Idch == id);
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(InvoicedetailModel model)
        {
            try
            {

                var detail = new Invoicedetail
                {
                    InvoiceId = model.InvoiceId,
                    PackageId = model.PackageId,


                };
                _context.Add(detail);
                _context.SaveChanges();
                return Ok(detail);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, InvoicedetailModel model)
        {
            var detail = _context.Invoicedetails.SingleOrDefault(lo => lo.Idch == id);
            if (detail != null)
            {
                detail.InvoiceId = model.InvoiceId;
                detail.PackageId = model.PackageId;
                _context.SaveChanges();
                return Ok(detail);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var detail = _context.Invoicedetails.SingleOrDefault(lo => lo.Idch == id);
            if (detail != null)
            {
                _context.Invoicedetails.Remove(detail);
                _context.SaveChanges();
                return Ok(detail);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
