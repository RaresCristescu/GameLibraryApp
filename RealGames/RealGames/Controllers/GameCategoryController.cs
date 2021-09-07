using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.DTOs;
using RealGames.Models;
using RealGames.Repositories.GameCategoryRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCategoryController : ControllerBase
    {
        public IGameCategoryRepository IGameCategoryRepository { get; set; }

        public GameCategoryController(IGameCategoryRepository repository)
        {
            IGameCategoryRepository = repository;
        }



        // GET: api/<StudioController>
        [HttpGet]
        public ActionResult<IEnumerable<GameCategory>> Get()
        {
            return IGameCategoryRepository.GetAll();
        }

        // GET api/<StudioController>/5
        [HttpGet("{id}")]
        public ActionResult<GameCategory> Get(int id)
        {
            return IGameCategoryRepository.Get(id);
        }

        // POST api/<StudioController>
        [HttpPost]
        public GameCategory Post(GameCategoryDTO value)
        {
            GameCategory model = new GameCategory()
            {
                GameId = value.GameId,
                CategoryId = value.CategoryId
            };
            return IGameCategoryRepository.Create(model);
        }

        // PUT api/<StudioController>/5
        [HttpPut("{id}")]
        public GameCategory Put(int id, GameCategoryDTO value)
        {
            GameCategory model = IGameCategoryRepository.Get(id);
            if (value.GameId != 0)
            {
                model.GameId = value.GameId;
            }

            if (value.CategoryId != 0)
            {
                model.CategoryId = value.CategoryId;
            }

            return IGameCategoryRepository.Update(model);
        }

        // DELETE api/<StudioController>/5
        [HttpDelete("{id}")]
        public GameCategory Delete(int id)
        {
            GameCategory gameCategory = IGameCategoryRepository.Get(id);
            return IGameCategoryRepository.Delete(gameCategory);

        }
    }
}
