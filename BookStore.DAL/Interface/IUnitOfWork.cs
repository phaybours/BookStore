using System.Threading.Tasks;

namespace BookStore.DAL.Interface
{
    public interface IUnitOfWork
    {
        Task<int> Commit(int userId);

        int CommitNonAsync(int userId);
    }
}
