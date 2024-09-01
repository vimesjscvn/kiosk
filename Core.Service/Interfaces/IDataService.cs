// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IDataService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using CS.EF.Models;
using Newtonsoft.Json;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IDataService
    ///     Implements the <see cref="CS.Base.IService{Data, Base.IRepository{Data}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{Data, Base.IRepository{Data}}" />
    public interface IDataService
    {
        /// <summary>
        ///     Gets the calendar by date.
        /// </summary>
        /// <param name="request">The get calendar by date request.</param>
        /// <returns></returns>
        Task<ICollection<Department>> GetListDepartment(GetListGroupDeptModel request);

        Task<ICollection<Group>> GetListGroupDept(GetListGroupDeptModel request);

        Task<ICollection<ServiceOrder>> GetListServiceByRegisteredCode(GetListServiceByRegisteredCodeModel model);

        Task<ICollection<Department>> ActiveGroupDept(List<ActiveGroupDeptModel> model);

        Task<ICollection<Group>> PostSyncListGroupDept(PostSyncListGroupDeptModel model);

        Task<ICollection<Group>> GetGroupDeptByCode(GetGroupDeptByCodeModel request);
    }

    /// <summary>
    ///     Class GetAllCalendarByPatientCodeRequest.
    /// </summary>
    public class GetListGroupDeptModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string GroupDeptType { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarByPatientCodeRequest.
    /// </summary>
    public class GetGroupDeptByCodeModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string GroupDeptCode { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarByPatientCodeRequest.
    /// </summary>
    public class GetListServiceByRegisteredCodeModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string RegisteredCode { get; set; }

        public string PatientCode { get; set; }
    }

    public class ActiveGroupDeptModel
    {
        public string GroupDeptCode { get; set; }
        public List<int> ActiveDepartments { get; set; }
    }

    /// <summary>
    /// </summary>
    public class ActiveGroupDeptRequest
    {
        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        [JsonProperty("active_departments")] public List<int> ActiveDepartments { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarByPatientCodeRequest.
    /// </summary>
    public class PostSyncListGroupDeptModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string GroupDeptCode { get; set; }
    }
}