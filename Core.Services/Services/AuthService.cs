using Core.Infrastructure.Contants;
using Core.Infrastructure.Dtos.GetDtos;
using Core.Infrastructure.Dtos.PostDtos;
using Core.Infrastructure.Utilities.Results;
using Core.Infrastructure.Utilities.Security.Hashing;
using Core.Models.Context;
using Core.Models.Entities;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Services
{
    public class AuthService : IAuthService
    {
        public DataResult<ResponseLoginUserDto> Login(LoginUserDto model)
        {
            var registerUser = new ResponseLoginUserDto();
            var data = new DataResult<ResponseLoginUserDto>(registerUser, true, Messages.SuccessMessage);
            using (var db = new CoreDBContext())
            {
                var user = db.Users.Where(x => x.EMail == model.Email && !x.IsDelete).FirstOrDefault();
                if (user != null)
                {
                    var isVerefyPassword=HashingHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt);
                    if (isVerefyPassword)
                    {
                        var loginUserData = new ResponseLoginUserDto
                        {
                            EMail = user.EMail,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Token = "Token asdfasdfa"
                        };
                        data = new DataResult<ResponseLoginUserDto>(loginUserData, true);
                    }
                    else
                    {
                      data = new DataResult<ResponseLoginUserDto>(null, false, Messages.AuthMessage);
                    }
                }
                else
                {
                    data = new DataResult<ResponseLoginUserDto>(null, false, Messages.AuthMessage);
                }

            }
            return data;
        }
        public Result Register(RegisterUserDto model)
        {
            var result = new Result(true, Messages.SuccessMessage);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            using (var db = new CoreDBContext())
            {
                var user = new USER
                {
                    EMail = model.EMail,
                    CreatedBy = "",
                    CreatedTime = DateTime.Now,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IsActive = true,
                    IsDelete = false,
                };
                db.Entry(user).State = EntityState.Added;
                db.SaveChanges();
            }
            return result;
        }
    }
}
