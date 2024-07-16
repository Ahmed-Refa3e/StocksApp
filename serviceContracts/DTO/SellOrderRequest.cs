using Entities;
using System.ComponentModel.DataAnnotations;

namespace serviceContracts.DTO;

public class SellOrderRequest
{
    [Required(ErrorMessage = "Stock symbol is mandatory.")]
    public string? StockSymbol { get; set; }

    [Required(ErrorMessage = "Stock name is mandatory.")]
    public string? StockName { get; set; }

    [CustomValidation(typeof(SellOrderRequest), "ValidateDateAndTimeOfOrder")]
    public DateTime DateAndTimeOfOrder { get; set; }

    [Range(1, 100000, ErrorMessage = "Quantity must be between 1 and 100000.")]
    public uint Quantity { get; set; }

    [Range(1.0, 10000.0, ErrorMessage = "Price must be between 1.0 and 10000.0.")]
    public double Price { get; set; }

    public static ValidationResult? ValidateDateAndTimeOfOrder(DateTime date, ValidationContext context)
    {
        if (date < new DateTime(2000, 1, 1))
        {
            return new ValidationResult("Date and time of order should not be older than January 01, 2000.");
        }
        return ValidationResult.Success;
    }

    public SellOrder ToSellOrder()
    {
        return new SellOrder
        {
            StockSymbol = StockSymbol,
            StockName = StockName,
            DateAndTimeOfOrder = DateAndTimeOfOrder,
            Quantity = Quantity,
            Price = Price
        };
    }
}
