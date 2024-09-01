﻿namespace Core.Config.Configs
{
    /// <summary>
    ///     Class External.
    /// </summary>
    public class ExternalConfig
    {
        /// <summary>
        ///     Gets or sets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        public string BaseUrl { get; set; }

        /// <summary>
        ///     Gets or sets the find patient URL.
        /// </summary>
        /// <value>The find patient URL.</value>
        public string FindPatientUrl { get; set; }

        /// <summary>
        ///     Gets or sets the register patient URL.
        /// </summary>
        /// <value>The register patient URL.</value>
        public string RegisterPatientUrl { get; set; }

        /// <summary>
        ///     Gets or sets the find patient by code URL.
        /// </summary>
        /// <value>The find patient by code URL.</value>
        public string FindPatientByCodeUrl { get; set; }

        /// <summary>
        ///     Gets or sets the charge clinic URL.
        /// </summary>
        /// <value>The charge clinic URL.</value>
        public string ChargeClinicUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get calendar URL.
        /// </summary>
        /// <value>The get calendar URL.</value>
        public string GetCalendarUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get all calendar URL.
        /// </summary>
        /// <value>The get all calendar URL.</value>
        public string GetAllCalendarUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get clinic URL.
        /// </summary>
        /// <value>The get clinic URL.</value>
        public string GetClinicUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get clinic list URL.
        /// </summary>
        /// <value>The get clinic list URL.</value>
        public string GetClinicListUrl { get; set; }

        /// <summary>
        ///     Gets or sets the charge list clinic URL.
        /// </summary>
        /// <value>The charge list clinic URL.</value>
        public string ChargeListClinicUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get finally clinic list URL.
        /// </summary>
        /// <value>The get finally clinic list URL.</value>
        public string GetFinallyClinicListUrl { get; set; }

        /// <summary>
        ///     Gets or sets the charge finally clinic list URL.
        /// </summary>
        /// <value>The charge finally clinic list URL.</value>
        public string ChargeFinallyClinicListUrl { get; set; }

        /// <summary>
        ///     Gets or sets the charge clinic list URL.
        /// </summary>
        /// <value>The charge clinic list URL.</value>
        public string ChargeClinicListUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get prescription URL.
        /// </summary>
        /// <value>The get prescription URL.</value>
        public string GetPrescriptionUrl { get; set; }

        /// <summary>
        ///     Gets or sets unhold service URL.
        /// </summary>
        /// <value>unhold service URL.</value>
        public string RefundServiceUrl { get; set; }

        /// <summary>
        ///     Gets or sets the charge finally clinic list at store URL.
        /// </summary>
        /// <value>The charge finally clinic list at store URL.</value>
        public string ChargeFinallyClinicListAtStoreUrl { get; set; }

        /// <summary>
        ///     Gets or sets the patient check in URL.
        /// </summary>
        /// <value>
        ///     The patient check in URL.
        /// </value>
        public string RegisterListServiceUrl { get; set; }

        /// <summary>
        ///     Gets or sets the cancel list service URL.
        /// </summary>
        /// <value>
        ///     The cancel list service URL.
        /// </value>
        public string CancelListServiceUrl { get; set; }

        /// <summary>
        ///     Gets or sets the update result service URL.
        /// </summary>
        /// <value>
        ///     The update result service URL.
        /// </value>
        public string UpdateResultServiceUrl { get; set; }

        /// <summary>
        ///     Gets or sets the update patient information URL.
        /// </summary>
        /// <value>
        ///     The update patient information URL.
        /// </value>
        public string UpdatePatientInfoUrl { get; set; }

        /// <summary>
        ///     Gets or sets the register URL.
        /// </summary>
        /// <value>
        ///     The register URL.
        /// </value>
        public string RegisterUrl { get; set; }

        /// <summary>
        ///     Gets or sets the patient check in URL.
        /// </summary>
        /// <value>
        ///     The patient check in URL.
        /// </value>
        public string PatientCheckInUrl { get; set; }

        /// <summary>
        ///     Gets or sets the register calendar URL.
        /// </summary>
        /// <value>
        ///     The register calendar URL.
        /// </value>
        public string RegisterCalendarUrl { get; set; }

        /// <summary>
        ///     Gets or sets the service list.
        /// </summary>
        /// <value>
        ///     the list service URL.
        /// </value>
        public string GetServiceList { get; set; }

        /// <summary>
        ///     Gets or sets the drug list.
        /// </summary>
        /// <value>
        ///     the drug list URL.
        /// </value>
        public string GetDrugList { get; set; }

        public string GetClinicResultList { get; set; }
        public string CreateAdvancePaymentUrl { get; set; }

        public string GetPatientByRegisteredCodeUrl { get; set; }

        public string CancelAdvancePaymentUrl { get; set; }

        public string CancelPaymentUrl { get; set; }

        public string UpdateReturnCardUrl { get; set; }
        public string AdminAPIBaseUrl { get; set; }
        public string AddPaymentUrl { get; set; }
        public string UpdateRefundUrl { get; set; }
        public string UpdateObjectTypeUrl { get; set; }
        public string GetCheckInInfoUrl { get; set; }
        public string PostCheckInInfoUrl { get; set; }
        public string FindPatientByRegisteredCodeUrl { get; set; }
        public string GetAllFeeUrl { get; set; }
        public string GetListExaminationByCodeUrl { get; set; }
        public string GetExaminationDetailByCodeUrl { get; set; }
        public string TestResultBaseUrl { get; set; }
        public string ReceiveTestResultUrl { get; set; }
        public string GetCategoryUrl { get; set; }
        public string PostRegisterReExaminationUrl { get; set; }
        public string GetReExaminationListByCodeAndDateUrl { get; set; }
        public string GetPatientUrl { get; set; }
        public string PostRegisterExaminationUrl { get; set; }
        public string GetPrescriptionDetailByCodeUrl { get; set; }
        public string GetListGroupDeptUrl { get; set; }
        public string PostRegisterExamByGroupUrl { get; set; }
        public string PostGetInfoOrderUrl { get; set; }
        public string GetListServiceByRegisteredCodeUrl { get; set; }
        public string PostListServiceByRegisteredCodeUrl { get; set; }
        public string PostUpdateListServiceUrl { get; set; }
        public string GetPendingListUrl { get; set; }

        /// <summary>
        ///     Gets or sets patient's registration information URL.
        /// </summary>
        /// <value>Patient's registration information URL.</value>
        public string GetAllRegistrationUrl { get; set; }

        /// <summary>
        ///     Gets or sets registration refundation URL.
        /// </summary>
        /// <value>The charge finally clinic list at store URL.</value>
        public string RefundRegistrationUrl { get; set; }

        /// <summary>
        ///     Gets or sets delete registration information URL.
        /// </summary>
        /// <value>Delete Registration Infomation URL.</value>
        public string DeleteRegistrationUrl { get; set; }

        /// <summary>
        ///     Gets or sets all title service URL.
        /// </summary>
        /// <value>all title service URL.</value>
        public string GetAllTitleUrl { get; set; }

        /// <summary>
        ///     Gets or sets all position URL.
        /// </summary>
        /// <value>all position URL.</value>
        public string GetAllPositionUrl { get; set; }

        /// <summary>
        ///     Gets or sets service group list URL.
        /// </summary>
        /// <value>service group list URL.</value>
        public string GetServiceGroupListUrl { get; set; }

        /// <summary>
        ///     Gets or sets department type list URL.
        /// </summary>
        /// <value>clinic type list URL.</value>
        public string GetDepartmentTypeListUrl { get; set; }

        /// <summary>
        ///     Gets or sets department list URL.
        /// </summary>
        /// <value>clinic type list URL.</value>
        public string GetDepartmentListUrl { get; set; }

        /// <summary>
        ///     Gets or sets supplies list URL.
        /// </summary>
        /// <value>supplies list URL.</value>
        public string GetSuppliesListUrl { get; set; }

        /// <summary>
        ///     Gets or sets province list URL.
        /// </summary>
        /// <value>province list URL.</value>
        public string GetProvinceListUrl { get; set; }

        /// <summary>
        ///     Gets or sets district list URL.
        /// </summary>
        /// <value>district list URL.</value>
        public string GetDistrictListUrl { get; set; }

        /// <summary>
        ///     Gets or sets wards list URL.
        /// </summary>
        /// <value>wards list URL.</value>
        public string GetWardsListUrl { get; set; }

        /// <summary>
        ///     Gets or sets all clinic calendar URL.
        /// </summary>
        /// <value>all clinic calendar URL.</value>
        public string GetAllClinicCalendarUrl { get; set; }

        /// <summary>
        ///     Gets or sets service URL.
        /// </summary>
        /// <value>service URL.</value>
        public string GetServiceListUrl { get; set; }

        /// <summary>
        ///     Gets or sets service result URL.
        /// </summary>
        /// <value>
        ///     The service result URL.
        /// </value>
        public string GetServiceResultListUrl { get; set; }

        /// <summary>
        ///     Gets or sets the charge registration URL.
        /// </summary>
        /// <value>
        ///     The charge registration URL.
        /// </value>
        public string ChargeRegistrationUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get medicines list URL.
        /// </summary>
        /// <value>
        ///     The get medicines list URL.
        /// </value>
        public string GetMedicinesListUrl { get; set; }

        /// <summary>
        ///     Gets or sets the get service list URL.
        /// </summary>
        /// <value>
        ///     The get medicines list URL.
        /// </value>
        public string GetServiceListFromHis { get; set; }
    }
}