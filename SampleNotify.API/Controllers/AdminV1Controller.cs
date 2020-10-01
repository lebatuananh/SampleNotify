using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SampleNotify.API.Controllers
{
    [ApiController]
    [Route("api/admin/v1/[controller]")]
    public abstract class AdminV1Controller : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}