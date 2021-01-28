using Domain.Entities;
using Domain.Repositories;
using MongoDB.Driver;

namespace Application.SearchRoulettesService
{
    public class SearchRouletteService
    {
        private readonly RouletteRepository _repository;
        public SearchRouletteService(IMongoCollection<Roulette> collection)
        {
            _repository = new RouletteRepository(collection);
        }
        public SearchRouletteResponse Execute()
        {
            
            return new SearchRouletteResponse(roulettes: _repository.Find());
        }
    }
}