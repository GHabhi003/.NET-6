using FinnHubAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContract;

namespace FinnHubAssignment.Controllers
{
    public class TradeController : Controller
    {
        private readonly IFinnhubService _finnhubService;
        private readonly IOptions<TradingOption> _options;
        private readonly IStocksService _stocksService;
        public TradeController(IFinnhubService finnHubService, IStocksService stockService, IOptions<TradingOption> options)
        {
            _finnhubService = finnHubService;
            _options = options;
            _stocksService = stockService;

        }
        [Route("Trade/Index")]
        public async Task<IActionResult> Index()
        {
            var profile = await _finnhubService.GetCompanyProfile(_options.Value.DefaultStockSymbol);
            var quote = await _finnhubService.GetStockPriceQuote(_options.Value.DefaultStockSymbol);

            StockTrade stockTrade = new StockTrade()
            {
                StockSymbol = _options.Value.DefaultStockSymbol,
                Price = Convert.ToDouble(quote?["c"].ToString()),
                Quantity = 100,
                StockName = profile?["name"].ToString() 
            };

            return Json(stockTrade);
        }
    }
}
