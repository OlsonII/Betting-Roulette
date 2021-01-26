using Domain.Base;

namespace Domain.Entities
{
    public class BetByNumber : Entity<string>,  IBet
    {
        public int Number { get; set; }
        private const double EarnRate = 5.0;
        public double Mount { get; set; }
        public double CalculateTotalEarn()
        {
            return Mount * EarnRate;
        }
    }
}