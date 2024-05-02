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
    public class WorkoutpackageController : ControllerBase
    {
        private demoappContext _context;
        public WorkoutpackageController(demoappContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsPackage = _context.Workoutpackages.ToList();
            return Ok(dsPackage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var package = _context.Workoutpackages.SingleOrDefault(lo => lo.Idg == id);
            if (package != null)
            {
                return Ok(package);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(WorkoutpackageModel model)
        {
            try
            {

                var package = new Workoutpackage
                {
                    Name = model.Name,
                    Description= model.Description,
                    Timestart = model.Timestart,
                    Timeend = model.Timeend,
                    Price = model.Price,
                    Status = model.Status

                };
                _context.Add(package);
                _context.SaveChanges();
                return Ok(package);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, WorkoutpackageModel model)
        {
            var package = _context.Workoutpackages.SingleOrDefault(lo => lo.Idg == id);
            if (package != null)
            {
                package.Name = model.Name;
                package.Description = model.Description;
                package.Timestart = model.Timestart;
                package.Timeend = model.Timeend;
                package.Price = model.Price;
                package.Status = model.Status;
                _context.SaveChanges();
                return Ok(package);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var package = _context.Workoutpackages.SingleOrDefault(lo => lo.Idg == id);
            if (package != null)
            {
                _context.Workoutpackages.Remove(package);
                _context.SaveChanges();
                return Ok(package);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
