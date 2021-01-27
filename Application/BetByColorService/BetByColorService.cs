using Domain.Entities;
using Domain.Repositories;
using MongoDB.Driver;

namespace Application.BetByColorService
{
    public class BetByColorService
    {
        private readonly RouletteRepository _repository;
        
        public BetByColorService(IMongoCollection<Roulette> collection)
        {
            _repository = new RouletteRepository(collection: collection);
        }
        public BetByColorResponse Execute(BetByColorRequest request, string clientId)
        {
            var searchedRoulette = _repository.Find(id: request.RouletteId);
            if (searchedRoulette == null) 
                return new BetByColorResponse(message: "Esta ruleta no se encuentra abierta");
            if (request.Color != "Rojo" && request.Color != "Negro")
                return new BetByColorResponse(message: "Por favor ingrese un color valido");
            var bet = new BetByColor {Amount = request.Amount, Color = request.Color, ClientIdentification = clientId};
            searchedRoulette.Repository = _repository;
            var betResult = searchedRoulette.AddBetByColor(bet);
            
            return betResult ? new BetByColorResponse(message: $"Apuesta a color {bet.Color} por valor de ${bet.Amount} realizada satisfactoriamente") 
                : new BetByColorResponse(message: "El valor de la apuesta debe ser un valor valido ($1 a $10.000)");
        }
    }
}