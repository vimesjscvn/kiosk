using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Group Add(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<Group> AddAsync(Group entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Group Find(Expression<Func<Group, bool>> match)
        {
            throw new NotImplementedException();
        }

        public ICollection<Group> FindAll(Expression<Func<Group, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Group>> FindAllAsync(Expression<Func<Group, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<Group> FindAsync(Expression<Func<Group, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Group Get(Guid id)
        {
            return _unitOfWork.GetRepository<Group>().GetById(id);
        }

        public ICollection<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Group Update(Group updated, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> UpdateAsync(Group updated, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
