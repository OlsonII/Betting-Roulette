using Domain.Base;

namespace Domain.Entities
{
    public class BetByColor : Entity<string>,  IBet
    {
        private const double EarnRate = 1.8;
        public string Color { get; set; }
        public double Mount { get; set; }
        public double CalculateTotalEarn()
        {
            return Mount * EarnRate;
        }
    }
}