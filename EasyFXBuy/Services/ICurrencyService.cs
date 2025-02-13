using EasyFXBuy.Models;

namespace EasyFXBuy.Services;

public interface ICurrencyService
{
    IEnumerable<CurrencyPurchase> GetPurchasedCurrencies();
    void PurchaseCurrency(CurrencyPurchase purchase);
}