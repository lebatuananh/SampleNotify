using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.EF.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
    }
}