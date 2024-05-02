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
    public class MembercardController : ControllerBase
    {
        private demoappContext _context;
        public MembercardController(demoappContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsCard = _context.Membercards.ToList();
            return Ok(dsCard);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var card = _context.Membercards.SingleOrDefault(lo => lo.Idt == id);
            if (card != null)
            {
                return Ok(card);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(MembercardModel model)
        {
            try
            {

                var card = new Membercard
                {

                   UserId = model.UserId,
                   PackageId = model.PackageId,
                   Timestart = model.Timestart,
                   Timeend = model.Timeend,
                   Status = model.Status,

                };
                _context.Add(card);
                _context.SaveChanges();
                return Ok(card);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, MembercardModel model)
        {
            var card = _context.Membercards.SingleOrDefault(lo => lo.Idt == id);
            if (card != null)
            {
                card.UserId = model.UserId;
                card.PackageId = model.PackageId;
                card.Timestart = model.Timestart;
                card.Timeend = model.Timeend;
               card.Status = model.Status;
                _context.SaveChanges();
                return Ok(card);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var card = _context.Membercards.SingleOrDefault(lo => lo.Idt == id);
            if (card != null)
            {
                _context.Membercards.Remove(card);
                _context.SaveChanges();
                return Ok(card);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
