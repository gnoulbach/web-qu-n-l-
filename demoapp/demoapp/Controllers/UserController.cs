using demoapp.Data;
using demoapp.Models;
using Google.Authenticator;
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
    public class UserController : ControllerBase
    {
        private demoappContext _context;
        public UserController(demoappContext context )
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsUser = _context.Users.ToList();
            return Ok(dsUser);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(UserModel model)
        {
            try
            {

                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Name = model.Name,
                    Age = model.Age,
                    Gender = model.Gender,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    Role = model.Role,
                    Point = model.Point,
                    Status = model.Status
                };
                _context.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, UserModel model)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (user != null)
            {
                user.Username = model.Username;
                user.Password = model.Password;
                user.Name = model.Name;
                user.Age = model.Age;
                user.Gender = model.Gender;
                user.Email = model.Email;
                user.Address = model.Address;
                user.Phone = model.Phone;
                user.Salary = model.Salary;
                user.Role = model.Role;
                user.Point = model.Point;
                user.Status = model.Status;
                _context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        //LOGIN 2FA
        private string UserKey;

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user != null)
            {
                this.UserKey = login.Username;
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                var setup = tfa.GenerateSetupCode("bach", login.Username, this.UserKey, false, 20);
                string QrCode = setup.QrCodeSetupImageUrl;

                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Oke hehehe",
                    QrCodeImageUrl = QrCode
                });
            }
            else
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = " :(( "
                });
            }
        }

        // Auth
        [HttpPost("TwoFactorAuthenticate")]
        public IActionResult TwoFactorAuthenticate(Token model)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            string userKey = model.Username;
            TimeSpan time = new TimeSpan(30);
            bool isValid = tfa.ValidateTwoFactorPIN(userKey, model.token, time, false);

            if (isValid)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Chuan khong can chinh"
                });
            }
            return Ok(new ApiResponse
            {
                Success = false,
                Message = "Nhap sai roi nhap lai di ban oi"
            });
        }
    }
}
