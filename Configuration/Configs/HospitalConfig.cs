using CS.Common.Common;
using Microsoft.Extensions.Configuration;

namespace Core.Config.Configs
{
    /// <summary>
    ///     Class Hospital.
    /// </summary>
    public class HospitalConfig
    {
        public void LoadSettings(IConfiguration configuration)
        {
            HospitalCode = configuration["HospitalCode"];
            HospitalArea = configuration["HospitalArea"];
            TempPatientCode = configuration["TempPatientCode"];
            CardFee = int.TryParse(configuration["CardFee"], out var cardFee) ? cardFee : 0;
            LimitSyncPaidWaiting = int.TryParse(configuration["LimitSyncPaidWaiting"], out var limitSyncPaidWaiting) ? limitSyncPaidWaiting : 0;
            MinBalance = int.TryParse(configuration["MinBalance"], out var minBalance) ? minBalance : 0;
            HoldDeviceId = configuration["HoldDeviceId"];
            IsForce = bool.TryParse(configuration["IsForce"], out bool isForce) && isForce;
            GroupCode = configuration["GroupCode"];
            IsManual = bool.TryParse(configuration["IsManual"], out bool isManual) && isManual;
            IsPriority = bool.TryParse(configuration["IsPriority"], out bool isPriority) && isPriority;
            IsGroup = bool.TryParse(configuration["IsGroup"], out bool isGroup) && isGroup;
            ReExamMinDay = int.TryParse(configuration["ReExamMinDay"], out var reExamMinDay) ? reExamMinDay : 0;
            ReExamMaxDay = int.TryParse(configuration["ReExamMaxDay"], out var reExamMaxDay) ? reExamMaxDay : 0;
            DefaultFeeId = configuration["DefaultFeeId"];
            DefaultPassword = configuration["DefaultPassword"];
            IsConnectedHosptialSystem = int.TryParse(configuration["IsConnectedHosptialSystem"], out var isConnectedHospitalSystem) ? isConnectedHospitalSystem : 0;
            TimeRemoveQueueNumber = int.TryParse(configuration["TimeRemoveQueueNumber"], out var timeRemoveQueueNumber) ? timeRemoveQueueNumber : 0;
            NextCallTime = int.TryParse(configuration["NextCallTime"], out var nextCallTime) ? nextCallTime : 0;
            MaxLimitNumberOfCallingPatient = int.TryParse(configuration["MaxLimitNumberOfCallingPatient"], out var maxLimitNumberOfCallingPatient) ? maxLimitNumberOfCallingPatient : 0;
            UseLocalQueueNumber = bool.TryParse(configuration["UseLocalQueueNumber"], out var useLocalQueueNumber) && useLocalQueueNumber;
            Ip = configuration["Ip"];
            PassClinicResultDayLimit = int.TryParse(configuration["PassClinicResultDayLimit"], out var passClinicResultDayLimit) ? passClinicResultDayLimit : 0;
            BaseUrlDepartment = configuration["BaseUrlDepartment"];
            ReportRechargedTemplate = configuration["ReportRechargedTemplate"];
            ReportCardFeeAndReturnTemplate = configuration["ReportCardFeeAndReturnTemplate"];
            ReportRechargedTemplateAdmin = configuration["ReportRechargedTemplateAdmin"];
            ReportCardFeeAndReturnTemplateAdmin = configuration["ReportCardFeeAndReturnTemplateAdmin"];
            ReportOverviewCardTemplate = configuration["ReportOverviewCardTemplate"];
            ReportOverviewCardTemplateAdmin = configuration["ReportOverviewCardTemplateAdmin"];
            ReportOverviewCashflowTemplate = configuration["ReportOverviewCashflowTemplate"];
            ReportRegisterTemplate = configuration["ReportRegisterTemplate"];
            ReportRegisterTemplateAdmin = configuration["ReportRegisterTemplateAdmin"];
            ReportLostTemplate = configuration["ReportLostTemplate"];
            ReportLostTemplateAdmin = configuration["ReportLostTemplateAdmin"];
            ReportPatientBalanceTemplate = configuration["ReportPatientBalanceTemplate"];
            ReportRechargedOriginTemplate = configuration["ReportRechargedOriginTemplate"];
            ReportRechargedOriginTemplateAdmin = configuration["ReportRechargedOriginTemplateAdmin"];
            ReportReexaminationRefundTemplate = configuration["ReportReexaminationRefundTemplate"];
            ReportReexaminationRefundTemplateAdmin = configuration["ReportReexaminationRefundTemplateAdmin"];
        }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>The hospital code.</value>
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the hospital area.
        /// </summary>
        /// <value>The hospital area.</value>
        public string HospitalArea { get; set; }

