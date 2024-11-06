using FleetManagementAPI.Infrastructure.Helpers;
using FluentValidation;
using System;

namespace FleetManagementAPI.DTO.Request
{
    public class UpdateFleetRequest
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }

    public class UpdateFleetRequestValidator : AbstractValidator<UpdateFleetRequest>
    {
        public UpdateFleetRequestValidator()
        {
            RuleFor(o => o.Make).NotEmpty();
            RuleFor(o => o.Model).NotEmpty();
            RuleFor(o => o.Price).NotEmpty();
        }
    }
}
