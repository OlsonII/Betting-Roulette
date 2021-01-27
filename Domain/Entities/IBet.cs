
namespace Domain.Entities
{
    public interface IBet
    {
        double Amount { get; set; }
        double Earn { get; set; }
        string ClientIdentification { get; set; }
        void CalculateTotalEarn();
    }
}