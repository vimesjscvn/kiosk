using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.DocumentModels;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{Document,IRepository}" />
    public interface IDocumentService : IService<Document, IRepository<Document>>
    {
        /// <summary>
        ///     Uploads the multi.
        /// </summary>
        /// <param name="documentPostModel">The document post model.</param>
        /// <returns>Task&lt;ICollection&lt;Document&gt;&gt;.</returns>
        Task<ICollection<Document>> UploadMulti(IEnumerable<DocumentPostModel> documentPostModel);
    }
}