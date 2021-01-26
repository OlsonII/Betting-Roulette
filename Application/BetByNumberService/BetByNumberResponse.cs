namespace Application.BetByNumberService
{
    public class BetByNumberResponse
    {
        public string Message { get; set; }

        public BetByNumberResponse(string message)
        {
            Message = message;
        }
    }
}