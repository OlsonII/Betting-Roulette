using System.Collections.Generic;
using Domain.Entities;

namespace Application.CloseRouletteService
{
    public class CloseRouletteResponse
    {
        public string Message { get; set; }
        public List<IBet> Winners { get; set; }
        public CloseRouletteResponse(string message, List<IBet> winners)
        {
            Message = message;
            Winners = winners;
        }
    }
}