using System.Collections.Generic;
using Domain.Entities;

namespace Application.SearchRoulettesService
{
    public class SearchRouletteResponse
    {
        public List<Roulette> Roulettes { get; }
        public SearchRouletteResponse(List<Roulette> roulettes)
        {
            Roulettes = roulettes;
        }
    }
}