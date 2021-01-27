using Domain.Entities;
using Domain.Repositories;
using MongoDB.Driver;

namespace Application.CloseRouletteService
{
    public class CloseRouletteService
    {
        private readonly RouletteRepository _repository;
        
        public CloseRouletteService(IMongoCollection<Roulette> collection)
        {
            _repository = new RouletteRepository(collection: collection);
        }
        public CloseRouletteResponse Execute(CloseRouletteRequest request)
        {
            var searchedRoulette = _repository.Find(id: request.RouletteId);
            if (searchedRoulette == null)
                return new CloseRouletteResponse("Esta ruleta no se encuentra registrada o abierta", null);
            if (searchedRoulette.State != "Abierta") 
                return new CloseRouletteResponse(message: "Esta ruleta ya se encuentra Cerrada", winners: null);    
            searchedRoulette.Repository = _repository;
            var winners = searchedRoulette.Close();
            return new CloseRouletteResponse(message: $"Ruleta {searchedRoulette.State}. Numero ganador: {searchedRoulette.WinnerNumber}, color ganador:  {searchedRoulette.WinnerColor}", winners: winners);
        }
    }
}