namespace Application.CreateRoulette
{
    public class CreateRouletteResponse
    {
        public string Message { get; set; }
        public string RouletteId { get; set; }
        public CreateRouletteResponse(string message, string rouletteId)
        {
            Message = message;
            RouletteId = rouletteId;
        }
    }
}