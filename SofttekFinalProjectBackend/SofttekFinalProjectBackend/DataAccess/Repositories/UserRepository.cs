﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Helper;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                User user = await _contextDB.Users
                    .Include(u => u.CryptoAccounts)
                    .Include(u => u.FiduciaryAccounts)
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    return user;

                }

                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserDTO> GetUserDTOById(int id)
        {
            try
            {
               UserDTO  user =  _mapper.Map<UserDTO>(await GetUserById(id));

                if (user != null)
                {
                    return user;

                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDTO dto)
        {

            try
            {
                return await _contextDB.Users.Include(user => user.Role).SingleOrDefaultAsync
                              (user => user.Email == dto.Email && user.Password == PasswordEncryptHelper.EncryptPassword(dto.Password, dto.Email));
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
