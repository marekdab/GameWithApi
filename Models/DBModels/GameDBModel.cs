using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL;

namespace Models.DBModels
{
    public class GameDBModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string Password { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }


        public GameDBModel CreateFromGameModel(Game game)
        {
            RoomDAL _roomDAL = new RoomDAL();

            GameDBModel tempModel = new GameDBModel();

            tempModel.Id = game.Id;
            tempModel.Name = game.Name;
            tempModel.Time = game.Time;
            tempModel.Password = game.Password;
            tempModel.RoomName = _roomDAL.Get(Convert.ToInt32(game.Room)).Name;
            tempModel.Description = game.Description;


            return tempModel;
        }
    }
}
