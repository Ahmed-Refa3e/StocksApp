using Entities;
using System.ComponentModel.DataAnnotations;

namespace serviceContracts.DTO;

public class BuyOrderRequest
{
    [Required(ErrorMessage = "StockSymbol can't be null")]
    public string? StockSymbol { get; set; }
    [Required(ErrorMessage = "StockName can't be null")]
    public string? StockName { get; set; }

    [CustomValidation(typeof(SellOrderRequest), "ValidateDateAndTimeOfOrder")]
    public DateTime DateAndTimeOfOrder { get; set; }

    [Range(1, 100000, ErrorMessage = "Value should be between 1 and 100000")]
    public uint Quantity { get; set; }

    [Range(1, 10000, ErrorMessage = "Value should be between 1 and 10000")]
    public double Price { get; set; }

    public static ValidationResult? ValidateDateAndTimeOfOrder(DateTime date, ValidationContext context)
    {
        if (date < new DateTime(2000, 1, 1))
        {
            return new ValidationResult("Date and time of order should not be older than January 01, 2000.");
        }
        return ValidationResult.Success;
    }

    public BuyOrder ToBuyOrder()
    {
        return new BuyOrder
        {
            StockSymbol = StockSymbol,
            StockName = StockName,
            DateAndTimeOfOrder = DateAndTimeOfOrder,
            Quantity = Quantity,
            Price = Price
        };
    }
}
