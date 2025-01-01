using ProductManagementTask.Applications.Account.Commands.Login.Dtos;
using ProductManagementTask.Applications.Common.Exceptions;
using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Domain.Entities.Identity;
using ProductManagementTask.SharedKernal.Constants;
using ProductManagementTask.SharedKernal.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Applications.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginOutput>
    {
        private readonly IUserHandler _userHandler;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwt;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(
            UserManager<ApplicationUser> userManager,
            IUserHandler userHandler,
            IOptions<JWT> jwt,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _userHandler = userHandler;
            _jwt = jwt.Value;
            _configuration = configuration;
        }
        public async Task<LoginOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            await ValidateUserAsync(user, request.Password);

            var expires = 24;

            var token = await _userHandler.GenerateJwtAsync(user, DateTime.UtcNow.AddHours(expires), cancellationToken);

            return new LoginOutput
            {
                Token = token,
                RefreshToken = _userHandler.GenerateRefreshToken(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(expires)
            };
        }
        private async Task ValidateUserAsync(ApplicationUser user, string password)
        {
            if (user == null )
            {
                throw new BusinessException(ErrorCodesConstants.UserNotFound);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!passwordValid)
            {
                throw new BusinessException(ErrorCodesConstants.InvalidPassword);
            }
        }
    }
}
