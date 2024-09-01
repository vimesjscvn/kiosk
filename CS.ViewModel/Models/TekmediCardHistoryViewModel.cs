// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TekmediCardHistoryViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using CS.Common.Enums;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    /// Class TekmediCardHistoryViewModel.
    /// </summary>
    public class TekmediCardHistoryViewModel
    {
        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [JsonProperty("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [JsonProperty("employee_id")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>The name of the employee.</value>
        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Creates new tekmedicardnumber.
        /// </summary>
        /// <value>The new tekmedi card number.</value>
        [JsonProperty("new_tekmedi_card_number")]
        public string NewTekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the tekmedi card identifier.
        /// </summary>
        /// <value>The tekmedi card identifier.</value>
        [JsonProperty("tekmedi_card_id")]
        public Guid TekmediCardId { get; set; }

        /// <summary>
        /// Gets or sets the tekmedi card.
        /// </summary>
        /// <value>The tekmedi card.</value>
        [JsonProperty("tekmedi_card")]
        public TekmediCardViewModel TekmediCard { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        [JsonProperty("patient")]
        public PatientViewModel Patient { get; set; }

        /// <summary>
        /// Gets or sets the bill number.
        /// </summary>
        /// <value>
        /// The bill number.
        /// </value>
        [JsonProperty(PropertyName = "bill_number")]
        public string BillNumber { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }

    public class TekmediCardHistoryCardExportViewModel
    {
        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [JsonProperty("row_num")]
        public string RowNum { get; set; }

        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [JsonProperty("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

        [JsonProperty("new_tekmedi_card_number")]
        public string NewTekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_name")]
        public string PatientName { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [JsonProperty("employee_id")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("payment_type_name")]
        public string PaymentTypeName { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; set; }

        [JsonProperty("cancel_advance_payment_amount")]
        public decimal? CancelAdvancePaymentAmount { get; set; }

        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("recv_no")]
        public int RecvNo { get; set; }
        [JsonProperty("serial_no")]
        public string SerialNo { get; set; }
    }

    public class TekmediCardCashflowExportSheetData
    {
        public TekmediCardCashflowExportSheetData()
        {
            ListDetail = new List<TekmediCardCashflowExportViewModel>();
            ListDetailByEmployee = new List<TekmediCardCashflowExportViewModel>();
        }

        public List<TekmediCardCashflowExportViewModel> ListDetail { get; set; }
        public List<TekmediCardCashflowExportViewModel> ListDetailByEmployee { get; set; }
    }

    public class TekmediCardCashflowExportViewModel
    {

        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [JsonProperty("row_num")]
        public string RowNum { get; set; }

        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [JsonProperty("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_name")]
        public string PatientName { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [JsonProperty("employee_id")]
        public Guid EmployeeId { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }

        [JsonProperty("advance_payment_amount")]
        public decimal AdvancePaymentAmount { get; set; }

        [JsonProperty("total_fee_amount")]
        public decimal TotalFeeAmount { get; set; }

        [JsonProperty("insurance_payment_amount")]
        public decimal InsurancePaymentAmount { get; set; }

        [JsonProperty("patient_payment_amount")]
        public decimal PatientPaymentAmount { get; set; }

        [JsonProperty("refund_amount")]
        public decimal TotalRefundAmount { get; set; }

        [JsonProperty("lost_amount")]
        public decimal TotalLostAmount { get; set; }

        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("is_returned_card")]
        public bool IsReturnedCard { get; set; }

        [JsonProperty("transaction_date")]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty("is_paid")]
        public bool IsPaid { get; set; }

        [JsonProperty("already_return_patient_paid_amount")]
        public decimal AlreadyReturnPatientPaidAmount { get; set; }

        [JsonProperty("not_yet_return_patient_paid_amount")]
        public decimal NotYetReturnPatientPaidAmount { get; set; }

        public int RecvNo { get; set; }
        public string SerialNo { get; set; }
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("extra_fee_amount")]
        public decimal ExtraFeeAmount { get; set; }
        [JsonProperty("transaction_info_id")]
        public Guid TransactionInfoId { get; set; }
        [JsonProperty("type")]
        public TekmediCardCashFlowPrepareDataEnum Type { get; set; }
        [JsonProperty("diff_amount")]
        public decimal DiffAmount { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("type_name")]
        public string TypeName { get; set; }
        [JsonProperty("cancelled_transaction_info_id")]
        public Guid? CancelledTransactionInfoId { get; set; }
    }

    public class TekmediCardCashFlowPrepareData
    {
        public string TekmediCardNumber { get; set; }
        public string EmployeeUserName { get; set; }
        public string PatientName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PatientCode { get; set; }
        public string EmployeeName { get; set; }
        public Guid EmployeeId { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public TekmediCardCashFlowPrepareDataEnum Type { get; set; }
        public decimal AdvancePaymentAmount { get; set; } = 0;
        public decimal TotalFee { get; set; } = 0;
        public decimal PatientPaymentAmount { get; set; } = 0;
        public decimal InsurancePaymentAmount { get; set; } = 0;
        public decimal RefundPaymentAmount { get; set; } = 0;
        public decimal LostPaymentAmount { get; set; } = 0;
        public decimal CancelAdvancePaymentAmount { get; set; } = 0;
        public string RegisteredCode { get; set; }
        public string RowNumber { get; set; }
        public int RecvNo { get; set; }
        public string SerialNo { get; set; }
        public decimal ExtraFeeAmount { get; set; } = 0;
        public Guid Id { get; set; }
        public Guid TekmediCardHistoryId { get; set; }
        public Guid TransactionInfoId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CancelledTransactionInfoId { get; set; }
    }

    public enum TekmediCardCashFlowPrepareDataEnum
    {
        None = 0,
        AdvancePayment = 1,
        Payment = 2,
        Refund = 3,
        Lost = 4,
        AdvancePaymentCancel = 5,
        ExtraFee = 6,
        PaymentCancel = 7
    }

    public class TekemediCardCashFlowOverviewViewModel
    {
        public decimal FinalcialAmount { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public decimal TotalInsuranceAmount { get; set; }
        public decimal PatientPaymentAmount { get; set; }
        public decimal TotalAdvancePaymentAmount { get; set; }
        public decimal TotalRefundAmount { get; set; }
        public decimal TotalLostAmount { get; set; }
        public decimal TotalCardAmountReturn { get; set; }
        public decimal TotalCardAmountNotReturn { get; set; }
    }

    public class TekmediCardHistoryGroupExportPdf
    {
        public TekmediCardHistoryGroupExportPdf()
        {
            TotalPrice = 0;
            TotalEmployee = 0;
            TotalPatient = 0;
            TotalPerform = 0;
            TotalTransfer = 0;
            TotalCardScan = 0;
            TotalMienGiam = 0;
            DataGroups = new List<TekmediCardHistoryGroupExportViewModel>();
        }

        public decimal TotalPrice { get; set; }
        public int TotalEmployee { get; set; }
        public int TotalPatient { get; set; }
        public int TotalPerform { get; set; }
        public int TotalCardScan { get; set; }
        public int TotalTransfer { get; set; }
        public int TotalMienGiam { get; set; }
        public List<TekmediCardHistoryGroupExportViewModel> DataGroups { get; set; }
    }

    public class TekmediCardHistoryGroupExportViewModel
    {
        public TekmediCardHistoryGroupExportViewModel()
        {
            Datas = new List<TekmediCardHistoryCardExportViewModel>();
        }

        public decimal TotalPriceEmployee { get; set; }
        public string EmployeeName { get; set; }
        public List<TekmediCardHistoryCardExportViewModel> Datas { get; set; }
    }

    public class TekmediCardHistoryOverviewPdf
    {
        public TekmediCardHistoryOverviewPdf()
        {
            Overview = new TekmediCardHistoryOverview();
        }

        public TekmediCardHistoryOverview Overview { get; set; }


        public TekmediCardHistoryGroupExportPdf Register { get; set; }
        public TekmediCardHistoryGroupExportPdf Return { get; set; }
        public TekmediCardHistoryGroupExportPdf CardFee { get; set; }
        public TekmediCardHistoryGroupExportPdf Recharged { get; set; }
    }

    public class TekmediCardHistoryOverview
    {
        public TekmediCardHistoryOverview()
        {
            Data = new List<TekmediCardHistoryOverviewListEmployee>();
            TotalAmountCardFee = 0;
            TotalAmountReturn = 0;
            TotalAmountRegister = 0;
            TotalAmountRecharged = 0;
        }

        public List<TekmediCardHistoryOverviewListEmployee> Data { get; set; }

        public decimal TotalAmountRegister { get; set; }

        public decimal TotalAmountRecharged { get; set; }
        public decimal TotalAmountReturn { get; set; }

        public decimal TotalAmountCardFee { get; set; }

        public decimal TotalAmountFinancialDept { get; set; }

        public decimal TotalAmountTekmedi { get; set; }
    }

    public class TekmediCardHistoryOverviewListEmployee
    {
        public string EmployeeName { get; set; }
        public int TotalRegister { get; set; }
        public decimal TotalPriceRegister { get; set; }
        public int TotalRecharged { get; set; }
        public decimal TotalPriceRecharged { get; set; }
        public int TotalReturn { get; set; }
        public decimal TotalPriceReturn { get; set; }
        public int TotalCardFee { get; set; }
        public decimal TotalPriceCardFee { get; set; }
    }

    public class ExportBalanceExcelSheetData
    {
        public List<ExportBalanceExcelDataDto> Data { get; set; } = new List<ExportBalanceExcelDataDto>();
    }

    public class ExportBalanceExcelDataDto
    {
        public string BillNumber { get; set; }
        public string RegisteredCode { get; set; }
        public string PatientName { get; set; }
        public string DepartmentName { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public decimal AmountBeforePayment { get; set; }
        public decimal AmountAfterPayment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SerialNo { get; set; }
        public int RecvNo { get; set; }
        public string TekmediCardNumber { get; set; }
        public string PatientCode { get; set; }
    }
}
