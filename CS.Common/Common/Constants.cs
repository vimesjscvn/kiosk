// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Constants.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using CS.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static CS.Common.Common.Constants;

namespace CS.Common.Common
{
    /// <summary>
    ///     Class Constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        ///     The format date time
        /// </summary>
        public const string FormatDateTime = "yyyyMMdd";

        /// <summary>
        ///     The male identifier
        /// </summary>
        public const string MaleId = "1";

        /// <summary>
        ///     The female identifier
        /// </summary>
        public const string FemaleId = "1";

        /// <summary>
        ///     The enum value format
        /// </summary>
        public const string EnumValueFormat = "D";

        /// <summary>
        ///     The default active
        /// </summary>
        public const bool DefaultIsActive = true;

        /// <summary>
        ///     The default active
        /// </summary>
        public const string DefaultIsActiveString = "1";

        /// <summary>
        ///     The default i deleted
        /// </summary>
        public const bool DefaultIsDeleted = false;

        /// <summary>
        ///     The default active
        /// </summary>
        public const bool DefaultIsDraft = false;

        /// <summary>
        ///     Class EnvironmentVariables.
        /// </summary>
        public static class EnvironmentVariables
        {
            /// <summary>
            ///     The aspnet core environment
            /// </summary>
            public const string AspnetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        }

        /// <summary>
        ///     Class Environments.
        /// </summary>
        public static class Environments
        {
            /// <summary>
            ///     The production
            /// </summary>
            public const string Production = "Production";
        }

        /// <summary>
        ///     Class Systems.
        /// </summary>
        public static class Systems
        {
            /// <summary>
            ///     The created by
            /// </summary>
            public const string CreatedBy = "system";

            /// <summary>
            ///     The updated by
            /// </summary>
            public const string UpdatedBy = "system";
        }

        /// <summary>
        ///     Class Departments.
        /// </summary>
        public static class Departments
        {
            /// <summary>
            ///     The TNB
            /// </summary>
            public const string TNB = "TNB";

            /// <summary>
            ///     The thuocbhyt
            /// </summary>
            public const string THUOCBHYT = "THUOCBHYT";

            /// <summary>
            ///     The tattoan
            /// </summary>
            public const string TATTOAN = "TATTOAN";

            /// <summary>
            ///     The KXN
            /// </summary>
            public const string KXN = "KXN";

            /// <summary>
            ///     The CLSX N12
            /// </summary>
            public const string CLSXN12 = "CLS.XN12";

            /// <summary>
            ///     The pay off store
            /// </summary>
            public const string PayOffStore = "Q03";

            /// <summary>
            ///     The pay off store
            /// </summary>
            public const string ClinicResult = "KQ.CLS";

            /// <summary>
            ///     The khammat
            /// </summary>
            public const string KHAMMAT = "KHAMMAT";

            public const string CPS = "CPS";
        }

        /// <summary>
        ///     Class Departments.
        /// </summary>
        public static class DepartmentTitles
        {
            /// <summary>
            ///     The TNB
            /// </summary>
            public const string DEFAULT = "Số thứ tự";

            /// <summary>
            ///     The TNB
            /// </summary>
            public const string TNB = "Số thứ tự tiếp đón";

            /// <summary>
            ///     The thuocbhyt
            /// </summary>
            public const string PHONGKHAM = "Số thứ tự phòng khám";

            /// <summary>
            ///     The tattoan
            /// </summary>
            public const string TATTOAN = "Số thứ tự thanh toán";

            /// <summary>
            ///     The thuocbhyt
            /// </summary>
            public const string TAIKHAM = "Số thứ tự tái khám";

            /// <summary>
            ///     The thuocbhyt
            /// </summary>
            public const string CDHA = "Số thứ tự";
        }

        /// <summary>
        ///     Class Departments.
        /// </summary>
        public static class ServiceGroups
        {
            /// <summary>
            ///     The TNB
            /// </summary>
            public const string XN = "xét nghiệm";
        }

        /// <summary>
        ///     Class Departments.
        /// </summary>
        public static class DocumentTypes
        {
            /// <summary>
            ///     The TNB
            /// </summary>
            public const string CCCD = "CCCD";

            /// <summary>
            ///     The thuocbhyt
            /// </summary>
            public const string BHYT = "BHYT";

            /// <summary>
            ///     The tattoan
            /// </summary>
            public const string HIS = "HIS";

            public const string PATIENT_CODE = "PATIENT_CODE";

            public const string REGISTERED_CODE = "REGISTERED_CODE";

            public const string UNKNOWN = "UNKNOWN";
        }

        /// <summary>
        ///     Class Departments.
        /// </summary>
        public static class Groups
        {
            /// <summary>
            ///     The pay off store
            /// </summary>
            public const string Endoscopic = "KHUNOISOI";

            /// <summary>
            ///     The pay off store
            /// </summary>
            public const string Ultrasound = "KHUSIEUAM";

            /// <summary>
            ///     The pay off store
            /// </summary>
            public const string XQuang = "KHUXQUANG";

            /// <summary>
            ///     The pay off store
            /// </summary>
            public const string CT = "NHOMCHUPCT";
        }

        /// <summary>
        ///     Class HealthcarePriorityCode.
        /// </summary>
        public static class HealthcarePriorityCode
        {
            /// <summary>
            ///     The cc
            /// </summary>
            public const string CC = "CC";

            /// <summary>
            ///     The ck
            /// </summary>
            public const string CK = "CK";

            /// <summary>
            ///     The kc
            /// </summary>
            public const string KC = "KC";
        }

