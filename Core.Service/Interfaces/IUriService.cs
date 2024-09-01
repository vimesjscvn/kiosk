using System;
using CS.VM.Requests;

namespace Core.Service.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}