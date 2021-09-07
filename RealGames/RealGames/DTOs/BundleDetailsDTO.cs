using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGames.DTOs
{
    public class BundleDetailsDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public List<string> GameName { get; set; }
    }
}
