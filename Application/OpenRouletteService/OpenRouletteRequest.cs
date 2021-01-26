namespace Application.OpenRouletteService
{
    public class OpenRouletteRequest
    {
        public string RouletteId { get; set; }

        public OpenRouletteRequest(string rouletteId)
        {
            RouletteId = rouletteId;
        }
    }
}