using Microsoft.EntityFrameworkCore.Storage;
using ProjectManagement.IServices;
using ProjectManagement.Repositories;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private ICompanyRepository _companyRepository;
        private IProjectRepository _projectRepository;
        private ITicketRepository _ticketRepository;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }



        public IRepositoryBase<T> GetGenericRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepositoryBase<T>)_repositories[typeof(T)];
            }

            var repository = new RepositoryBase<T>(_context);
            _repositories.Add(typeof(T), repository);

            return repository;
        }



        public IProjectRepository GetProjectRepository()
        {
           
                if (this._projectRepository== null)
                {
                    this._projectRepository = new ProjectRepository(_context);
                }

              return this._projectRepository;
            
        }

        public ITicketRepository GetTicketRepository()
        {
            if (this._ticketRepository == null)
            {
                this._ticketRepository = new TicketRepository(_context);
            }

            return this._ticketRepository;
        }

        public ICompanyRepository GetCompanyRepository()
        {
            if (this._companyRepository == null)
            {
                this._companyRepository = new CompanyRepository(_context);
            }

            return this._companyRepository;
        }



    }
}
