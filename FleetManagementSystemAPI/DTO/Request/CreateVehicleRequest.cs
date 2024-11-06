using FluentValidation;
using System;

namespace FleetManagementAPI.DTO.Request
{
    public class CreateFleetRequest
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }

    public class CreateFleetRequestValidator : AbstractValidator<CreateFleetRequest>
    {
        public CreateFleetRequestValidator()
        {
            RuleFor(o => o.Make).NotEmpty();
            RuleFor(o => o.Model).NotEmpty();
            RuleFor(o => o.Price).NotEmpty();
        }
    }
}
