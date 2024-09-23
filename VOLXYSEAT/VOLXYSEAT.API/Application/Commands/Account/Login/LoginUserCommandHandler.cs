﻿using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using VOLXYSEAT.API.Application.Models.Dtos.User;
using VOLXYSEAT.API.Application.Responses;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.INFRASTRUCTURE.Services;

namespace VOLXYSEAT.API.Application.Commands.Account.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
    private readonly JWTService _jwtService;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public LoginUserCommandHandler(JWTService JWTService, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _jwtService = JWTService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    private LoginUserResponse AddLoginUserResponse(User user)
    {
        return new LoginUserResponse(user.Name, _jwtService.JWTGenerateToken(user), user.Email, user.Id);
    }

    public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        return AddLoginUserResponse(user);
    }
}
