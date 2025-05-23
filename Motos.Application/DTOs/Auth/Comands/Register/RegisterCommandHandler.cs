using MediatR;
using Microsoft.AspNetCore.Identity;
using Motos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.DTOs.Auth.Comands.Register;

public class RegisterCommandHandler : IRequestHandler<RegistroRequest, RegisterResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRoles> _roleManager; // Adicione esta injeção

    public RegisterCommandHandler(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRoles> roleManager) // Adicione ao construtor
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Correção aqui: Handle sem a tipagem explícita e usando 'await'
    public async Task<RegisterResponse> Handle(RegistroRequest request, CancellationToken cancellationToken)
    {
        

        // Validações de entrada e de role (MANTENHA ESTAS VALIDAÇÕES AQUI)
        // Lembre-se que 'request.Name' pode ser 'request.Username' dependendo do seu DTO
        var requestedRole = request.Role?.Trim();
        var allowedRoles = _roleManager.Roles.ToList();// Seus papéis permitidos

        if (string.IsNullOrEmpty(requestedRole))
        {
            return new RegisterResponse { Succeeded = false, Errors = new List<string> { "O campo 'Role' é obrigatório." } };
        }

        if (!allowedRoles.Any(r => r.Name == requestedRole))
        {
            return new RegisterResponse { Succeeded = false, Errors = new List<string> { $"O papel '{request.Role}' é inválido. Papéis permitidos: {string.Join(", ", allowedRoles)}" } };
        }

        // Validação se o papel existe no banco de dados
        if (!await _roleManager.RoleExistsAsync(requestedRole))
        {
            return new RegisterResponse { Succeeded = false, Errors = new List<string> { $"O papel '{request.Role}' não existe no sistema. Por favor, escolha um papel válido." } };
        }

        // Criação do usuário
        var user = new ApplicationUser
        {
            UserName = request.Name, // Ou request.Name, conforme seu RegisterRequest

            FullName = request.FullName  // Sua propriedade customizada
        };

        // Use await, NUNCA .Result em async void/async Task
        var createResult = await _userManager.CreateAsync(user, request.Password);

        if (!createResult.Succeeded)
        {
            return new RegisterResponse
            {
                Succeeded = false,
                Errors = createResult.Errors.Select(e => e.Description).ToList()
            };
        }

        // Adicionar o usuário ao papel (também use await)
        var roleAssignmentResult = await _userManager.AddToRoleAsync(user, requestedRole);

        if (!roleAssignmentResult.Succeeded)
        {
            // Se falhar ao adicionar a role, você pode querer reverter a criação do usuário
            // (ex: await _userManager.DeleteAsync(user);) ou logar o erro.
            return new RegisterResponse
            {
                Succeeded = false,
                Errors = roleAssignmentResult.Errors.Select(e => e.Description).ToList()
            };
        }

        return new RegisterResponse
        {
            Succeeded = true,
            UserId = user.Id,
            FullName = user.FullName // Retorne o FullName do objeto user, se desejar
        };
    }
}
