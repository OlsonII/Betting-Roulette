namespace Application.BetByColorService
{
    public class BetByColorResponse
    {
        public string Message { get; set; }
        public BetByColorResponse(string message)
        {
            Message = message;
        }
    }
}