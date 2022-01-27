using RPG_CS.src.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    public class HeroRepository : IRepository<Hero>
    {
        private List<Hero> listHero = new List<Hero>();

        public void Update(int id, Hero entity)
        {
            listHero[id] = entity;
        }

        public void Delete(int id)
        {
            listHero[id].DeleteThis();
        }

        public void Insert(Hero entity)
        {
            listHero.Add(entity);
        }

        public List<Hero> List()
        {    
                return listHero;           
        }

        public int NextId()
        {
            return listHero.Count;
        }

        public Hero ReturnById(int id)
        {
            return listHero[id];
        }
    }
}
