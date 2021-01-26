
namespace Domain.Entities
{
    public interface IBet
    {
        double Mount { get; set; }
        double CalculateTotalEarn();
    }
}