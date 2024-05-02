using demoapp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using demoapp.Data;
using demoapp.Models;
using System.Threading.Tasks;

namespace demoapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseequipmentController : ControllerBase
    {
        private demoappContext _context;
        public ExerciseequipmentController(demoappContext context)
        {
            _context = context;
           
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsEquipment = _context.Exerciseequipments.ToList();
            return Ok(dsEquipment);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var equip = _context.Exerciseequipments.SingleOrDefault(lo => lo.Idm == id);
            if (equip != null)
            {
                return Ok(equip);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(ExerciseequipmentModel model)
        {
            try
            {

                var equip = new Exerciseequipment
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Date = model.Date,
                    Price = model.Price,
                    Note = model.Note
                
                };
                _context.Add(equip);
                _context.SaveChanges();
                return Ok(equip);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, ExerciseequipmentModel model)
        {
            var equip = _context.Exerciseequipments.SingleOrDefault(lo => lo.Idm == id);
            if (equip != null)
            {
                equip.Name = model.Name;
                equip.Quantity = model.Quantity;
                equip.Date = model.Date;
                equip.Price = model.Price;
                equip.Note = model.Note;
                _context.SaveChanges();
                return Ok(equip);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var equip = _context.Exerciseequipments.SingleOrDefault(lo => lo.Idm == id);
            if (equip != null)
            {
                _context.Exerciseequipments.Remove(equip);
                _context.SaveChanges();
                return Ok(equip);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