        /// <summary>
        ///     Class HealthcarePriorityCode.
        /// </summary>
        public static class AreaCode
        {
            /// <summary>
            ///     The cc
            /// </summary>
            public const string KBA = "KBA";

            /// <summary>
            ///     The ck
            /// </summary>
            public const string KBB = "KBB";
        }

        /// <summary>
        ///     Class Department Type.
        /// </summary>
        public static class DepartmentTypeValue
        {
            /// <summary>
            ///     The success
            /// </summary>
            // Nhóm phòng chỉ định
            public const string NPCD = "NPCD";

            /// <summary>
            ///     The not found data
            /// </summary>
            // Nhóm phòng thực hiện
            public const string NPTH = "NPTH";
        }

        public static class ReExaminations
        {
            public const int MinDay = -30;
            public const int MaxDay = 1;
            public const int AllowedMaxDay = 5;
        }

        /// <summary>
        /// </summary>
        public static class CardType
        {
            /// <summary>
            ///     The local
            /// </summary>
            public const string Local = "local";

            /// <summary>
            ///     The bank
            /// </summary>
            public const string VCB = "vcb";
        }

        /// <summary>
        ///     Class ExternalClinicStatus.
        /// </summary>
        public static class HISErrorCode
        {
            /// <summary>
            ///     The success
            /// </summary>
            public const string Success = "1";

            /// <summary>
            ///     The success
            /// </summary>
            public const int NotFoundFinallyInformationData = 14;

            /// <summary>
            ///     The is finished
            /// </summary>
            public const string IsFinished = "1";

            /// <summary>
            ///     The not found data
            /// </summary>
            public const int NotExistedData = 20;

            /// <summary>
            ///     The not found data
            /// </summary>
            public const string UpdateFailedHIS = "999";

            /// <summary>
            ///     The failed
            /// </summary>
            public const string FailedPayment = "9999";

            public const int CannotConnectToGatewayServer = 9999999;

            public const int CannotConnectToHISServer = 888888;

            public const string CannotConnectToSocialInsuranceServer = "999";

            /// <summary>
            ///     The not finished
            /// </summary>
            public const string NotFinished = "0";
        }

        public static class GenderConstants
        {
            /// <summary>
            ///     The female
            /// </summary>
            public const string Female = "Nữ";

            /// <summary>
            ///     The male
            /// </summary>
            public const string Male = "Nam";
        }

        /// <summary>
        ///     Class ExternalResponseStatus.
        /// </summary>
        public static class ExternalResponseStatus
        {
            /// <summary>
            ///     The success
            /// </summary>
            public const string Success = "1";

            /// <summary>
            ///     The not found data
            /// </summary>
            public const string NotFoundData = "22";
        }


        /// <summary>
        ///     Class ManipulationContent.
        /// </summary>
        public static class ManipulationContent
        {
            /// <summary>
            ///     The register
            /// </summary>
            public const string Register = "Ghi thẻ";

            /// <summary>
            ///     The recharged
            /// </summary>
            public const string Recharged = "Nạp tiền";

            /// <summary>
            ///     The return
            /// </summary>
            public const string Return = "Trả thẻ";

            /// <summary>
            ///     The lost
            /// </summary>
            public const string Lost = "Mất thẻ không phát mới";

            /// <summary>
            ///     The lost renew
            /// </summary>
            public const string LostRenew = "Mất thẻ phát mới";

            /// <summary>
            ///     The charge
            /// </summary>
            public const string Charge = "Thanh toán tiền tạm ứng";

            /// <summary>
            ///     The refund
            /// </summary>
            public const string Refund = "Hoàn tiền";

            /// <summary>
            ///     The charge list
            /// </summary>
            public const string ChargeList = "Thanh toán tiền dịch vụ";

            /// <summary>
            ///     The finally charge
            /// </summary>
            public const string FinallyCharge = "Tất toán";

            /// <summary>
            ///     The card fee
            /// </summary>
            public const string CardFee = "Phí phát thẻ mới";

            /// <summary>
            ///     The cancel
            /// </summary>
            public const string Cancel = "Hủy nạp tiền";

            /// <summary>
            ///     The withdraw
            /// </summary>
            public const string Withdraw = "Rút tiền";
        }

        /// <summary>
        ///     Class StatusContent.
        /// </summary>
        public static class StatusContent
        {
            /// <summary>
            ///     The success
            /// </summary>
            public const string Success = "Thành công";

            /// <summary>
            ///     The fail
            /// </summary>
            public const string Fail = "Thất bại";
        }

        /// <summary>
        ///     Class TransactionStatusContent.
        /// </summary>
        public static class TransactionStatusContent
        {
            /// <summary>
            ///     The doing
            /// </summary>
            public const string Doing = "Chưa tạm ứng";

            /// <summary>
            ///     The hold
            /// </summary>
            public const string Hold = "Tạm ứng";

            /// <summary>
            ///     The paid
            /// </summary>
            public const string Paid = "Tất toán";

            /// <summary>
            ///     The cancelled
            /// </summary>
            public const string Cancelled = "Hủy";

            /// <summary>
            ///     Gets or sets the paid medicine.
            /// </summary>
            /// <value>
            ///     The paid medicine.
            /// </value>
            public static string PaidMedicine = "Thanh toán thuốc dịch vụ";

            /// <summary>
            ///     Gets or sets the return.
            /// </summary>
            /// <value>
            ///     The return.
            /// </value>
            public static string Refund = "Hoàn tiền";
        }

        /// <summary>
        ///     Class EnvironmentVariables.
        /// </summary>
        public static class DateTimeFormatConstants
        {
            /// <summary>
            ///     The yyyymmdd
            /// </summary>
            public const string YYYYMMDD = "yyyyMMdd";

