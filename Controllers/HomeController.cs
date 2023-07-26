using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContract;

namespace FinnHubAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly TradingOption _option;
        private readonly IFinnhubService _finnhubService;
        public HomeController(IOptions<TradingOption> option, IFinnhubService finnhubService)
        {
            _option = option.Value;
            _finnhubService = finnhubService;

        }

        [Route("/GetStockPriceQuote")]
        public async Task<IActionResult> GetStockPriceQuote()
        {
            var result = await _finnhubService.GetStockPriceQuote(_option.DefaultStockSymbol);
            return Json(result);
        }

        [Route("/GetCompanyProfile")]
        public async Task<IActionResult> GetCompanyProfile()
        {
            var result = await _finnhubService.GetCompanyProfile(_option.DefaultStockSymbol);
            return Json(result);
        }
    }
}
