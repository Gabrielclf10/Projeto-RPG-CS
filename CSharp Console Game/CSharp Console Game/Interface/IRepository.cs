using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Console_Game.Interface
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
        string ReturnAll();

    }
}
