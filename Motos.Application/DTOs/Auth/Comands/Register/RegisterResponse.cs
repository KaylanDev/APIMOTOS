using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.DTOs.Auth.Comands.Register
{
   public class RegisterResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
        public string UserId { get; set; }
        public string FullName { get; set; }
    }
}
