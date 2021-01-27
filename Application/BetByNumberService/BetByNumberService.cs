using Domain.Entities;
using Domain.Repositories;
using MongoDB.Driver;

namespace Application.BetByNumberService
{
    public class BetByNumberService
    {
        private readonly RouletteRepository _repository;
        public BetByNumberService(IMongoCollection<Roulette> collection)
        {
            _repository = new RouletteRepository(collection: collection);
        }
        public BetByNumberResponse Execute(BetByNumberRequest request, string clientId)
        {
            var searchedRoulette = _repository.Find(id: request.RouletteId);
            if (searchedRoulette == null) 
                return new BetByNumberResponse(message: "Esta ruleta no se encuentra abierta");
            if (request.Number < 0 || request.Number > 36)
                return new BetByNumberResponse(message: "Por favor ingrese un numero valido de 0 a 36");
            var bet = new BetByNumber() {Amount = request.Amount, Number = request.Number, ClientIdentification = clientId};
            searchedRoulette.Repository = _repository;
            var betResult = searchedRoulette.AddBetByNumber(bet: bet);
            
            return betResult ? new BetByNumberResponse(message: $"Apuesta a numero {bet.Number} por valor de ${bet.Amount} realizada satisfactoriamente") 
                : new BetByNumberResponse(message: "El valor de la apuesta debe ser un valor valido");
        }
    }
}