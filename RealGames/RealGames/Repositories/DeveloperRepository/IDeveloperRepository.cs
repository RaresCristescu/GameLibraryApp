using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.Models;

namespace RealGames.Repositories.DeveloperRepository
{
    public interface IDeveloperRepository
    {
        List<Developer> GetAll();
        Developer Get(int Id);
        Developer Create(Developer developer);
        Developer Update(Developer developer);
        Developer Delete(Developer developer);
    }
}
