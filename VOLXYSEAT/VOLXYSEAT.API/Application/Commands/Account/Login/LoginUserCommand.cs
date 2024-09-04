﻿using MediatR;
using VOLXYSEAT.API.Application.Models.Dtos.User;
using VOLXYSEAT.API.Application.Responses;

namespace VOLXYSEAT.API.Application.Commands.Account.Login;

public record LoginUserCommand(string UserName, string Password) : IRequest<LoginUserResponse>;
