using System.Collections.Generic;
using Domain.Entities;
using MongoDB.Driver;

namespace Domain.Repositories
{
    public class RouletteRepository
    {
        private IMongoCollection<Roulette> Collection { get; set; }
        public RouletteRepository(IMongoCollection<Roulette> collection)
        {
            Collection = collection;
        }
        public void Insert(Roulette roulette)
        {
            Collection.InsertOne(roulette);
        }
        public void Update(Roulette roulette)
        {
            Collection.ReplaceOne(r => r.Id == roulette.Id, roulette);
        }
        public Roulette Find(string id)
        {
            return Collection.Find(r => r.Id == id)
                .FirstOrDefault();
        }
        public List<Roulette> Find()
        {
            return Collection.Find(r => true).ToList();
        }
    }
}