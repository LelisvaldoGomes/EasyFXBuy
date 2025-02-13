using EasyFXBuy.Models;
using EasyFXBuy.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Adicionando suporte ao Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Registrar o serviço no DI
builder.Services.AddSingleton<ICurrencyService, CurrencyService>();

var app = builder.Build();

app.UseHttpsRedirection(); // 🔒 Redirecionamento para HTTPS

var purchasesGroup = app.MapGroup("/api/v1/purchases");

// ✅ Endpoint GET para listar compras de moedas
purchasesGroup.MapGet("/", (ICurrencyService service) =>
        Results.Ok(service.GetPurchasedCurrencies()))
    .WithName("GetAllPurchases");

// ✅ Endpoint POST para registrar uma compra de moeda
purchasesGroup.MapPost("/", (ICurrencyService service, CurrencyPurchase purchase) =>
{
    service.PurchaseCurrency(purchase);
    return Results.Created($"/api/v1/purchases/{purchase.Currency}", purchase);
}).WithName("CreatePurchase");

// ✅ Configuração mínima do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();