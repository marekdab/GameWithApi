using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class GameDAL
    {
        public Game Add(Game model)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                var m = ctx.Game.Add(new Game()
                {
                    Name = model.Name,
                    Password = model.Password,
                    Time = model.Time,
                    Room = model.Room,
                    Description = model.Description
                });//tu dodajemy model
                ctx.SaveChanges();//tu zapisujemy zmiany
                model.Id = m.Id;
                ctx.SaveChanges();
                return model;
            }
        }

        public void Delete(int id)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                var ic = ctx.Game.Where(x => x.Id == id).FirstOrDefault();
                ctx.Game.Remove(ic);
                ctx.SaveChanges();
            }
        }

        public Game Get(int GameId)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                return ctx.Game.Where(x => x.Id == GameId).FirstOrDefault();
            }
        }

        public List<Game> GetAll()
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                return ctx.Game.ToList();
            }
        }

        public Game Update(Game model)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                var ic = ctx.Game.Where(x => x.Id == model.Id).FirstOrDefault();
                ic.Name = model.Name;
                ic.Password = model.Password;
                ic.Room = model.Room;
                ic.Description = model.Description;
                ctx.SaveChanges();
                return model;
            }
        }
    }
}
