using Domain.Entities;
using Domain.Repositories;
using MongoDB.Driver;

namespace Application.CreateRoulette
{
    public class CreateRouletteService
    {
        private readonly RouletteRepository _repository;
        public CreateRouletteService(IMongoCollection<Roulette> collection)
        {
            _repository = new RouletteRepository(collection);
        }
        public CreateRouletteResponse Execute()
        {
            var newRouletteId = (_repository.Find().Count + 1).ToString();
            var newRoulette = new Roulette(_repository) {Id = newRouletteId};
            _repository.Insert(newRoulette);
            return new CreateRouletteResponse($"Ruleta con ID {newRouletteId} creada satisfactoriamente", newRouletteId);
        }
    }
}