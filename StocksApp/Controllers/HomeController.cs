using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;

namespace StocksApp.Controllers
{
    public class HomeController(Finhubservice finhubservice, IOptions<TradingOptions> tradingOptions) : Controller
    {
        private readonly Finhubservice _finhubservice = finhubservice;
        private readonly IOptions<TradingOptions> _tradingOptions = tradingOptions;

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.Apple == null)
            {
                throw new InvalidOperationException("No stock symbol provided");
            }
            Dictionary<string, object>? stockQuote = await _finhubservice.GetStockQuote(_tradingOptions.Value.Apple);

            if (stockQuote == null)
            {
                throw new InvalidOperationException("No stock quote found");
            }

            Stock stock = new()
            {
                Symbol = _tradingOptions.Value.Apple,
                CurrentPrice = Convert.ToString(stockQuote["c"]),
                HighestPrice = Convert.ToString(stockQuote["h"]),
                LowestPrice = Convert.ToString(stockQuote["l"]),
                OpenPrice = Convert.ToString(stockQuote["o"])
            };
            return View(stock);
        }
    }
}
