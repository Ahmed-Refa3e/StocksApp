namespace serviceContracts
{
    public interface IFinnhubService
    {
        Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);

        Task<Dictionary<string, object>?> GetStockQuote(string stockSymbol);
    }

}

