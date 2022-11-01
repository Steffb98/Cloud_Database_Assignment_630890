﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace DAL.Interface
{
    public interface IUserRepository
    {
        public Task CreateUser(User user);
        public Task UpdateMortgage(Guid userID, double mortgage);
        public Task<List<User>> GetAllUsers();
    }
}