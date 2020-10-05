using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleNotify.Application.Commands.NotifyConfigGroups;
using SampleNotify.Models.Entity;
using SampleNotify.Models.Repositories.Interfaces;
using Shared.EF.Interfaces;

namespace SampleNotify.Application.Write.NotifyConfigGroupCommandHanler
{
    public class AddNotifyConfigGroupCommandHandler : IRequestHandler<AddNotifyConfigGroupCommand>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddNotifyConfigGroupCommandHandler(INotifyConfigGroupRepository notifyConfigGroupRepository,
            IUnitOfWork unitOfWork)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(AddNotifyConfigGroupCommand request, CancellationToken cancellationToken)
        {
            _notifyConfigGroupRepository.Add(new NotifyConfigGroup(request.Title, request.Ord, request.AppId));
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}