using gy_TechShop.Business.Abstract;
using gy_TechShop.Business.Constants;
using gy_TechShop.Core.Entities.Concrete;
using gy_TechShop.Core.Utilities.Results;
using gy_TechShop.Core.Utilities.Security.Hashing;
using gy_TechShop.Core.Utilities.Security.JWT;
using gy_TechShop.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheckResult = _userService.GetByMail(userLoginDto.Email);
            if (!userToCheckResult.Success) return new ErrorDataResult<User>(userToCheckResult.Message);

            var userToCheck = userToCheckResult.Data;
            if (userToCheck == null) return new ErrorDataResult<User>(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt)) return new ErrorDataResult<User>(Messages.PasswordError);

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            var userResult = _userService.GetByMail(email);
            if (!userResult.Success) return new ErrorResult(userResult.Message);
            if (userResult.Data != null) return new ErrorResult(Messages.UserAlreadyExists);
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claimsResult = _userService.GetClaims(user);
            if (!claimsResult.Success) return new ErrorDataResult<AccessToken>(claimsResult.Message);
            var accessToken = _tokenHelper.CreateToken(user, claimsResult.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
