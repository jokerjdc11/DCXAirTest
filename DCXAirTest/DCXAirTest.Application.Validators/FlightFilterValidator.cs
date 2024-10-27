using FluentValidation;
using DCXAirTest.Application.DTO.Filters;

namespace DCXAirTest.Application.Validators
{
    public class FlightFilterValidator : AbstractValidator<JourneyFilterDTO>
    {
        public FlightFilterValidator()
        {
            RuleFor(x => x.Origin).NotEmpty().MaximumLength(4);
            RuleFor(x => x.Destination).NotEmpty().MaximumLength(4);
        }
    }
}
