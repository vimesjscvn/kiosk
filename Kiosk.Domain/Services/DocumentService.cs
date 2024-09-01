using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.DocumentModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.Service.Interfaces.IDocumentService" />
    public class DocumentService : IDocumentService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public DocumentService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public Document Add(Document entity)
        {
            _unitOfWork.GetRepository<Document>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Document> AddAsync(Document entity)
        {
            _unitOfWork.GetRepository<Document>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Document>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Document>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Document entity)
        {
            _unitOfWork.GetRepository<Document>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Document>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Document entity)
        {
            _unitOfWork.GetRepository<Document>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Document>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public Document Find(Expression<Func<Document, bool>> match)
        {
            return _unitOfWork.GetRepository<Document>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Document> FindAll(Expression<Func<Document, bool>> match)
        {
            return _unitOfWork.GetRepository<Document>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Document>> FindAllAsync(Expression<Func<Document, bool>> match)
        {
            return await _unitOfWork.GetRepository<Document>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Document> FindAsync(Expression<Func<Document, bool>> match)
        {
            return await _unitOfWork.GetRepository<Document>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public Document Get(Guid id)
        {
            return _unitOfWork.GetRepository<Document>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Document> GetAll()
        {
            return _unitOfWork.GetRepository<Document>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Document>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Document>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Document> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Document>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Document.</returns>
        public Document Update(Document entity, Guid id)
        {
            if (entity == null)
                return null;

            Document existing = _unitOfWork.GetRepository<Document>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Document>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Document.
        /// </returns>
        public async Task<Document> UpdateAsync(Document entity, Guid id)
        {
            if (entity == null)
                return null;

            Document existing = await _unitOfWork.GetRepository<Document>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Document>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Uploads the multi.
        /// </summary>
        /// <param name="documentList">The document list.</param>
        /// <returns>ICollection&lt;Document&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ICollection<Document>> UploadMulti(IEnumerable<DocumentPostModel> documentList)
        {
            if (documentList != null && documentList.Count() == 0)
                throw new Exception(ErrorMessages.NotFoundDocument);

            var documents = new List<Document>();
            foreach (var item in documentList)
            {
                var model = _mapper.Map<Document>(item);
                _unitOfWork.GetRepository<Document>().Add(model);
                documents.Add(model);
            }

            await _unitOfWork.CommitAsync();
            return documents;
        }
    }
}
