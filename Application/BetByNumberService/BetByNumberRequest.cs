namespace Application.BetByNumberService
{
    public class BetByNumberRequest
    {
        public string RouletteId { get; set; }
        public double Amount { get; set; }
        public int Number { get; set; }
    }
}