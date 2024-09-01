// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionDetailRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.Requests
{
    public class CancelPaymentRequest
    {
        [JsonProperty("registered_code")]
        [JsonRequired]
        public string RegisteredCode { get; set; }

        [JsonProperty("patient_code")]
        [JsonRequired]
        public string PatientCode { get; set; }

        [JsonProperty("employee_code")]
        [JsonRequired]
        public string EmployeeCode { get; set; }
    }

    public class CancelPaymentResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("invoice_no")]
        public int InvoiceNo { get; set; }
    }

    public class CancelRawPaymentRequest
    {
        [JsonProperty("registered_code")]
        [JsonRequired]
        public string RegisteredCode { get; set; }

        [JsonProperty("patient_code")]
        [JsonRequired]
        public string PatientCode { get; set; }

        [JsonProperty("employee_code")]
        [JsonRequired]
        public string EmployeeCode { get; set; }

        [JsonProperty("invoice_no")]
        [JsonRequired]
        public int InvoiceNo { get; set; }
    }
}
