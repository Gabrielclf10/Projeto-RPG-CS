using CSharp_Console_Game.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Console_Game.Entity
{
    public class CharacterRepository : IRepository<Character>
    {
        public List<Character> listCharacter = new List<Character>();

        public void Delete(int id)
        {
            listCharacter.RemoveAt(id);
        }

        public void Insert(Character entity)
        {
            listCharacter.Add(entity);
        }

        public List<Character> List()
        {
            return listCharacter;
        }

        public string ReturnAll()
        {
            string list = "";

            for (int i = 0; i < listCharacter.Count; i++)
            {
                list += "\n" + listCharacter[i].returnName();
            }

            return list;
        }

        public int NextId()
        {
            return listCharacter.Count;
        }

        public Character ReturnById(int id)
        {
            return listCharacter[id];
        }

        public void Update(int id, Character entity)
        {
            listCharacter[id] = entity;
        }
    }
}
