using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{AuditLog,IRepository}" />
    public interface IAuditLogService : IService<AuditLog, IRepository<AuditLog>>
    {
        /// <summary>
        ///     Gets the range.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;ICollection&lt;AuditLog&gt;&gt;.</returns>
        Task<TableResultJsonResponse<AuditLogViewModel>> GetRange(AuditLogRequest request);
    }
}