// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionInfoViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using CS.Base.ViewModels;
using CS.Common.Common;
using CS.VM.ClinicModels;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Models
{
    /// <summary>
    /// Class TransactionInfoViewModel.
    /// Implements the <see cref="BaseViewModelExtended" />
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class TransactionInfoViewModel : BaseViewModelExtended
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfoViewModel"/> class.
        /// </summary>
        public TransactionInfoViewModel()
        {
            TransactionClinics = new List<ClinicTransactionViewModel>();
            TransactionPrescriptions = new List<PrescriptionTransactionViewModel>();
        }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets the name of the status.
        /// </summary>
        /// <value>The name of the status.</value>
        [JsonProperty("status_name")]
        public string StatusName
        {
            get
            {
                return Status.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [JsonProperty("type_name")]
        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        [JsonProperty("patient")]
        public PatientViewModel Patient { get; set; }

        /// <summary>
        /// Gets or sets the transaction clinics.
        /// </summary>
        /// <value>The transaction clinics.</value>
        [JsonProperty("transaction_clinics")]
        public IEnumerable<ClinicTransactionViewModel> TransactionClinics { get; set; }

        /// <summary>
        /// Gets or sets the transaction prescriptions.
        /// </summary>
        /// <value>The transaction prescriptions.</value>
        [JsonProperty("transaction_prescriptions")]
        public IEnumerable<PrescriptionTransactionViewModel> TransactionPrescriptions { get; set; }

        /// <summary>
        /// Gets the store.
        /// </summary>
        /// <value>The store.</value>
        [JsonProperty("store")]
        public ListValueExtendViewModel Store { get; set; }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [JsonProperty("employee")]
        public object Employee { get; set; }
    }

    /// <summary>
    /// Class ClinicTransactionViewModel.
    /// Implements the <see cref="BaseViewModelExtended" />
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class ClinicTransactionViewModel : BaseViewModelExtended
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClinicTransactionViewModel"/> class.
        /// </summary>
        public ClinicTransactionViewModel()
        {
            Clinic = new ClinicViewModel();
        }

        /// <summary>
        /// Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("money")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets the name of the status.
        /// </summary>
        /// <value>The name of the status.</value>
        [JsonProperty("status_name")]
        public string StatusName
        {
            get
            {
                return Status.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [JsonProperty("type_name")]
        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the transaction information identifier.
        /// </summary>
        /// <value>The transaction information identifier.</value>
        [JsonProperty("transaction_info_id")]
        public Guid TransactionInfoId { get; set; }

        /// <summary>
        /// Gets or sets the clinic identifier.
        /// </summary>
        /// <value>The clinic identifier.</value>
        [JsonProperty("clinic_id")]
        public Guid ClinicId { get; set; }

        /// <summary>
        /// Gets or sets the clinic.
        /// </summary>
        /// <value>The clinic.</value>
        [JsonProperty("clinic")]
        public ClinicViewModel Clinic { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the type of the clinic.
        /// </summary>
        /// <value>The type of the clinic.</value>
        [JsonProperty("clinic_type")]
        public ClinicType? ClinicType { get; set; }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        [JsonProperty("number")]
        public int? Number { get; set; }
    }

    /// <summary>
    /// Class PrescriptionTransactionViewModel.
    /// Implements the <see cref="BaseViewModelExtended" />
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class PrescriptionTransactionViewModel : BaseViewModelExtended
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrescriptionTransactionViewModel"/> class.
        /// </summary>
        public PrescriptionTransactionViewModel()
        {
            Prescription = new PrescriptionViewModel();
        }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the transaction information identifier.
        /// </summary>
        /// <value>The transaction information identifier.</value>
        [JsonProperty("transaction_info_id")]
        public Guid TransactionInfoId { get; set; }

        /// <summary>
        /// Gets or sets the prescription identifier.
        /// </summary>
        /// <value>The prescription identifier.</value>
        [JsonProperty("prescription_id")]
        public Guid PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets the name of the status.
        /// </summary>
        /// <value>The name of the status.</value>
        [JsonProperty("status_name")]
        public string StatusName
        {
            get
            {
                return Status.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [JsonProperty("type_name")]
        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the prescription.
        /// </summary>
        /// <value>The prescription.</value>
        [JsonProperty("prescription")]
        public PrescriptionViewModel Prescription { get; set; }


        /// <summary>
        /// Gets or sets the type of the prescription.
        /// </summary>
        /// <value>The type of the prescription.</value>
        [JsonProperty("prescription_type")]
        public PrescriptionType? PrescriptionType { get; set; }
    }

    /// <summary>
    /// Class TransactionDetailGroupViewModel.
    /// Implements the <see cref="BaseViewModelExtended" />
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class TransactionDetailGroupViewModel : BaseViewModelExtended
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetailGroupViewModel"/> class.
        /// </summary>
        public TransactionDetailGroupViewModel()
        {
            //TransactionClinicGroups = new List<ClinicTransactionGroupViewModel>();
            //TransactionPrescriptions = new List<PrescriptionTransactionViewModel>();
        }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets the name of the status.
        /// </summary>
        /// <value>The name of the status.</value>
        [JsonProperty("status_name")]
        public string StatusName
        {
            get
            {
                return Status.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [JsonProperty("type_name")]
        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        [JsonProperty("patient")]
        public PatientViewModel Patient { get; set; }

        /// <summary>
        /// Gets or sets the transaction clinic groups.
        /// </summary>
        /// <value>The transaction clinic groups.</value>
        //[JsonProperty("transaction_clinics")]
        //public IEnumerable<ClinicTransactionGroupViewModel> TransactionClinicGroups { get; set; }

        /// <summary>
        /// Gets or sets the transaction prescriptions.
        /// </summary>
        /// <value>The transaction prescriptions.</value>
        //[JsonProperty("transaction_prescriptions")]
        //public IEnumerable<PrescriptionTransactionViewModel> TransactionPrescriptions { get; set; }

        /// <summary>
        /// Gets the store.
        /// </summary>
        /// <value>The store.</value>
        [JsonProperty("store")]
        public ListValueExtendViewModel Store { get; set; }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [JsonProperty("employee")]
        public SysUserViewModel Employee { get; set; }
    }

    /// <summary>
    /// Class ClinicTransactionGroupViewModel.
    /// </summary>
    public class ClinicTransactionGroupViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClinicTransactionGroupViewModel"/> class.
        /// </summary>
        public ClinicTransactionGroupViewModel()
        {
            TransactionClinicGroup = new List<ClinicTransactionViewModel>();
        }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets the type of the clinic.
        /// </summary>
        /// <value>The type of the clinic.</value>
        [JsonProperty("clinic_type")]
        public ClinicType? ClinicType { get; set; }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        [JsonProperty("number")]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets the transaction clinic group.
        /// </summary>
        /// <value>The transaction clinic group.</value>
        [JsonProperty("services")]
        public IEnumerable<ClinicTransactionViewModel> TransactionClinicGroup { get; set; }
    }

    public class TransactionListGroupViewModel : BaseViewModelExtended
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetailGroupViewModel"/> class.
        /// </summary>
        public TransactionListGroupViewModel()
        {
            TransactionDetailGroups = new List<TransactionDetailGroupViewModel>();
        }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets the name of the status.
        /// </summary>
        /// <value>The name of the status.</value>
        [JsonProperty("status_name")]
        public string StatusName
        {
            get
            {
                return Status.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [JsonProperty("type_name")]
        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Gets or sets the transaction detail groups.
        /// </summary>
        /// <value>
        /// The transaction detail groups.
        /// </value>
        [JsonProperty("transactions")]
        public IEnumerable<TransactionDetailGroupViewModel> TransactionDetailGroups { get; set; }
    }
}
