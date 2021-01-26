namespace Application.BetByColorService
{
    public class BetByColorRequest
    {
        public string RouletteId { get; set; }
        public double Amount { get; set; }
        public string Color { get; set; }
    }
}