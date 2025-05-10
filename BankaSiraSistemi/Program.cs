using BankaSiraSistemi.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS ve JSON ayarları
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddSingleton<SiraYonetimi>();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null; // PascalCase JSON için
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
