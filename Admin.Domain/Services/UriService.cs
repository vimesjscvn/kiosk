using CS.VM.Requests;
using Microsoft.AspNetCore.WebUtilities;
using System;
using TEK.Core.Service.Interfaces;

namespace Admin.API.Domain.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        /// <summary>
        /// Get Page Uri
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "page_Number", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "page_Size", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
