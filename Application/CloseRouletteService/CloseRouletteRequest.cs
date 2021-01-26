namespace Application.CloseRouletteService
{
    public class CloseRouletteRequest
    {
        public string RouletteId { get; set; }

        public CloseRouletteRequest(string rouletteId)
        {
            RouletteId = rouletteId;
        }
    }
}