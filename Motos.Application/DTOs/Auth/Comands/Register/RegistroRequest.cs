using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.DTOs.Auth.Comands.Register
{
   public class RegistroRequest : IRequest<RegisterResponse>
{
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
