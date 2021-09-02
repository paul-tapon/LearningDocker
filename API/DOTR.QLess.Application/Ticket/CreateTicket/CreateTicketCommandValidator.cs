using AutoMapper;
using DOTR.QLess.Application.Context;
using FluentValidation;

namespace DOTR.QLess.Application.Ticket.CreateTicket
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {

        public CreateTicketCommandValidator()
        {

            const string seniorIdFormatRegex = "^\\d{2}-\\d{4}-\\d{4}$";
            const string pwdIdFormatRegex = "^\\d{4}-\\d{4}-\\d{4}$";

            RuleFor(c => c.TicketType).GreaterThan(0).WithMessage("Ticket type is required.");

            RuleFor(c => c.IdType).GreaterThan(0).When(c =>c.TicketType == 2).WithMessage("ID type is required for Discounted Ticket.");

            RuleFor(c => c.SeniorIdNumber).NotEmpty().Matches(seniorIdFormatRegex).When(c => c.IdType.GetValueOrDefault() == 1 && c.TicketType == 2)
                .WithMessage("Senior Id Number is required.");

            RuleFor(c => c.PwdIdNumber)
                .NotEmpty().WithMessage("PWD Id Number is required.")
                .Matches(pwdIdFormatRegex).WithMessage("Invalid PWD Id Number format.")
                .When(c => c.IdType.GetValueOrDefault() == 2 && c.TicketType == 2);

        }
    }
}
