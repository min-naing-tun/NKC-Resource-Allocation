using Microsoft.EntityFrameworkCore;
using NKC_Resource_Allocation;
using NKC_Resource_Allocation.Database.CoreService;
using NKC_Resource_Allocation.Database.Helper;
using NKC_Resource_Allocation.Middleware;
using NKC_Resource_Allocation.Repositories;
using NKC_Resource_Allocation.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Connectin string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<NKC_DbContext>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();


builder.Services.AddScoped<QueryHelper>();
builder.Services.AddScoped<CoreService>();
builder.Services.AddScoped<OutletRepository>();
builder.Services.AddScoped<AuditorRepository>();
builder.Services.AddScoped<DocumentRepository>();
builder.Services.AddScoped<FormRepository>();

// Bind individual keys from root
builder.Services.Configure<KeyConfig>(builder.Configuration);


builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddResponseCompression();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseMiddleware<Guard>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCompression();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());

app.Run();
