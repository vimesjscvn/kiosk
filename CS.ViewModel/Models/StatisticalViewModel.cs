// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="StatisticalViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Common.Enums;

namespace CS.VM.Models
{
    /// <summary>
    ///     Patient View Model
    /// </summary>
    public class StatisticalViewModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        public string TekmediCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi identifier.
        /// </summary>
        /// <value>The tekmedi identifier.</value>
        public string TekmediId { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the province.
        /// </summary>
        /// <value>The province.</value>
        public string Province { get; set; }

        /// <summary>
        ///     Gets or sets the district.
        /// </summary>
        /// <value>The district.</value>
        public string District { get; set; }

        /// <summary>
        ///     Gets or sets the ward.
        /// </summary>
        /// <value>The ward.</value>
        public string Ward { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time { get; set; }

        public Guid EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the employee.
        /// </summary>
        /// <value>The name of the employee.</value>
        public string EmployeeName { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public TypeEnum Type { get; set; }

        /// <summary>
        ///     Gets or sets the manipulation.
        /// </summary>
        /// <value>The manipulation.</value>
        public string Manipulation { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }

        /// <summary>
        ///     Creates new tekmedicardnumber.
        /// </summary>
        /// <value>
        ///     The new tekmedi card number.
        /// </value>
        public string NewTekmediCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the before value.
        /// </summary>
        /// <value>
        ///     The before value.
        /// </value>
        public decimal? BeforeValue { get; set; }

        /// <summary>
        ///     Gets or sets the after value.
        /// </summary>
        /// <value>
        ///     The after value.
        /// </value>
        public decimal? AfterValue { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is actived card.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is actived card; otherwise, <c>false</c>.
        /// </value>
        public bool IsActivedCard { get; set; }


        /// <summary>
        ///     Gets or sets the payment type name.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is actived card; otherwise, <c>false</c>.
        /// </value>
        public string PaymentTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the bill number.
        /// </summary>
        /// <value>
        ///     The bill number.
        /// </value>
        public int BillNumber { get; set; }

        /// <summary>
        ///     Gets or sets the payment name
        /// </summary>
        /// <value>
        ///     The Payment Name.
        /// </value>
        public string PaymentType { get; set; }

        /// <summary>
        ///     Gets or sets the is birthday year only
        /// </summary>
        /// <value>
        ///     The Payment Name.
        /// </value>
        public bool BirthdayYearOnly { get; set; }

        public string RegisteredCode { get; set; }
    }

    public class StatisticalIncludeUserName
    {
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        public string TekmediCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi identifier.
        /// </summary>
        /// <value>The tekmedi identifier.</value>
        public string TekmediId { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the province.
        /// </summary>
        /// <value>The province.</value>
        public string Province { get; set; }

        /// <summary>
        ///     Gets or sets the district.
        /// </summary>
        /// <value>The district.</value>
        public string District { get; set; }

        /// <summary>
        ///     Gets or sets the ward.
        /// </summary>
        /// <value>The ward.</value>
        public string Ward { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time { get; set; }

        public Guid EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the employee.
        /// </summary>
        /// <value>The name of the employee.</value>
        public string EmployeeName { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public TypeEnum Type { get; set; }

        /// <summary>
        ///     Gets or sets the manipulation.
        /// </summary>
        /// <value>The manipulation.</value>
        public string Manipulation { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }

        /// <summary>
        ///     Creates new tekmedicardnumber.
        /// </summary>
        /// <value>
        ///     The new tekmedi card number.
        /// </value>
        public string NewTekmediCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the before value.
        /// </summary>
        /// <value>
        ///     The before value.
        /// </value>
        public decimal? BeforeValue { get; set; }

        /// <summary>
        ///     Gets or sets the after value.
        /// </summary>
        /// <value>
        ///     The after value.
        /// </value>
        public decimal? AfterValue { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is actived card.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is actived card; otherwise, <c>false</c>.
        /// </value>
        public bool IsActivedCard { get; set; }

        /// <summary>
        ///     Gets or sets the bill number.
        /// </summary>
        /// <value>
        ///     The bill number.
        /// </value>
        public string BillNumber { get; set; }

        /// <summary>
        ///     Gets or sets the payment name
        /// </summary>
        /// <value>
        ///     The Payment Name.
        /// </value>
        public string PaymentType { get; set; }

        /// <summary>
        ///     Gets or sets the is birthday year only
        /// </summary>
        /// <value>
        ///     The Payment Name.
        /// </value>
        public bool BirthdayYearOnly { get; set; }

        public string RegisteredCode { get; set; }

        public string SerialNo { get; set; }

        public int? RecvNo { get; set; }
    }
}