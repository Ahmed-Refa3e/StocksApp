using serviceContracts.DTO;

namespace serviceContracts
{
    public interface IStocksService
    {
        /// <summary>
        /// Inserts a new buy order into the database table called 'BuyOrders
        /// </summary>
        /// <param name="buyOrderRequest"></param>
        /// <returns></returns>
        Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
        /// <summary>
        /// Inserts a new sell order into the database table called 'SellOrders'.
        /// </summary>
        /// <param name="sellOrderRequest"></param>
        /// <returns></returns>

        Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);
        /// <summary>
        /// Returns the existing list of buy orders retrieved from database table called 'BuyOrders'
        /// </summary>
        /// <returns></returns>
        Task<List<BuyOrderResponse>> GetBuyOrders();
        /// <summary>
        /// Returns the existing list of sell orders retrieved from database table called 'SellOrders'.
        /// </summary>
        /// <returns></returns>
        Task<List<SellOrderResponse>> GetSellOrders();
    }
}
