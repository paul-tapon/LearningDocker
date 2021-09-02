using DOTR.QLess.Application.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DOTR.QLess.Application.Ticket.SimulateTravel
{
    public class SimulateTravelCommandalidator : AbstractValidator<SimulateTravelCommand>
    {
        private readonly IQLessDbContext _qLessDbContext;

        public SimulateTravelCommandalidator(IQLessDbContext qLessDbContext)
        {
            base.CascadeMode = CascadeMode.StopOnFirstFailure;


            RuleFor(c => c.TicketNumber)
                    .NotEmpty()
                    .WithMessage("Ticket number is required.")
                    .Must(p => HaveSufficientBalance(p))
                    .WithMessage("Your ticket has insufficient funds to travel.");

            RuleFor(c => new { c.TravelDate, c.TicketNumber })
                .NotEmpty()
                .NotNull()
                .Must(p => WithinTheValidTerm(p.TicketNumber, p.TravelDate))
                .WithMessage("Travel date is not within the valid term.");

            _qLessDbContext = qLessDbContext;
        }

        private bool WithinTheValidTerm(string ticketNumber, DateTime travelDate)
        {
            var ticket = _qLessDbContext
                            .Tickets
                            .Include(t => t.TicketType)
                            .FirstOrDefault(t => t.TicketNumber == ticketNumber);

            var validUntil = ticket.LastUsedDate.HasValue ?
                   ticket.LastUsedDate.Value.AddMonths(ticket.TicketType.ExpirationInMonths.GetValueOrDefault()) :
                   ticket.CreatedDate.AddMonths(ticket.TicketType.ExpirationInMonths.GetValueOrDefault());


            return travelDate <= validUntil;
        }

        private bool HaveSufficientBalance(string ticketNumber)
        {
            var ticket = _qLessDbContext
                            .Tickets
                            .Include(t => t.TicketType)
                            .FirstOrDefault(t => t.TicketNumber == ticketNumber);

            if (ticket.Balance < ticket.TicketType.FixRate)
            {
                return false;
            }

            return true;
        }
    }

}
