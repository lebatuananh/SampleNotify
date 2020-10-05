using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleNotify.API.Request.NotifyConfigGroup;
using SampleNotify.Application.NotifyConfigGroups.Commands;
using SampleNotify.Application.NotifyConfigGroups.Queries.GetAllNotifyConfigGroup;
using SampleNotify.Application.NotifyConfigGroups.Queries.GetListNotifyConfigGroup;
using SampleNotify.Application.NotifyConfigGroups.Queries.GetNotifyConfigGroup;
using SampleNotify.Models;
using SampleNotify.Models.Entity;
using Shared.BaseModel;

namespace SampleNotify.API.Controllers
{
    public class NotifyConfigGroupController : AdminV1Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(BaseEntityResponse<NotifyConfigGroup>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddNotifyConfigGroupRequest configGroupRequest)
        {
            var result = await Mediator.Send(new AddNotifyConfigGroupCommand(configGroupRequest.Title,
                configGroupRequest.Ord, configGroupRequest.AppId));
            return Ok(result);
        }

        [HttpPut("{notifyConfigGroupId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int notifyConfigGroupId,
            UpdateNotifyConfigGroupRequest updateNotifyConfigGroupRequest)
        {
            var result = await Mediator.Send(new UpdateNotifyConfigGroupCommand(notifyConfigGroupId,
                updateNotifyConfigGroupRequest.Title,
                updateNotifyConfigGroupRequest.Ord, updateNotifyConfigGroupRequest.AppId));
            return NoContent();
        }

        [HttpDelete("{notifyConfigGroupId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int notifyConfigGroupId)
        {
            var result = await Mediator.Send(new DeleteNotifyConfigGroupCommand(notifyConfigGroupId));
            return NoContent();
        }

        [HttpGet("{notifyConfigGroupId}")]
        [ProducesResponseType(typeof(NotifyConfigGroupDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetails(int notifyConfigGroupId)
        {
            var result = await Mediator.Send(new GetNotifyConfigGroupQuery(notifyConfigGroupId));
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagingResponse<IList<NotifyConfigGroupListDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNotifyConfigGroups(string query, int pageIndex = 1, int pageSize = 10,
            string sorts = null)
        {
            var result = await Mediator.Send(new GetListNotifyConfigGroupQuery(pageIndex,
                pageSize, query, sorts));
            return Ok(result);
        }

        [HttpGet("get_all")]
        [ProducesResponseType(typeof(List<NotifyConfigGroupDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
            StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllNotifyConfigGroupQuery());
            return Ok(result);
        }
    }
}