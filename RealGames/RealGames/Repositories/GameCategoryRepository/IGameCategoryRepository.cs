﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.Models;

namespace RealGames.Repositories.GameCategoryRepository
{
    public interface IGameCategoryRepository
    { 
        List<GameCategory> GetAll();
        GameCategory Get(int Id);
        GameCategory Create(GameCategory gameCategory);
        GameCategory Update(GameCategory gameCategory);
        GameCategory Delete(GameCategory gameCategory);
    }
}
