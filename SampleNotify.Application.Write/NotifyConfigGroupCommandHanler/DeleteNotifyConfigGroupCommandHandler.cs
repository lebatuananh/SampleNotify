using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleNotify.Application.Commands.NotifyConfigGroups.Delete;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;
using Shared.EF.Interfaces;

namespace SampleNotify.Application.Write.NotifyConfigGroupCommandHanler
{
    public class DeleteNotifyConfigGroupCommandHandler : IRequestHandler<DeleteNotifyConfigGroupCommand>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotifyConfigGroupCommandHandler(INotifyConfigGroupRepository notifyConfigGroupRepository,
            IUnitOfWork unitOfWork)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteNotifyConfigGroupCommand request, CancellationToken cancellationToken)
        {
            _notifyConfigGroupRepository.Delete(request.Id);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}