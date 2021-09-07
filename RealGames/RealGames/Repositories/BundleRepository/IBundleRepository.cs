using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.Models;

namespace RealGames.Repositories.BundleRepository
{
    public interface IBundleRepository
    {
        List<Bundle> GetAll();
        Bundle Get(int Id);
        Bundle Create(Bundle bundle);
        Bundle Update(Bundle bundle);
        Bundle Delete(Bundle bundle);
    }
}