        /// <summary>
        ///     Gets or sets the temporary patient code.
        /// </summary>
        /// <value>The temporary patient code.</value>
        public string TempPatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the card fee.
        /// </summary>
        /// <value>The card fee.</value>
        public int CardFee { get; set; }

        /// <summary>
        ///     Gets or sets the limit synchronize paid waiting.
        /// </summary>
        /// <value>
        ///     The limit synchronize paid waiting.
        /// </value>
        public int LimitSyncPaidWaiting { get; set; }

        /// <summary>
        ///     Gets or sets the minimum balance.
        /// </summary>
        /// <value>
        ///     The minimum balance.
        /// </value>
        public int MinBalance { get; set; }

        public string DefaultPassword { get; set; }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>The hospital code.</value>
        public int IsConnectedHosptialSystem { get; set; }

        /// <summary>
        ///     Gets or sets the temporary patient code.
        /// </summary>
        /// <value>The temporary patient code.</value>
        public string HoldDeviceId { get; set; }

        /// <summary>
        ///     Gets or sets the time remove queue number.
        /// </summary>
        /// <value>
        ///     The time remove queue number.
        /// </value>
        public int TimeRemoveQueueNumber { get; set; }

        /// <summary>
        ///     Gets or sets the next call time.
        /// </summary>
        /// <value>
        ///     The next call time.
        /// </value>
        public int NextCallTime { get; set; }

        public bool IsForce { get; set; }
        public string GroupCode { get; set; }
        public int MaxLimitNumberOfCallingPatient { get; set; }

        public bool UseLocalQueueNumber { get; set; }

        public bool IsManual { get; set; }
        public bool IsPriority { get; set; }
        public bool IsGroup { get; set; }
        public int ReExamMinDay { get; set; } = -30;
        public int ReExamMaxDay { get; set; } = 1;

        /// <summary>
        ///     Gets or sets the ip nework.
        /// </summary>
        /// <value>The ip network.</value>
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the date get clinic result.
        /// </summary>
        /// <value>
        ///     The date get clinic resul.
        /// </value>
        public int PassClinicResultDayLimit { get; set; }


        /// <summary>
        ///     Gets or sets the date get clinic result.
        /// </summary>
        /// <value>
        ///     The date get clinic resul.
        /// </value>
        public string BaseUrlDepartment { get; set; }

        /// <summary>
        ///     Gets or sets the Report Recharged Template.
        /// </summary>
        /// <value>
        ///     The next call time.
        /// </value>
        public string ReportRechargedTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the Report CardFeeAnd Return Template.
        /// </summary>
        /// <value>
        ///     The next call time.
        /// </value>
        public string ReportCardFeeAndReturnTemplate { get; set; }


        /// <summary>
        ///     Gets or sets the Report Recharged Template Admin.
        /// </summary>
        /// <value>
        ///     The next call time.
        /// </value>
        public string ReportRechargedTemplateAdmin { get; set; }

        /// <summary>
        ///     Gets or sets the Report CardFee And Return Template Admin.
        /// </summary>
        /// <value>
        ///     The next call time.
        /// </value>
        public string ReportCardFeeAndReturnTemplateAdmin { get; set; }

        /// <summary>
        ///     Gets or sets the Report Recharged Template Admin.
        /// </summary>
        /// <value>
        ///     The next call time.
        /// </value>
        public string ReportOverviewCardTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the Report CardFee And Return Template Admin.
        /// </summary>
        /// <value>
        ///     The next call time.
        /// </value>
        public string ReportOverviewCardTemplateAdmin { get; set; }

        public string ReportOverviewCashflowTemplate { get; set; }
        public string ReportRegisterTemplate { get; set; }
        public string ReportRegisterTemplateAdmin { get; set; }
        public string ReportLostTemplate { get; set; }
        public string ReportLostTemplateAdmin { get; set; }
        public string ReportPatientBalanceTemplate { get; set; }
        public string ReportRechargedOriginTemplate { get; set; }
        public string ReportRechargedOriginTemplateAdmin { get; set; }
        public string ReportReexaminationRefundTemplate { get; set; }
        public string ReportReexaminationRefundTemplateAdmin { get; set; }
        public string DefaultFeeId { get; set; }
    }
}