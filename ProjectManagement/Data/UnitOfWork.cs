using ProjectManagement.IServices;
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
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
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


        public ICompanyRepository CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_context);
                }

                return _companyRepository;
            }
        }


        public IProjectRepository ProjectRepository
        {
            get
            { 
                if(_projectRepository == null)
                {
                    _projectRepository = new ProjectRepository(_context);
                }

                return _projectRepository;
            }

        
        }

    }
}
