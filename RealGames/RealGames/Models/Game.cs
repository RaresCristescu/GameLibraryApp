using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string MinReq { get; set; }
        public string RecReq { get; set; }
        public int DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }
        public List<GameBundle> GameBundle { get; set; }
        public List<GameCategory> GameCategory { get; set; }


    }
}
