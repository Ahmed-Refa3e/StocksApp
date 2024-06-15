namespace StocksApp.Models
{
    public class Stock
    {
        public string? Symbol { get; set; }
        public string? CurrentPrice { get; set; }
        public string? HighestPrice { get; set; }
        public string? LowestPrice { get; set; }
        public string? OpenPrice { get; set; }
    }
}
