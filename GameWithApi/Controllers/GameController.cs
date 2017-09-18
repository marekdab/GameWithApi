using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.DAL;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Models.DBModels;

namespace GameWithApi.Controllers
{
    public class GameController : ApiController
    {
        GameDAL _gameDAL = new GameDAL();

        public string Get(int Id)
        {
            Game games = _gameDAL.Get(Id);

            GameDBModel gameDB = new GameDBModel();
            gameDB = gameDB.CreateFromGameModel(games);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(gameDB);



            return json;
        }

        public List<string> Get()
        {
            List<Game> games = _gameDAL.GetAll();
            List<string> result = new List<string>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            GameDBModel gameDB = new GameDBModel();

            foreach (var Game in games)
            {
                gameDB = gameDB.CreateFromGameModel(Game);
                result.Add(js.Serialize(gameDB));
            }


            return result;
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            _gameDAL.Delete(Id);
        }

        [HttpPost]
        public void Post([FromBody]Game game)
        {
            _gameDAL.Add(game);
        }
    }
}
