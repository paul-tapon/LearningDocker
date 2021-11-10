using DOTR.QLess.Api.Controllers;
using DOTR.QLess.Application.Ticket.GetTicketByNumber;
using DOTR.QLess.Application.Ticket.Shared;
using DOTR.QLess.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOTR.QLess.Tests.ApiTests.ControllerTests.TicketControllerTests
{

    [TestFixture]
    public class When_Getting_Ticket_By_Number
    {
        [Test]
        public void Should_Return_Ticket_Details_If_Number_Exists()
        {
            var mediator = new Mock<IMediator>();
            var configuration = new Mock<IConfiguration>();

            var ticketDto = new TicketDto()
            {
                TicketNumber = "1111",
                TicketId = 1,
                Balance = 1
            };

            var controller = new TicketController(mediator.Object, configuration.Object);

            var query = new GetTicketByNumber()
            {
                TicketNumber = "1111"
            };
            mediator.Setup(m => m.Send(query, It.IsAny<CancellationToken>())).Returns(Task.FromResult(ticketDto));

            var result = controller.Get(query).Result as OkObjectResult;
            var contentBody = result.Value as TicketDto;

            Assert.IsNotNull(result);
            Assert.IsNotNull(contentBody);
            Assert.AreEqual("1111", contentBody.TicketNumber);


            mediator.VerifyAll();
        }

        [Test]
        public void Should_Return_200_Ok_If_Number_Exists()
        {
            var mediator = new Mock<IMediator>();
            var configuration = new Mock<IConfiguration>();

            var ticketDto = new TicketDto()
            {
                TicketNumber = "1111",
                TicketId = 1,
                Balance = 1
            };

            var controller = new TicketController(mediator.Object, configuration.Object);

            var query = new GetTicketByNumber()
            {
                TicketNumber = "1111"
            };
            mediator.Setup(m => m.Send(query, It.IsAny<CancellationToken>())).Returns(Task.FromResult(ticketDto));

            var result = controller.Get(query).Result as OkObjectResult;


            Assert.AreEqual(200, result.StatusCode.GetValueOrDefault());


            mediator.VerifyAll();
        }

        [Test]
        public void Should_Throw_Record_Not_Found_If_Number_Dont_Exists()
        {
            var mediator = new Mock<IMediator>();
            var configuration = new Mock<IConfiguration>();

            var controller = new TicketController(mediator.Object, configuration.Object);

            var query = new GetTicketByNumber()
            {
                TicketNumber = "1111"
            };
            mediator.Setup(m => m.Send(query, It.IsAny<CancellationToken>())).Throws(new RecordNotFoundException("Ticket", "TicketNumber", query.TicketNumber));

            Task<IActionResult> result = controller.Get(query);

            var exception = result.Exception.InnerExceptions[0] as RecordNotFoundException;
            Assert.IsNotEmpty(result.Exception.InnerExceptions);
            Assert.IsNotNull(exception);

            mediator.VerifyAll();
        }
    }


}
