using MediatR;
using Microsoft.AspNetCore.Identity;
using Motos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Motos.Domain.Services;

namespace Motos.Application.DTOs.Auth.Comands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            // 1. Encontrar o usuário pelo nome de usuário
            var user = await _userManager.FindByNameAsync(request.Name);
            if (user == null)
            {
                // Se o usuário não for encontrado, consideramos credenciais inválidas.
                // Evito expor se o usuário existe ou não por questões de segurança.
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }

            // 2. Verificar se a senha está correta
            // O 'false' no final significa que não tentaremos bloquear a conta se a tentativa de login falhar
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                // Se a senha estiver incorreta ou outras falhas de login (ex: lockout)
                if (result.IsLockedOut)
                {
                    throw new UnauthorizedAccessException("Sua conta está bloqueada. Tente novamente mais tarde.");
                }
                // Outros casos: IsNotAllowed, TwoFactorRequired, etc.
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }

            //Criando Claims
            var claims = new List<Claim>();
           
                claims.Add(new Claim("FullName", user.FullName ?? string.Empty));

            
            // 3. Se o login for bem-sucedido, gerar o JWT

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _jwtTokenService.GenerateToken(user,roles,claims);

            // 4. Retornar a resposta com o token
            return new LoginResponse
            {
                Token = token,
                Name = user.UserName // Ou user.FullName, etc.
            };
        }
    }
}
