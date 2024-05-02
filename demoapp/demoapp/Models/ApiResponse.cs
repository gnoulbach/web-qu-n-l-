using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string QrCodeImageUrl { get; set; }
    }
}
