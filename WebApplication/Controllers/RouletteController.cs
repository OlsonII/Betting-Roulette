using Application.OpenRouletteService;
using Application.BetByColorService;
using Application.BetByNumberService;
using Application.CloseRouletteService;
using Application.SearchRoulettesService;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : Controller
    {
        private readonly IMongoCollection<Roulette> _rouletteCollection;
        public RouletteController(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _rouletteCollection = database.GetCollection<Roulette>(settings.CollectionName);
        }
        [HttpPost]
        public ActionResult<OpenRouletteResponse> OpenRoulette(OpenRouletteRequest request)
        {
            var openRouletteService = new OpenRouletteService(_rouletteCollection);
            return Ok(openRouletteService.Execute(request));
        }
        [HttpPut]
        public ActionResult<CloseRouletteResponse> CloseRoulette(CloseRouletteRequest request)
        {
            var closeRouletteService = new CloseRouletteService(_rouletteCollection);
            return Ok(closeRouletteService.Execute(request));
        }
        [HttpPut("BetByColor")]
        public ActionResult<BetByColorResponse> RegisterBetByColor(BetByColorRequest request)
        {
            var closeRouletteService = new BetByColorService(_rouletteCollection);
            return Ok(closeRouletteService.Execute(request));
        }
        [HttpPut("BetByNumber")]
        public ActionResult<BetByNumberResponse> RegisterBetByNumber(BetByNumberRequest request)
        {
            var closeRouletteService = new BetByNumberService(_rouletteCollection);
            return Ok(closeRouletteService.Execute(request));
        }
        [HttpGet]
        public ActionResult<SearchRouletteResponse> SearchRoulettes()
        {
            var searchRouletteService = new SearchRouletteService(_rouletteCollection);
            return Ok(searchRouletteService.Execute());
        }
    }
}