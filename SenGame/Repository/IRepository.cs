using System.Collections.Generic;

namespace SenGame.Repository
{
    public interface IRepository
    {
        public void Create<T>(T T1);
        public List<T> ReadAll<T>();
        public T Read<T>(int _id);

        public T Update<T>(int _id);
        public T Delete<T>(int _id);
        public void SaveChanges();
    }
}
