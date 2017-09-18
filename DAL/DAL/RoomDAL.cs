using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class RoomDAL
    {
        public Room Add(Room model)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                var m = ctx.Room.Add(new Room()
                {
                    Name = model.Name,
                    Password = model.Password,
                    CreatorId = model.CreatorId
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
                var ic = ctx.Room.Where(x => x.Id == id).FirstOrDefault();
                ctx.Room.Remove(ic);
                ctx.SaveChanges();
            }
        }

        public Room Get(int RoomId)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                return ctx.Room.Where(x => x.Id == RoomId).FirstOrDefault();
            }
        }

        public List<Room> GetAll()
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                return ctx.Room.ToList();
            }
        }

        public Room Update(Room model)
        {
            using (GameApiEntities ctx = new GameApiEntities())
            {
                var ic = ctx.Room.Where(x => x.Id == model.Id).FirstOrDefault();
                ic.CreatorId = model.CreatorId;
                ic.Name = model.Name;
                ic.Password = model.Password;
                ctx.SaveChanges();
                return model;
            }
        }
    }
}
