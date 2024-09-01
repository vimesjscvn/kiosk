// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Clinic.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class Clinic.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("service_order", Schema = "IHM")]
    public class ServiceOrder : BaseObjectExtended
    {
        [Column("service_name")] public string ServiceName { get; set; }

        [Column("status")] public string Status { get; set; }

        [Column("group_dept_code")] public string GroupDeptCode { get; set; }

        [Column("group_dept_name")] public string GroupDeptName { get; set; }

        [Column("department_type")] public int DepartmentType { get; set; }

        [Column("service_id")] public string ServiceId { get; set; }

        [Column("order_id")] public int OrderId { get; set; }

        [Column("group_service_id")] public string GroupServiceId { get; set; }

        [Column("order_line_id")] public int OrderLineId { get; set; }

        [Column("patient_type")] public string PatientType { get; set; }

        [Column("department_code")] public string DepartmentCode { get; set; }

        [Column("group_service_name")] public string GroupServiceName { get; set; }

        [Column("department_name")] public string DepartmentName { get; set; }

        [Column("registered_date")] public DateTime RegisteredDate { get; set; } = DateTime.Now;

        [Column("registered_code")] public string RegisteredCode { get; set; }

        [Column("is_finish")] public bool IsFinished { get; set; }

        [Column("is_had_result")] public bool IsHadResult { get; set; }

        [Column("examination_code")] public string ExaminationCode { get; set; }

        [Column("examination_name")] public string ExaminationName { get; set; }

        [Column("patient_code")] public string PatientCode { get; set; }

        [NotMapped] public List<ServiceDepartment> Departments { get; set; } = new List<ServiceDepartment>();
    }

    public class ServiceDepartment
    {
        public string GroupDeptCode { get; set; }

        public string GroupDeptName { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }
        public int OrderId { get; set; }
        public int OrderLineId { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int DepartmentType { get; set; }
        public int TotalNumber { get; set; }
        public int WaitingNumber { get; set; }
        public int FinishNumber { get; set; }
    }
}