            /// <summary>
            ///     The yyyymmddthhmmssz
            /// </summary>
            public const string YYYYMMDDTHHMMSSZ = "yyyyMMddTHHmmssZ";

            /// <summary>
            ///     The yyyymmddthhmmssz
            /// </summary>
            public const string CustomDefault = "yyyy-MM-ddTHH:mm:ss";

            /// <summary>
            ///     The ddmmyyyy
            /// </summary>
            public const string DDMMYYYY = "dd/MM/yyyy";

            public const string DDMMYYYYNS = "ddMMyyyy";

            /// <summary>
            ///     The yyyy
            /// </summary>
            public const string YYYY = "yyyy";

            public const string YYYY_MM_DD = "yyyy-MM-dd";

            /// <summary>
            ///     The ddmmyyyy
            /// </summary>
            public const string DDMMYYYYHHMMSS = "dd/MM/yyyy HH:mm:ss";

            /// <summary>
            ///     The ddmmyyyy
            /// </summary>
            public const string DDMMYYYYHHMM = "dd/MM/yyyy HH:mm";

            /// <summary>
            ///     The ddmmyyyy
            /// </summary>
            public const string DD_MM_YYYY = " dd-MM-yyyy";

            /// <summary>
            ///     The yyyymmddhhmmssz
            /// </summary>
            public const string YYYYMMDDHHMMSS = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// </summary>
        public static class EncryptConstants
        {
            /// <summary>
            ///     The empty body sh a256
            /// </summary>
            public const string EMPTY_BODY_SHA256 = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";

            /// <summary>
            ///     The unsigned payload
            /// </summary>
            public const string UNSIGNED_PAYLOAD = "UNSIGNED-PAYLOAD";
        }

        /// <summary>
        /// </summary>
        public static class HeaderConstants
        {
            /// <summary>
            ///     The content type
            /// </summary>
            public const string CONTENT_TYPE = "application/json";

            /// <summary>
            ///     The language
            /// </summary>
            public const string LANGUAGE = "en";

            /// <summary>
            ///     The request timeout
            /// </summary>
            public const string REQUEST_TIMEOUT = "900";
        }

        /// <summary>
        /// </summary>
        public static class NamedClientConstants
        {
            /// <summary>
            ///     The VCB
            /// </summary>
            public const string VCB = "VCB";

            /// <summary>
            ///     HIS
            /// </summary>
            public const string HIS = "HIS";

            /// <summary>
            ///     HIS
            /// </summary>
            public const string Bank = "BANK";

            /// <summary>
            ///     The internal
            /// </summary>
            public const string Internal = "INTERNAL";

            /// <summary>
            ///     The SMS
            /// </summary>
            public const string SMS = "SMS";

            /// <summary>
            ///     HIS
            /// </summary>
            public const string INSURANCE = "INSURANCE";
        }

        /// <summary>
        ///     Class ExternalClinicStatus.
        /// </summary>
        public static class StateConstants
        {
            /// <summary>
            ///     The success
            /// </summary>
            public const string Approved = "approved";

            /// <summary>
            ///     The failed
            /// </summary>
            public const string Failed = "failed";

            /// <summary>
            ///     The authorization required
            /// </summary>
            public const string AuthorizationRequired = "authorization_required";

            /// <summary>
            ///     The finished
            /// </summary>
            public const string Finished = "finished";

            /// <summary>
            ///     The new
            /// </summary>
            public const string New = "new";
        }

        /// <summary>
        ///     Class ExternalClinicStatus.
        /// </summary>
        public static class StatusServiceConstants
        {
            /// <summary>
            ///     The success
            /// </summary>
            public const string Finished = "1";

            /// <summary>
            ///     The failed
            /// </summary>
            public const string New = "0";
        }

        /// <summary>
        /// </summary>
        public static class ExaminationType
        {
            /// <summary>
            ///     The in patient
            /// </summary>
            public const string IN_PATIENT = "NOI_TRU";

            /// <summary>
            ///     The out patient
            /// </summary>
            public const string OUT_PATIENT = "NGOAI_TRU";
        }

        public static class ClinicResultConstants
        {
            /// <summary>
            ///     The success
            /// </summary>
            public const string Finished = "1";

            /// <summary>
            ///     The failed
            /// </summary>
            public const string UnFinished = "0";
        }

        public static class GroupCode
        {
            public const string Female = "A";
            public const string Male = "B";
        }

        public static class GroupName
        {
            public const string Default = "Khu B";
            public const string Female = "Khu A";
            public const string Male = "Khu B";
        }

        public static class DefautSetting
        {
            public const string DefautKey = "DEFAULT";
            public const string DefautGeneralKey = "DEFAULTGENERAL";
        }

        public static class RegsiteredType
        {
            public const string BHYT = "BHYT";
            public const string DV = "DV";
        }


        public static class PatientTypeConstants
        {
            /// <summary>
            ///     The Normal
            /// </summary>
            public const string Normal = "Thường";

            /// <summary>
            ///     The priority6
            /// </summary>
            public const string Priority6 = "Ưu Tiên 6";

            /// <summary>
            ///     The priority80
            /// </summary>
            public const string Priority80 = "Ưu Tiên 80";

            /// <summary>
            ///     The priority code
            /// </summary>
            public const string PriorityCode = "Ưu Tiên";

            /// <summary>
            ///     The priority kt
            /// </summary>
            public const string PriorityKT = "Ưu Tiên KT";

            /// <summary>
            ///     The priority bn
            /// </summary>
            public const string PriorityBN = "Ưu Tiên BN";

            /// <summary>
            ///     The priority gt
            /// </summary>
            public const string PriorityGT = "Ưu Tiên GT";

