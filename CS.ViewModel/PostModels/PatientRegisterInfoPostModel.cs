// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PatientRegisterInfoPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace CS.VM.PostModels
{
    /// <summary>
    ///     Class PatientRegisterInfoPostModel.
    /// </summary>
    public class PatientRegisterInfoPostModel
    {
        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public int Gender { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public int Phone { get; set; }

        /// <summary>
        ///     Gets or sets the passport.
        /// </summary>
        /// <value>The passport.</value>
        public int Passport { get; set; }

        /// <summary>
        ///     Gets or sets the passport certificate date.
        /// </summary>
        /// <value>The passport certificate date.</value>
        public DateTime PassportCertificateDate { get; set; }

        /// <summary>
        ///     Gets or sets the place of passport.
        /// </summary>
        /// <value>The place of passport.</value>
        public string PlaceOfPassport { get; set; }

        /// <summary>
        ///     Gets or sets the bhyt code.
        /// </summary>
        /// <value>The bhyt code.</value>
        public string BHYTCode { get; set; }

        /// <summary>
        ///     Gets or sets the bhyt name register.
        /// </summary>
        /// <value>The bhyt name register.</value>
        public string BHYTNameRegister { get; set; }

        /// <summary>
        ///     Gets or sets the value from.
        /// </summary>
        /// <value>The value from.</value>
        public int ValueFrom { get; set; }

        /// <summary>
        ///     Gets or sets the value to.
        /// </summary>
        /// <value>The value to.</value>
        public int ValueTo { get; set; }

        /// <summary>
        ///     Gets or sets the DKKCBBD code.
        /// </summary>
        /// <value>The DKKCBBD code.</value>
        public string DKKCBBDCode { get; set; }

        /// <summary>
        ///     Gets or sets the DKKCBBD place.
        /// </summary>
        /// <value>The DKKCBBD place.</value>
        public string DKKCBBDPlace { get; set; }
    }
}