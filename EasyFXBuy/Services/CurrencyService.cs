using EasyFXBuy.Models;

namespace EasyFXBuy.Services;

public class CurrencyService : ICurrencyService
{
    private readonly List<CurrencyPurchase> _purchases = new();

    public IEnumerable<CurrencyPurchase> GetPurchasedCurrencies() => _purchases;

    public void PurchaseCurrency(CurrencyPurchase purchase)
    {
        _purchases.Add(purchase);
    }
}