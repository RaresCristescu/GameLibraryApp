using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.Models;
using RealGames.Contexts;

namespace RealGames.Repositories.GameBundleRepository
{
    public class GameBundleRepository: IGameBundleRepository
    {
        public Context _context { get; set; }

        public GameBundleRepository(Context context)
        {
            _context = context;
        }
        public GameBundle Create(GameBundle gameBundle)
        {
            var result = _context.Add<GameBundle>(gameBundle);
            _context.SaveChanges();
            return result.Entity;
        }
        public GameBundle Get(int Id)
        {
            return _context.GameBundles.SingleOrDefault(x => x.Id == Id);
        }
        public List<GameBundle> GetAll()
        {
            return _context.GameBundles.ToList();
        }
        public GameBundle Update(GameBundle gameBundle)
        {
            _context.Entry(gameBundle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return gameBundle;
        }
        public GameBundle Delete(GameBundle gameBundle)
        {
            var result = _context.Remove(gameBundle);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

