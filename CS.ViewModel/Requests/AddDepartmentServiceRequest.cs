using System;
using CS.VM.Models;

namespace CS.VM.Requests
{
    public class AddDepartmentServiceRequest : DepartmentServiceBase
    {
    }

    public class UpdateDepartmentServiceRequest : DepartmentServiceBase
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}