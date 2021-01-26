using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class BetByColor : IBet
    {
        [BsonIgnore]
        private const double EarnRate = 1.8;
        public string Color { get; set; }
        public double Amount { get; set; }
        public double Earn { get; set; }
        public void CalculateTotalEarn()
        {
            Earn = Amount * EarnRate;
        }
    }
}