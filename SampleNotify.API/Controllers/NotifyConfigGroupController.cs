using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleNotify.API.Request.NotifyConfigGroup;
using SampleNotify.Application.Commands.NotifyConfigGroups.Add;
using SampleNotify.Application.Commands.NotifyConfigGroups.Delete;
using SampleNotify.Application.Commands.NotifyConfigGroups.Update;
using SampleNotify.Application.Models;
using SampleNotify.Application.Queries.NotifyConfigGroup;
using Shared.Dto;

namespace SampleNotify.API.Controllers
{
    public class NotifyConfigGroupController : AdminV1Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddNotifyConfigGroupRequest configGroupRequest)
        {
            var result = await Mediator.Send(new AddNotifyConfigGroupCommand(configGroupRequest.Title,
                configGroupRequest.Ord, configGroupRequest.AppId));
            return NoContent();
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
        [ProducesResponseType(typeof(QueryResult<NotifyConfigGroupDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNotifyConfigGroups(string query, int skip, int take = 10)
        {
            var result = await Mediator.Send(new GetListNotifyConfigGroupQuery(skip, take, query));
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