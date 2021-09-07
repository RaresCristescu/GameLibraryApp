using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealGames.DTOs;
using RealGames.Models;
using RealGames.Repositories.GameRepository;
using RealGames.Repositories.GameCategoryRepository;
using RealGames.Repositories.CategoryRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public IGameRepository IGameRepository { get; set; }
        public ICategoryRepository ICategoryRepository { get; set; }
        public IGameCategoryRepository IGameCategoryRepository { get; set; }
        public GameController(IGameRepository gameRepository, ICategoryRepository categoryRepository, IGameCategoryRepository gameCategoryRepository)
        {
            IGameRepository = gameRepository;
            ICategoryRepository = categoryRepository;
            IGameCategoryRepository = gameCategoryRepository;
        }
        // GET: api/<AlbumController>
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return IGameRepository.GetAll();
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public GameDetailsDTO Get(int id)
        {
            Game Game = IGameRepository.Get(id);
            GameDetailsDTO MyGame = new GameDetailsDTO()
            {
                Name = Game.Name,
                Price = Game.Price,
                Description = Game.Description,
                MinReq = Game.MinReq,
                RecReq = Game.RecReq,
                DeveloperId = Game.DeveloperId
            };
            IEnumerable<GameCategory> MyGameCategories = IGameCategoryRepository.GetAll().Where(x => x.GameId == Game.Id);
            if (MyGameCategories != null)
            {
                List<string> CategoryNameList = new List<string>();
                foreach (GameCategory MyGameCategory in MyGameCategories)
                {
                    Category MyCategory = ICategoryRepository.GetAll().SingleOrDefault(x => x.Id == MyGameCategory.CategoryId);
                    CategoryNameList.Add(MyCategory.Name);
                }
                MyGame.CategoryName = CategoryNameList;
            }
 
            return MyGame;
        }

        // POST api/<AlbumController>
        [HttpPost]
        public void Post(GameDTO value)
        {
            Game model = new Game()
            {
                Name = value.Name,
                Price = value.Price,
                Description = value.Description,
                MinReq = value.MinReq,
                RecReq = value.RecReq,
                DeveloperId = value.DeveloperId
            };
            IGameRepository.Create(model);
            for (int i = 0; i < value.CategoryId.Count; i++)
            {
                GameCategory GameCategory = new GameCategory()
                {
                    GameId = model.Id,
                    CategoryId = value.CategoryId[i]
                };
                IGameCategoryRepository.Create(GameCategory);
            }
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public void Put(int id, GameDTO value)
        {
            Game model = IGameRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Price != 0.0)
            {
                model.Price = value.Price;
            }
            if (value.Description != null)
            {
                model.Description = value.Description;
            }
            if (value.MinReq != null)
            {
                model.MinReq = value.MinReq;
            }
            if (value.RecReq != null)
            {
                model.RecReq = value.RecReq;
            }
            if (value.DeveloperId != 0)
            {
                model.DeveloperId = value.DeveloperId;
            }

            IGameRepository.Update(model);

            if (value.CategoryId != null)
            {
                IEnumerable<GameCategory> MyGameCategories = IGameCategoryRepository.GetAll().Where(x => x.GameId == id);
                foreach (GameCategory MyGameCategory in MyGameCategories)
                {
                    IGameCategoryRepository.Delete(MyGameCategory);
                }
                for (int i = 0; i < value.CategoryId.Count; i++)
                {
                    GameCategory GameCategory = new GameCategory()
                    {
                        GameId = model.Id,
                        CategoryId = value.CategoryId[i]
                    };
                    IGameCategoryRepository.Create(GameCategory);
                }
            }
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public Game Delete(int id)
        {
            Game game = IGameRepository.Get(id);
            return IGameRepository.Delete(game);
        }
    }
}
