using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGames.DTOs
{
    public class GameDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string MinReq { get; set; }
        public string RecReq { get; set; }
        public int DeveloperId { get; set; }
        public List<int> CategoryId { get; set; }
    }
}