            /// <summary>
            ///     The priority ct
            /// </summary>
            public const string PriorityCT = "Ưu Tiên CT";
        }

        /// <summary>
        ///     CreatedTypeConstants
        /// </summary>
        public static class CreatedTypeConstants
        {
            /// <summary>
            ///     The website
            /// </summary>
            public const string Website = "Website";

            /// <summary>
            ///     The synchronize
            /// </summary>
            public const string Sync = "Đồng bộ HIS";

            /// <summary>
            ///     The excel
            /// </summary>
            public const string Excel = "Excel";
        }

        /// <summary>
        ///     UsageTypeConstants
        /// </summary>
        public static class UsageTypeConstants
        {
            /// <summary>
            ///     The normal
            /// </summary>
            public const string Normal = "Thường";

            /// <summary>
            ///     The service
            /// </summary>
            public const string Service = "Dịch vụ";

            /// <summary>
            ///     The male
            /// </summary>
            public const string Male = "Nam";

            /// <summary>
            ///     The female
            /// </summary>
            public const string Female = "Nữ";

            /// <summary>
            ///     The LDLK
            /// </summary>
            public const string LDLK = "LDLK (N)";
        }

        public static class ServiceTypeConstants
        {
            /// <summary>
            ///     The examination
            /// </summary>
            public const string Examination = "Công khám";

            /// <summary>
            ///     The clinic
            /// </summary>
            public const string Clinic = "Cận lâm sàng";

            /// <summary>
            ///     The unknown
            /// </summary>
            public const string Unknown = "Không xác định";
        }

        public static class ValueTypeCode
        {
            public const string PositionCode = "CV";
            public const string TitleCode = "CD";
            public const string ServiceCode = "DV";
            public const string GroupServiceCode = "NDV";
            public const string DepartmentCode = "PB";
            public const string DepartmentKindCode = "LPB";
            public const string ObjectCode = "DT";
            public const string Hospital = "DSBV";
        }

        /// <summary>
        ///     OcrTypeConstants
        /// </summary>
        public static class OcrTypeConstants
        {
            /// <summary>
            ///     The VNPT
            /// </summary>
            public const string VNPT = "VNPT";

            /// <summary>
            ///     The FPT
            /// </summary>
            public const string FPT = "FPT";

            /// <summary>
            ///     The google
            /// </summary>
            public const string GOOGLE = "GOOGLE";
        }

        public static class HospitalCodeList
        {
            /// <summary>
            ///     The VNPT
            /// </summary>
            public const string NINH_BINH_GENERAL_HOSPITAL = "37101";
        }

        public static class TypeGenderConstants
        {
            /// <summary>
            ///     The examination
            /// </summary>
            public const string All = "Tất cả";

            /// <summary>
            ///     The clinic
            /// </summary>
            public const string Male = "Nam";

            /// <summary>
            ///     The unknown
            /// </summary>
            public const string Female = "Nữ";
        }

        /// <summary>
        ///     CacheKeyConstants
        /// </summary>
        public static class CacheKeyConstants
        {
            /// <summary>
            ///     The province key
            /// </summary>
            public const string ProvinceKey = "Provinces";

            /// <summary>
            ///     The district key
            /// </summary>
            public const string DistrictKey = "Districts";

            /// <summary>
            ///     The ward key
            /// </summary>
            public const string WardKey = "Wards";
        }

        public static class ServiceResultStatus
        {
            /// <summary>
            ///     The examination
            /// </summary>
            public const string HasResult = "T";

            /// <summary>
            ///     The clinic
            /// </summary>
            public const string NoResult = "S";
        }

        public static class RoomTypeEndoscopic
        {
            // <summary>
            /// Table DTL 1
            /// </summary>
            public const string NOISOIDDK2 = "NOISOIDDK2";

            /// <summary>
            ///     Table DTL 2
            /// </summary>
            public const string NOISOICTK2 = "NOISOICTK2";

            /// <summary>
            ///     Table DTL 3
            /// </summary>
            public const string NOISOIDTK2 = "NOISOIDTK2";

            /// <summary>
            ///     Table DTL 3
            /// </summary>
            public const string NOISOIDTK3 = "NOISOIDTK3";

            /// <summary>
            ///     Table DTL 3
            /// </summary>
            public const string NOISOIDDK3 = "NOISOIDDK3";
        }

        public static class RoomTypeSA
        {
            /// <summary>
            ///     Table DTL 1
            /// </summary>
            public const string SAKHUB1 = "SAKHUB-DV-P1";

            /// <summary>
            ///     Table DTL 2
            /// </summary>
            public const string SAKHUB2 = "SAKHUB-DV-P2";

            /// <summary>
            ///     Table DTL 3
            /// </summary>
            public const string SAKHUB3 = "SAKHUB-DV-P3";

            /// <summary>
            ///     Table DTL 4
            /// </summary>
            public const string SAKHUB4 = "SAKHUB-DV-P4";

            /// <summary>
            ///     Table DTL 5
            /// </summary>
            public const string SAKHUB5 = "SAKHUB-P5";

            /// <summary>
            ///     Table DTL 6
            /// </summary>
            public const string SAKHUB6 = "SAKHUB-P6";

            /// <summary>
            ///     Table DTL 7
            /// </summary>
            public const string SAKHUB7 = "SAKHUB-P7";

            /// <summary>
            ///     Table DTL 8
            /// </summary>
            public const string SAKHUB8 = "SAKHUB-P8";

            /// <summary>
            ///     Table DTL 9
            /// </summary>
            public const string SAKHUB9 = "SAKHUB-P9";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string SAKHUB10 = "SAKHUB-P10";

