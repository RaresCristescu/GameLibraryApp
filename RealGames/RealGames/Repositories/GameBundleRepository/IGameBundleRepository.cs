using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.Models;

namespace RealGames.Repositories.GameBundleRepository
{
    public interface IGameBundleRepository
    {
        List<GameBundle> GetAll();
        GameBundle Get(int Id);
        GameBundle Create(GameBundle gameBundle);
        GameBundle Update(GameBundle gameBundle);
        GameBundle Delete(GameBundle gameBundle);
    }
}
