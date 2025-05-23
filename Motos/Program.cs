using FluentValidation;
using FluentValidation.AspNetCore;
using Motos.API;
using Newtonsoft.Json;

using Motos.CrossCutting.IoC;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(contex => contex.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}
    ).AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
//resolver dps
/*builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();*/

builder.Services.AddMemoryCache();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JWT:issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:secret"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();


builder.Services.Addinfrastruture(builder.Configuration);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Informa��es b�sicas da API no Swagger UI
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sua API de Projeto", Version = "v1" });

    // 1. Definir o esquema de seguran�a JWT Bearer
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization", // Nome do cabe�alho
        Type = SecuritySchemeType.Http, // Tipo de esquema (HTTP)
        Scheme = "Bearer", // Nome do esquema (Bearer)
        BearerFormat = "JWT", // Formato do token
        In = ParameterLocation.Header, // Onde o token ser� enviado (no cabe�alho)
        Description = "Autentica��o JWT usando o esquema Bearer.\n\nDigite 'Bearer ' [espa�o] e ent�o seu token.\n\nExemplo: \"Bearer seu.token.aqui\""
    });

    // 2. Adicionar o requisito de seguran�a para todas as opera��es
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer" // ID do esquema de seguran�a definido acima
                }
            },
            new string[] {} // Escopos necess�rios para a opera��o (vazio para JWT simples)
        }
    });

    // Se voc� adicionou Swashbuckle.AspNetCore.Annotations:
    // options.EnableAnnotations(); // Habilita o uso de atributos como [SwaggerOperation], [SwaggerParameter]
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ConfigureExeptionHandler();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication(); // DEVE VIR ANTES DE app.UseAuthorization()
app.UseAuthorization();

app.MapControllers();

app.Run();