            /// <summary>
            ///     Nọi soi
            /// </summary>
            public const string NOISOIK24 = "NOISOIK2.4";

            /// <summary>
            ///     Table DTL 6
            /// </summary>
            public const string NOISOIK13 = "NOISOIK1.3";

            /// <summary>
            ///     Table DTL 7
            /// </summary>
            public const string NOISOIK12 = "NOISOIK1.2";

            /// <summary>
            ///     Table DTL 8
            /// </summary>
            public const string NOISOIK25 = "NOISOIK2.5";

            /// <summary>
            ///     Table DTL 9
            /// </summary>
            public const string NOISOIK3 = "NOISOIK3";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK2 = "NOISOIK2";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK21 = "NOISOIK2.1";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK32 = "NOISOIK3.2";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK31 = "NOISOIK3.1";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK41 = "NOISOIK4.1";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK1 = "NOISOIK1";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK42 = "NOISOIK4.2";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK23 = "NOISOIK2.3";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK22 = "NOISOIK2.2";

            /// <summary>
            ///     Table DTL 10
            /// </summary>
            public const string NOISOIK4 = "NOISOIK4";


            public const string TEK_KSAB = "TEK_KSAB";

            public const string TEK_KNSB = "TEK_KNSB";
        }

        /// <summary>
        ///     Class sort condition
        /// </summary>
        public static class SortCondition
        {
            /// <summary>
            ///     Sort by tekmedicard
            /// </summary>
            public const string TEKMEDICARD = "TEKMEDICARD";

            /// <summary>
            ///     Sort by patient code
            /// </summary>
            public const string PATIENT_CODE = "PATIENT_CODE";

            /// <summary>
            ///     Sort by name
            /// </summary>
            public const string NAME = "NAME";

            /// <summary>
            ///     Sort by created date
            /// </summary>
            public const string CREATED_DATE = "CREATED_DATE";

            /// <summary>
            ///     Order by
            /// </summary>
            public const string ORDER_BY_ESC = "-ESC";

            /// <summary>
            ///     Order by descending
            /// </summary>
            public const string ORDER_BY_DESC = "-DESC";
        }
    }


    /// <summary>
    ///     Icon Status
    /// </summary>
    public enum IconStatus
    {
        /// <summary>
        ///     The private
        /// </summary>
        Private,

        /// <summary>
        ///     The public
        /// </summary>
        Public
    }

    /// <summary>
    ///     Prescription Type
    /// </summary>
    public enum ReceptionResultStatus
    {
        /// <summary>
        ///     The new
        /// </summary>
        // Bệnh nhân đã lấy stt vào phòng lấy kq-cls (không hiển thị thông tin trên lcd-cls nữa)
        HaveBeenTakeQueueNumberResult = 1,

        /// <summary>
        ///     The new
        /// </summary>
        // Tất cả dịch vụ của bệnh nhận đã thực hiện nhưng chưa lấy stt vào phòng lấy kq-cls (chỉ hiển thị trên lcd kết quả cls với status này)
        NotYetTakeQueueNumberResult = 2,

        /// <summary>
        ///     The new
        /// </summary>
        // BN có chỉ định thêm sau khi lấy kết quả (BN có status này sẽ được cấp stt mới khi quay lại phòng lấy kq-cls)
        TakeMoreClinics = 3,

        /// <summary>
        ///     The new
        /// </summary>
        // BN có chỉ định thêm sau khi lấy kết quả và tất cả đã thực hiện ( hiển thị trên lcd kết quả cls với status này )
        TakeMoreClinicIsFull = 4
    }

    /// <summary>
    ///     Gender
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        /// <summary>
        ///     The public
        /// </summary>
        [EnumMember(Value = GenderConstants.Female)]
        Female,

