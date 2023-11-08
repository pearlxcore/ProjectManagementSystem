﻿using FluentValidation;

namespace ProjectManagementSystem.Application.Users.Query.GetUser
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
