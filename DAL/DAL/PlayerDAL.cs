using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class PlayerDAL
    {
        public Player Add(Player model)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                var m = ctx.Player.Add(new Player()
                {
                    Nick = model.Nick
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
                var ic = ctx.Player.Where(x => x.Id == id).FirstOrDefault();
                ctx.Player.Remove(ic);
                ctx.SaveChanges();
            }
        }

        public Player Get(int PlayerId)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                return ctx.Player.Where(x => x.Id == PlayerId).FirstOrDefault();
            }
        }

        public Player GetByName(string PlayerName)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                return ctx.Player.Where(x => x.Nick.Contains(PlayerName)).FirstOrDefault();
            }
        }

        public List<Player> GetAll()
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                return ctx.Player.ToList();
            }
        }

        public Player Update(Player model)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                var ic = ctx.Player.Where(x => x.Id == model.Id).FirstOrDefault();
                ic.Nick = model.Nick;
                ic.Room = model.Room;
                ctx.SaveChanges();
                return model;
            }
        }

    }
}