        /// <summary>
        ///     The Male
        /// </summary>
        [EnumMember(Value = GenderConstants.Male)]
        Male
    }

    /// <summary>
    ///     Patient Type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PatientType
    {
        /// <summary>
        ///     The Normal
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.Normal)]
        Normal,

        /// <summary>
        ///     The priority6
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.Priority6)]
        Priority6,

        /// <summary>
        ///     The priority80
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.Priority80)]
        Priority80,

        /// <summary>
        ///     The priority code
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.PriorityCode)]
        PriorityCode,

        /// <summary>
        ///     The priority kt
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.PriorityKT)]
        PriorityKT,

        /// <summary>
        ///     The priority bn
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.PriorityBN)]
        PriorityBN,

        /// <summary>
        ///     The priority gt
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.PriorityGT)]
        PriorityGT,

        /// <summary>
        ///     The priority ct
        /// </summary>
        [EnumMember(Value = PatientTypeConstants.PriorityCT)]
        PriorityCT
    }

    /// <summary>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UsageType
    {
        /// <summary>
        ///     The normal
        /// </summary>
        [EnumMember(Value = UsageTypeConstants.Normal)]
        Normal,

        /// <summary>
        ///     The service
        /// </summary>
        [EnumMember(Value = UsageTypeConstants.Service)]
        Service,

        /// <summary>
        ///     The male
        /// </summary>
        [EnumMember(Value = UsageTypeConstants.Male)]
        Male,

        /// <summary>
        ///     The female
        /// </summary>
        [EnumMember(Value = UsageTypeConstants.Female)]
        Female,

        /// <summary>
        ///     The LDLK
        /// </summary>
        [EnumMember(Value = UsageTypeConstants.LDLK)]
        LDLK
    }

    /// <summary>
    ///     Gender
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        ///     The failed
        /// </summary>
        Failed,

        /// <summary>
        ///     The pending
        /// </summary>
        Pending,

        /// <summary>
        ///     The success
        /// </summary>
        Success,

        /// <summary>
        ///     The cancelled
        /// </summary>
        Cancelled
    }

    /// <summary>
    ///     Gender
    /// </summary>
    public enum QueueNumberType
    {
        /// <summary>
        ///     Creates new patient.
        /// </summary>
        NotHaveFollowUpExamination = 1,

        /// <summary>
        ///     The have follow up examination
        /// </summary>
        HaveFollowUpClinicNotExamination = 2,

        /// <summary>
        ///     The have follow up examination not clinic
        /// </summary>
        HaveFollowUpExaminationNotClinic = 3,

        /// <summary>
        ///     The have follow up examination and clinic and enough balance
        /// </summary>
        HaveFollowUpExaminationAndClinic = 4,

        /// <summary>
        ///     The have follow up examination and clinic and not enough balance
        /// </summary>
        HaveFollowUpExaminationAndClinicAndNotEnoughBalance = 5
    }

    /// <summary>
    ///     Gender
    /// </summary>
    public enum BalanceStatus
    {
        /// <summary>
        ///     The public
        /// </summary>
        EnoughBalance,

        /// <summary>
        ///     The Male
        /// </summary>
        NotEnoughBalance
    }

    /// <summary>
    ///     Enum PatientReceiverType
    /// </summary>
    public enum PatientReceiverType
    {
        /// <summary>
        ///     The new
        /// </summary>
        NotHaveFollowUpExamination = 1,

        /// <summary>
        ///     The have follow up examination
        /// </summary>
        HaveFollowUpClinicNotExamination = 2,

        /// <summary>
        ///     The have examination and clinic not card number
        /// </summary>
        HaveFollowUpExaminationNotClinic = 3,

        /// <summary>
        ///     The have examination and clinic and card number
        /// </summary>
        HaveFollowUpExaminationAndClinic = 4
    }

    /// <summary>
    ///     Transaction Status
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        ///     The success
        /// </summary>
        Success,

        /// <summary>
        ///     The failed
        /// </summary>
        Failed,

        /// <summary>
        ///     The waiting
        /// </summary>
        Waiting,

        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The approved
        /// </summary>
        Approved,

        /// <summary>
        ///     The authorization required
        /// </summary>
        AuthorizationRequired
    }

    /// <summary>
    ///     Transaction Status
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        ///     The hold
        /// </summary>
        Hold,

        /// <summary>
        ///     The paid
        /// </summary>
        Paid,

        /// <summary>
        ///     The return
        /// </summary>
        Refund,

        /// <summary>
        ///     The paid medicine
        /// </summary>
        ServiceMedicine,

        /// <summary>
        ///     The cancelled
        /// </summary>
        Cancelled,

        /// <summary>
        ///     The paid extra
        /// </summary>
        Extra,

        /// <summary>
        ///     The hold
        /// </summary>
        Draft
    }

    /// <summary>
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The hold
        /// </summary>
        Hold,

        /// <summary>
        ///     The paid
        /// </summary>
        Paid,

        /// <summary>
        ///     The return
        /// </summary>
        Refund,

        /// <summary>
        ///     The paid medicine
        /// </summary>
        ServiceMedicine,

        /// <summary>
        ///     The cancelled
        /// </summary>
        Cancelled,

        /// <summary>
        ///     The paid extra
        /// </summary>
        Extra
    }

    public enum ClinicPaymentStatus
    {
        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The hold
        /// </summary>
        Hold,

        /// <summary>
        ///     The paid
        /// </summary>
        Paid,

        /// <summary>
        ///     The cancelled
        /// </summary>
        Cancelled
    }

    /// <summary>
    ///     Clinic Status
    /// </summary>
    public enum ClinicStatus
    {
        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The hold
        /// </summary>
        Hold,

        /// <summary>
        ///     The paid
        /// </summary>
        Paid,

        /// <summary>
        ///     The cancelled
        /// </summary>
        Cancelled
    }

    /// <summary>
    ///     Clinic Type
    /// </summary>
    public enum ClinicType
    {
        /// <summary>
        ///     The examination
        /// </summary>
        Examination,

        /// <summary>
        ///     The clinic
        /// </summary>
        Clinic
    }

    /// <summary>
    ///     Enum TransactionReportStatus
    /// </summary>
    public enum TransactionReportStatus
    {
        /// <summary>
        ///     The doing
        /// </summary>
        Doing = 1,

        /// <summary>
        ///     The paid
        /// </summary>
        Paid = 2
    }

    /// <summary>
    ///     Prescription Type
    /// </summary>
    public enum PrescriptionStatus
    {
        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The paid
        /// </summary>
        Paid,

        /// <summary>
        ///     The hold
        /// </summary>
        Hold,

        /// <summary>
        ///     The hold
        /// </summary>
        Cancelled
    }

    /// <summary>
    ///     Prescription Type
    /// </summary>
    public enum PrescriptionType
    {
        /// <summary>
        ///     The use with service
        /// </summary>
        UseWithService,

        /// <summary>
        ///     The use by doctor
        /// </summary>
        UseByDoctor
    }

    /// <summary>
    ///     Priority Type
    /// </summary>
    public enum PriorityType
    {
        /// <summary>
        ///     The Normal
        /// </summary>
        Normal,

        /// <summary>
        ///     The priority
        /// </summary>
        Priority
    }

    /// <summary>
    ///     Patient Type
    /// </summary>
    public enum QueueTempStatus
    {
        /// <summary>
        ///     The Normal
        /// </summary>
        Verified,

        /// <summary>
        ///     The added
        /// </summary>
        Added
    }

    /// <summary>
    /// </summary>
    public enum ReceptionStatus
    {
        /// <summary>
        ///     The new
        /// </summary>
        Waiting = 8,

        /// <summary>
        ///     The hold
        /// </summary>
        Failed = 9,

        /// <summary>
        ///     The paid
        /// </summary>
        Success = 10
    }

    /// <summary>
    /// </summary>
    public enum ReceptionType
    {
        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The hold
        /// </summary>
        Hold,

        /// <summary>
        ///     The paid
        /// </summary>
        Paid,

        /// <summary>
        ///     The cancelled
        /// </summary>
        Cancelled
    }

    public enum PaidWaitingStatus
    {
        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The waiting
        /// </summary>
        Waiting,

        /// <summary>
        ///     The finished
        /// </summary>
        Finished
    }

    /// <summary>
    ///     Clinic Status
    /// </summary>
    public enum BankStatus
    {
        /// <summary>
        ///     The new
        /// </summary>
        New,

        /// <summary>
        ///     The registered
        /// </summary>
        Registered,

        /// <summary>
        ///     The hold
        /// </summary>
        Approved
    }

    public enum PaymentProvider
    {
        /// <summary>
        ///     The new
        /// </summary>
        Local,

        /// <summary>
        ///     The hold
        /// </summary>
        Bank
    }

    /// <summary>
    /// </summary>
    public enum CardType
    {
        /// <summary>
        ///     The new
        /// </summary>
        Local,

        /// <summary>
        ///     The registered
        /// </summary>
        Bank
    }

    /// <summary>
    /// </summary>
    public static class TransactionTypeConstants
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string GetName(TransactionType type)
        {
            switch (type)
            {
                case TransactionType.Hold:
                    return "Tạm ứng";
                case TransactionType.Paid:
                    return "Tất toán";
                case TransactionType.Refund:
                    return "Hoàn";
                case TransactionType.ServiceMedicine:
                    return "Thanh toán thuốc dịch vụ";
                case TransactionType.Cancelled:
                    return "Hủy";
                case TransactionType.Extra:
                    return "Thu thêm";
            }

            return string.Empty;
        }

        /// <summary>
        ///     Gets the status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public static string GetStatus(TransactionStatus status)
        {
            switch (status)
            {
                case TransactionStatus.Success:
                    return "Thành công";
                case TransactionStatus.Failed:
                    return "Thất bại";
                case TransactionStatus.Waiting:
                    return "Đang chờ";
                case TransactionStatus.New:
                    return "Mới";
                case TransactionStatus.Approved:
                    return "Đã thanh toán";
                case TransactionStatus.AuthorizationRequired:
                    return "Chờ xác thực";
            }

            return string.Empty;
        }
    }

    /// <summary>
    /// </summary>
    public static class CardTypeConstants
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string GetTypeName(TypeEnum type)
        {
            switch (type)
            {
                case TypeEnum.Register:
                    return "Ghi thẻ";
                case TypeEnum.Recharged:
                    return "Nạp tiền";
                case TypeEnum.Return:
                    return "Trả thẻ";
                case TypeEnum.Lost:
                    return "Mất thẻ";
                case TypeEnum.Charge:
                    return "Tạm ứng";
                case TypeEnum.Refund:
                    return "Hoàn tiền";
                case TypeEnum.ChargeList:
                    return "Tạm ứng";
                case TypeEnum.FinallyCharge:
                    return "Tất toán";
                case TypeEnum.CardFee:
                    return "Phí mất thẻ";
                case TypeEnum.Cancel:
                    return "Hủy";
                case TypeEnum.Withdraw:
                    return "Rút tiền";
            }

            return string.Empty;
        }

        /// <summary>
        ///     Gets the name of the status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public static string GetStatusName(StatusEnum status)
        {
            switch (status)
            {
                case StatusEnum.Failed:
                    return "Thất bại";
                case StatusEnum.Success:
                    return "Thành công";
                case StatusEnum.Waiting:
                    return "Đang chờ";
            }

            return string.Empty;
        }
    }

    /// <summary>
    /// </summary>
    public enum FinallyPaymentStatus
    {
        /// <summary>
        ///     The no action
        /// </summary>
        NoAction,

        /// <summary>
        ///     The only refund
        /// </summary>
        OnlyLocalRefund,

        /// <summary>
        ///     The only refund
        /// </summary>
        OnlyBankRefund,

        /// <summary>
        ///     The only extra
        /// </summary>
        OnlyExtra,

        /// <summary>
        ///     The local and bank refund
        /// </summary>
        LocalAndBankRefund,

        /// <summary>
        ///     The extra and bank refund
        /// </summary>
        ExtraAndBankRefund
    }

    /// <summary>
    /// </summary>
    public enum AuthorizationType
    {
        /// <summary>
        ///     The none
        /// </summary>
        None,

        /// <summary>
        ///     The user name
        /// </summary>
        UserName,

        /// <summary>
        ///     The phone
        /// </summary>
        Phone
    }

    /// <summary>
    /// </summary>
    public enum HistoryType
    {
        /// <summary>
        ///     The reception
        /// </summary>
        Reception,

        /// <summary>
        ///     The queue number
        /// </summary>
        QueueNumber,

        /// <summary>
        ///     The synchronize transaction
        /// </summary>
        SyncTransaction,

        /// <summary>
        ///     The cancel transaction
        /// </summary>
        CancelTransaction
    }

    /// <summary>
    /// </summary>
    public enum EmailType
    {
        /// <summary>
        ///     The reception
        /// </summary>
        Reception,

        /// <summary>
        ///     The queue number
        /// </summary>
        QueueNumber,

        /// <summary>
        ///     The synchronize transaction
        /// </summary>
        SyncTransaction,

        /// <summary>
        ///     The cancel transaction
        /// </summary>
        CancelTransaction
    }

    /// <summary>
    /// </summary>
    public enum TableDeviceType
    {
        /// <summary>
        ///     The normal
        /// </summary>
        NORMAL,

        /// <summary>
        ///     The CPS
        /// </summary>
        CPS
    }

    /// <summary>
    /// </summary>
    public enum ReceptionClinicStatus
    {
        /// <summary>
        ///     The none
        /// </summary>
        None = 0,

        /// <summary>
        ///     The new
        /// </summary>
        New = 1,

        /// <summary>
        ///     The part
        /// </summary>
        Part = 2,

        /// <summary>
        ///     The full
        /// </summary>
        Full = 3,

        /// <summary>
        ///     The full
        /// </summary>
        Read = 4
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CreatedType
    {
        /// <summary>
        ///     The web
        /// </summary>
        [EnumMember(Value = CreatedTypeConstants.Website)]
        Web,

        /// <summary>
        ///     The synchronize
        /// </summary>
        [EnumMember(Value = CreatedTypeConstants.Sync)]
        Sync,

        /// <summary>
        ///     The import excel
        /// </summary>
        [EnumMember(Value = CreatedTypeConstants.Excel)]
        ImportExcel
    }

    /// <summary>
    ///     ServiceType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceType
    {
        /// <summary>
        ///     The examination
        /// </summary>
        [EnumMember(Value = ServiceTypeConstants.Examination)]
        Examination,

        /// <summary>
        ///     The clinic
        /// </summary>
        [EnumMember(Value = ServiceTypeConstants.Clinic)]
        Clinic,

        /// <summary>
        ///     The unknown
        /// </summary>
        [EnumMember(Value = ServiceTypeConstants.Unknown)]
        Unknown
    }

    public enum DepartmentType
    {
        TNB,
        ROOM,
        THUOCBHYT
    }

    public enum ExamRegistrationType
    {
        HUYET_AP,
        TIEU_DUONG,
        HEN
    }

    /// <summary>
    ///     OcrType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OcrType
    {
        /// <summary>
        ///     The VNPT
        /// </summary>
        [EnumMember(Value = OcrTypeConstants.VNPT)]
        VNPT,

        /// <summary>
        ///     The FPT
        /// </summary>
        [EnumMember(Value = OcrTypeConstants.FPT)]
        FPT,

        /// <summary>
        ///     The google
        /// </summary>
        [EnumMember(Value = OcrTypeConstants.GOOGLE)]
        GOOGLE
    }

    public enum InputTypeCard
    {
        None,

        PatientCard,

        HealthInsuranceCard,

        IdentityCard,

        RegisteredCode,

        Unknown
    }

    public enum Functions
    {
        RECEPTION_ORDER_NUMBER = 0, // Lấy STT Tiếp Đón

        RECEPTION_PRIORITY_ORDER_NUMBER = 1, // Lấy STT Tiếp Đón Ưu Tiên

        PAYMENT_ORDER_NUMBER = 2, // Lấy STT Thanh Toán

        EXAMINATION_REGISTRATION = 3, // Đăng Ký Chuyên Khoa

        RE_EXAMINATION_REGISTRATION = 4, // Tái Khám

        HEALTH_EXAMINATION_RECORDS = 5, // Tra Cứu Hồ Sơ Sức Khỏe

        SURVEY = 6, // Khảo Sát

        PRICE_TABLE = 7, // Bảng Giá

        RECEPTION_REGISTRATION = 8, // Đăng Ký Nhập Tay Thủ Công

        TOP_UP = 9, // Nạp Tiền

        FAST_RECEPTION_REGISTRATION = 10, // Đăng Ký Nhanh

        DIAGNOSING_IMAGE = 11, // Lấy STT CDHA

        EXAMINATION_GROUP_REGISTRATION = 12, // Đăng Ký Nhóm Chuyên Khoa

        RECEPTION_ORDER_NUMBER_WITH_MUTLI_AREA = 13, // Lấy STT Tiếp đón dành dành cho nhiều khu

        RECEPTION_ORDER_NUMBER_NINH_BINH_GENERAL_HOSPITAL = 14,

        PAYMENT_ORDER_NUMBER_NINH_BINH_GENERAL_HOSPITAL = 15
    }

    /// <summary>
    ///     ServiceType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeGender
    {
        /// <summary>
        ///     All
        /// </summary>
        [EnumMember(Value = TypeGenderConstants.All)]
        All,

        /// <summary>
        ///     nam
        /// </summary>
        [EnumMember(Value = TypeGenderConstants.Male)]
        Male,

        /// <summary>
        ///     nu
        /// </summary>
        [EnumMember(Value = TypeGenderConstants.Female)]
        Female
    }

    public enum DeviceType
    {
        KIOSK,
        ITOUCH,
        LCD
    }

    public enum RoomType
    {
        /// <summary>
        ///     The Tiep nhan benh
        /// </summary>
        TNB = 0,

        /// <summary>
        ///     The Do thi luc
        /// </summary>
        DTL = 1,

        /// <summary>
        ///     The Do sieu am
        /// </summary>
        SA = 2,

        /// <summary>
        ///     The Do noi soi
        /// </summary>
        NS = 3
    }

    public enum ObjectType
    {
        BHYT = 1,
        DICHVU = 2,
        THUPHI = 3
    }

    public enum Applications
    {
        KIOSK_API = 1,
        ADMIN_API = 2,
        DEPARTMENT_GROUP_API = 3,
        AUTH_API = 4,
        PRIVATE_API = 5,
        PUBLIC_API = 6,
    }
}