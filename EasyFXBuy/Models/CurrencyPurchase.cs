namespace EasyFXBuy.Models;

public class CurrencyPurchase
{
    public string Currency { get; set; }
    public decimal Amount { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

    public CurrencyPurchase(string currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }
}