using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Domain.Entities
{
    public class Roulette
    {
        [BsonId]
        public string Id { get; set; }
        public string State { get; set; }
        public List<BetByColor> BetsByColor { get; set; }
        public List<BetByNumber> BetsByNumber { get; set; }
        public List<IBet> WinnerBets { get; set; }
        public int WinnerNumber { get; set; }
        public string WinnerColor { get; set; }
        private const double MaxBet = 10000;
        [BsonIgnore]
        public RouletteRepository Repository;
        public Roulette(RouletteRepository repository)
        {
            BetsByColor = new List<BetByColor>();
            BetsByNumber = new List<BetByNumber>();
            WinnerBets = new List<IBet>();
            Repository = repository;
        }
        public void Open()
        {
            State = "Abierta";
            Repository.Update(roulette: this);
        }
        public bool AddBetByColor(BetByColor bet)
        {
            
            if (bet.Amount > MaxBet)
                return false;
            BetsByColor.Add(bet);
            Repository.Update(roulette: this);
            
            return true;
        }
        public bool AddBetByNumber(BetByNumber bet)
        {
            
            if (bet.Amount < 0 || bet.Amount > MaxBet)
                return false;
            BetsByNumber.Add(bet);
            Repository.Update(roulette: this);
            
            return true;
        }
        public List<IBet> Close()
        {
            State = "Cerrada";
            WinnerNumber = GenerateWinnerNumber();
            WinnerColor = IdentifyWinnerColor(number: WinnerNumber);
            SelectWinnersByColor(color: WinnerColor);
            SelectWinnersByNumber(number: WinnerNumber);
            Repository.Update(roulette: this);
            
            return WinnerBets;
        }
        private void SelectWinnersByNumber(int number)
        {
            foreach (var bet in BetsByNumber.Where(bet => bet.Number == number))
            {
                bet.CalculateTotalEarn();
                WinnerBets.Add(bet);
            }
        }
        private void SelectWinnersByColor(string color)
        {
            foreach (var bet in BetsByColor.Where(bet => bet.Color == color))
            {
                bet.CalculateTotalEarn();
                WinnerBets.Add(bet);
            }
        }
        private int GenerateWinnerNumber()
        {
            
            return new Random(Environment.TickCount).Next(0, 36);
        }
        private static string IdentifyWinnerColor(int number)
        {
            
            return number % 2 == 0 ? "Rojo" : "Negro";
        }
    }
}