using BankaSiraSistemi.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS ve JSON ayarları
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddSingleton<SiraYonetimi>();

// PascalCase JSON desteği
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});

var app = builder.Build();

app.UseCors("AllowAll");

// wwwroot klasöründen statik dosyaları (HTML, JS, CSS) sun
app.UseStaticFiles();

app.UseRouting();

// API controller'ları aktifleştir
app.MapControllers();

// ✅ Ana sayfa yönlendirmesi (önemli!)
app.MapGet("/", () =>
{
    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/index.html");
    return Results.File(path, "text/html");
});


app.Run();
