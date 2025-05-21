using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Motos.Domain.Entities
{
 public  class ApplicationRoles : IdentityRole
    {

        public string Description { get; set; }
    }
}
