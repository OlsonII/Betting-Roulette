namespace Application.OpenRouletteService
{
    public class OpenRouletteResponse
    {
        public string Message { get; set; }
        public OpenRouletteResponse(string message)
        {
            Message = message;
        }
    }
}