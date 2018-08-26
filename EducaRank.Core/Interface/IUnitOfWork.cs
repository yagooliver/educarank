namespace EducaRank.Core.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
