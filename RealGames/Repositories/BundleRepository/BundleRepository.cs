using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.Contexts;
using RealGames.Models;

namespace RealGames.Repositories.BundleRepository
{
    public class BundleRepository: IBundleRepository
    {
            public Context _context { get; set; }

            public BundleRepository(Context context)
            {
                _context = context;
            }
            public Bundle Create(Bundle bundle)
            {
                var result = _context.Add<Bundle>(bundle);
                _context.SaveChanges();
                return result.Entity;
            }
            public Bundle Get(int Id)
            {
                return _context.Bundles.SingleOrDefault(x => x.Id == Id);
            }
            public List<Bundle> GetAll()
            {
                return _context.Bundles.ToList();
            }
            public Bundle Update(Bundle bundle)
            {
                _context.Entry(bundle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return bundle;
            }
            public Bundle Delete(Bundle bundle)
            {
                var result = _context.Remove(bundle);
                _context.SaveChanges();
                return result.Entity;
            }
    }
}

