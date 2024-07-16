using Entities;
using System.ComponentModel.DataAnnotations;

namespace serviceContracts.DTO;

public class BuyOrderResponse
{ 
    public Guid BuyOrderID { get; set; }

    public string? StockSymbol { get; set; }

    public string? StockName { get; set; }

    public DateTime DateAndTimeOfOrder { get; set; }

    public uint Quantity { get; set; }

    public double Price { get; set; }
}

public static class BuyOrderExtensions
{
    public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
    {
        return new BuyOrderResponse
        {
            BuyOrderID = buyOrder.BuyOrderID,
            StockSymbol = buyOrder.StockSymbol,
            StockName = buyOrder.StockName,
            DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
            Quantity = buyOrder.Quantity,
            Price = buyOrder.Price
        };
    }
}
