using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Roulette : Entity<string>
    {
        public string State { get; set; }
        public const double MAX_BET = 10000;
        public List<BetByColor> BetsByColor { get; set; }
        public List<BetByNumber> BetsByNumber { get; set; }
        public List<IBet> WinnerBets { get; set; }
        public Roulette()
        {
            BetsByColor = new List<BetByColor>();
            BetsByNumber = new List<BetByNumber>();
            WinnerBets = new List<IBet>();
        }
        public bool AddBetByColor(BetByColor bet)
        {
            if (bet.Mount > MAX_BET)
                return false;
            
            BetsByColor.Add(bet);
            
            return true;
        }
        public bool AddBetByNumber(BetByNumber bet)
        {
            if (bet.Mount > MAX_BET)
                return false;
            BetsByNumber.Add(bet);
            
            return true;
        }
        public void Close()
        {
            int winnerNumber = GenerateWinnerNumber();
            string winnerColor = IdentifyWinnerColor(winnerNumber);
            SelectWinnersByColor(winnerColor);
            SelectWinnersByNumber(winnerNumber);
        }
        private void SelectWinnersByNumber(int number)
        {
            
            foreach (var bet in BetsByNumber)
            {
                if (bet.Number == number)
                {
                    WinnerBets.Add(bet);
                }
            }
        }
        private void SelectWinnersByColor(string color)
        {
            
            foreach (var bet in BetsByColor)
            {
                if (bet.Color == color)
                {
                    WinnerBets.Add(bet);
                }
            }
        }
        private int GenerateWinnerNumber()
        {
            return new Random(Environment.TickCount).Next(0, 36);
        }
        private string IdentifyWinnerColor(int number)
        {
            return number % 2 == 0 ? "Rojo" : "Negro";
        }
    }
}