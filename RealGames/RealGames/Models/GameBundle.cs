using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGames.Models
{
    public class GameBundle
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int BundleId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Bundle Bundle { get; set; }
    }
}
