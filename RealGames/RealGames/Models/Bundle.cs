using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGames.Models
{
    public class Bundle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<GameBundle> GameBundle { get; set; }
    }
}
