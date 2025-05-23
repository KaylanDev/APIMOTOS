using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.DTOs.Auth.Comands.Login
{
  public  class LoginResponse
    {
        public string Token { get; set; }
        public string Name { get; set; }
    }
}
