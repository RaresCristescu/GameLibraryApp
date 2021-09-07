using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.DTOs;
using RealGames.Models;
using RealGames.Repositories.GameBundleRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameBundleController : ControllerBase
    {
        public IGameBundleRepository IGameBundleRepository { get; set; }

        public GameBundleController(IGameBundleRepository repository)
        {
            IGameBundleRepository = repository;
        }
        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<GameBundle>> Get()
        {
            return IGameBundleRepository.GetAll();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<GameBundle> Get(int id)
        {
            return IGameBundleRepository.Get(id);
        }

        // POST api/<SongController>
        [HttpPost]
        public GameBundle Post(GameBundleDTO value)
        {
            GameBundle model = new GameBundle
            {
                GameId = value.GameId,
                BundleId = value.BundleId
            };
            return IGameBundleRepository.Create(model);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public GameBundle Put(int id, GameBundleDTO value)
        {
            GameBundle model = IGameBundleRepository.Get(id);
            if (value.GameId != 0)
            {
                model.GameId = value.GameId;
            }
            if (value.BundleId != 0)
            {
                model.BundleId = value.BundleId;
            }
            return IGameBundleRepository.Update(model);
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public GameBundle Delete(int id)
        {
            GameBundle model = IGameBundleRepository.Get(id);
            return IGameBundleRepository.Delete(model);
        }
    }
}
