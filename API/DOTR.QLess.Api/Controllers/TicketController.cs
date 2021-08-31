using DOTR.QLess.Application.Ticket.CreateTicket;
using DOTR.QLess.Application.Ticket.GetTicketById;
using DOTR.QLess.Application.Ticket.GetTicketByNumber;
using DOTR.QLess.Application.Ticket.Shared;
using DOTR.QLess.Application.Ticket.SimulateTravel;
using DOTR.QLess.Application.TicketType.GetTicketTypesQuery;
using DOTR.QLess.Application.TicketType.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DOTR.QLess.Api.Controllers
{
    public class TicketController : ApiController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateTicketCommand command)
        {
            var tid = await Mediator.Send(command);
            return CreatedAtRoute("GetById", new { id = tid }, tid);
        }

        [HttpGet("{id}",Name = "GetById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TicketDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTicketById(){ TicketId = id }));
        }

        [HttpGet("GetByNumber")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TicketDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery]string ticketNumber)
        {
            return Ok(await Mediator.Send(new GetTicketByNumber(){ TicketNumber = ticketNumber }));
        }

        [HttpPost("SimulateTravel")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] SimulateTravelCommand command)
        {
            var tid = await Mediator.Send(command);
            return CreatedAtRoute("GetById", new { id = tid }, tid);
        }


    }

    public class TicketTypeController : ApiController
    {
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TicketTypeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetTicketTypesQuery()));
        }
    }
}
