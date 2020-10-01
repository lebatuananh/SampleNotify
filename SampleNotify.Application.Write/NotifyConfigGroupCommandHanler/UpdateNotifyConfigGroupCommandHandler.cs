using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleNotify.Application.Commands.NotifyConfigGroups.Update;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;
using Shared.EF.Interfaces;

namespace SampleNotify.Application.Write.NotifyConfigGroupCommandHanler
{
    public class UpdateNotifyConfigGroupCommandHandler : IRequestHandler<UpdateNotifyConfigGroupCommand>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNotifyConfigGroupCommandHandler(INotifyConfigGroupRepository notifyConfigGroupRepository, IUnitOfWork unitOfWork)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateNotifyConfigGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _notifyConfigGroupRepository.GetByIdAsync(request.Id);
            entity.Update(request.Title, request.Ord, request.AppId);
            _notifyConfigGroupRepository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}