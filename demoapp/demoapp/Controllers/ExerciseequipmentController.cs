using demoapp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using demoapp.Data;
using demoapp.Models;
using System.Threading.Tasks;
using Hangfire;
using System.Net;
using System.Net.Mail;

namespace demoapp.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseequipmentController : ControllerBase
    {
        private demoappContext _context;
        private IBackgroundJobClient _backgroundJobClient;

        public ExerciseequipmentController(demoappContext context, IBackgroundJobClient backgroundJobClient)
        {
            _context = context;
            _backgroundJobClient = backgroundJobClient;
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
                return NotFound ();
            }
        }





        //DEMO HANGFIRE 
        //Xóa ngẫu nhiên 1 phần tử trong Exerciseequipments
        [HttpDelete("delete-random")]
        public IActionResult RemoveRandom()
        {
            var random = new Random();
            var totalRecords = _context.Exerciseequipments.Count();

            if (totalRecords > 0)
            {
                var randomIndex = random.Next(0, totalRecords); // Lấy một chỉ số ngẫu nhiên
                var randomEquip = _context.Exerciseequipments.Skip(randomIndex).FirstOrDefault(); // Lấy sản phẩm ứng với chỉ số ngẫu nhiên

                if (randomEquip != null)
                {
                    _context.Exerciseequipments.Remove(randomEquip);
                    _context.SaveChanges();
                    return Ok(randomEquip);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound("No records found to delete.");
            }
        }

        // Dùng HANGFIRE hẹn giờ 1 phút gọi 1 lần
        [HttpPost("schedule-auto-delete")]
        public IActionResult ScheduleAutoDelete()
        {
            // Tạo công việc lên lịch để xóa bản ghi với id tương ứng sau 1 phút
            _backgroundJobClient.Schedule(() => RemoveRandom(), TimeSpan.FromMinutes(1));

            return Ok($"Auto deletion scheduled for record ");
        }

        [HttpPost("schedule-recurring-auto-delete")]
        public IActionResult ScheduleRecurringAutoDelete()
        {
            // Tạo công việc lên lịch để xóa bản ghi với id tương ứng mỗi 1 phút
            RecurringJob.AddOrUpdate("auto-delete-job", () => RemoveRandom(), Cron.MinuteInterval(1));

            return Ok($"Recurring auto deletion scheduled.");
        }
    }
}
