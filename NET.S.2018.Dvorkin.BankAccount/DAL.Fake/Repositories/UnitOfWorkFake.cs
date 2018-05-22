using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class UnitOfWorkFake:IUnitOfWork
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}