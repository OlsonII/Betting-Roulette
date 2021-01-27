using Infrastructure.Database;
using MongoDB.Driver;
using Domain.Entities;
using Domain.Repositories;
using MongoDB.Bson;

namespace Application.OpenRouletteService
{
    public class OpenRouletteService
    {
        private readonly RouletteRepository _repository;
        public OpenRouletteService(IMongoCollection<Roulette> collection)
        {
            _repository = new RouletteRepository(collection);
        }
        public OpenRouletteResponse Execute(OpenRouletteRequest request)
        {
            var searchedRoulette = _repository.Find(id: request.RouletteId);
            if (searchedRoulette == null)
                return new OpenRouletteResponse("Esta ruleta no se encuentra registrada o abierta");
            switch (searchedRoulette.State)
            {
                case "Abierta":
                    return new OpenRouletteResponse(message: "Esta ruleta ya se encuentra abierta");
                case "Cerrada":
                    return new OpenRouletteResponse(
                        message: $"Ruleta {request.RouletteId} ya se encuentra cerrada. Por favor cree una nueva.");
            }
            var roulette = new Roulette(repository: _repository) {Id = request.RouletteId};
            roulette.Open();
                
            return new OpenRouletteResponse(message: $"Ruleta {roulette.State}");
        }
    }
}