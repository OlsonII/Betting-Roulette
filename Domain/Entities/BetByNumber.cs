using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class BetByNumber : IBet
    {
        public int Number { get; set; }
        [BsonIgnore]
        private const double EarnRate = 5.0;
        public double Amount { get; set; }
        public double Earn { get; set; }
        public string ClientIdentification { get; set; }
        public void CalculateTotalEarn()
        {
            Earn = Amount * EarnRate;
        }
    }
}