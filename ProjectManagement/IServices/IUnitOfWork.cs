﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IUnitOfWork
    {
  
        public  Task Commit();

        IRepositoryBase<T> GetGenericRepository<T>() where T : class;

        public ICompanyRepository GetCompanyRepository();

        public IProjectRepository GetProjectRepository();

        public ITicketRepository GetTicketRepository();

        public IUserRepository GetUserRepository();

        public Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
