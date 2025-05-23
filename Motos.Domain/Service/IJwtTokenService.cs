using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Motos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Domain.Services;

public interface IJwtTokenService
{
    Task<string> GenerateToken(ApplicationUser user, IList<string> role, IList<Claim> additionalClaims = null);
   

}
