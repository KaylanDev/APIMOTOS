using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.DTOs.Auth.Comands.Login
{
  public  class LoginRequest : IRequest<LoginResponse>
 
    {
        public string  Name { get; set; }
        public string Password { get; set; }

    }
}
