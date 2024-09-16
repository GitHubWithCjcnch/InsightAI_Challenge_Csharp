using InsightAI.Core.Interfaces.Services;
using InsightAI.Core.Services;
using InsightAI.Infraestructure.Data;
using InsightAI.Core.Interfaces.Repositories;
using InsightAI.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Oracle.EntityFrameworkCore;
using InsightAI.Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnection"),
    b => b.MigrationsAssembly("InsightAI.Infraestructure")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEnderecoEmpresaRepository, EnderecoEmpresaRepository>();
builder.Services.AddScoped<IRamoEmpresaRepository, RamoEmpresaRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IFeedbackEmpresaRepository, FeedbackEmpresaRepository>();
builder.Services.AddScoped<IAnaliseRepository, AnaliseRepository>();

// em teoria deve funcionar pq apliquei singleton no usuariosService, então não existe a necessidade de colocar aqui...
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEnderecoEmpresaService, EnderecoEmpresaService>();
builder.Services.AddScoped<IRamoEmpresaService, RamoEmpresaService>();
builder.Services.AddScoped<IColaboradorService, ColaboradorService>();
builder.Services.AddScoped<IFeedbackEmpresaService, FeedbackEmpresaService>();
builder.Services.AddScoped<IAnaliseService, AnaliseService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Example", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Example V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
