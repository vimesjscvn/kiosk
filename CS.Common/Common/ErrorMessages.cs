// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ErrorMessages.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.Common.Common
{
    /// <summary>
    ///     Class ErrorMessages.
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        ///     The not enough balance message
        /// </summary>
        public const string Default = "Có lỗi hệ thống xảy ra, vui lòng thử lại.";

        /// <summary>
        ///     The not enough balance message
        /// </summary>
        public const string NotEnoughBalanceMessage = "Số tiền không đủ";

        /// <summary>
        ///     The not enough balance message
        /// </summary>
        public const string EnoughBalanceMessage = "Số tiền đủ";

        /// <summary>
        ///     The not enough in patient balance message
        /// </summary>
        public const string NotEnoughInPatientBalanceMessage =
            "Số dư bệnh nhân là 0 đồng. Vui lòng nạp tiền trước khi thanh toán.";

        /// <summary>
        ///     The have not provided card number
        /// </summary>
        public const string HaveNotProvidedCardNumber = "Bệnh nhân chưa được cấp thẻ.";

        /// <summary>
        ///     The not found card number
        /// </summary>
        public const string NotFoundCardNumber = "Thẻ Tekmedi không tìm thấy.";

        /// <summary>
        ///     The exsited paid transaction
        /// </summary>
        public const string ExsitedPaidTransaction = "Tồn tại ít nhất một dịch vụ đã được tất toán.";

        /// <summary>
        ///     The not found card number
        /// </summary>
        public const string NotMatchCardNumber = "Thẻ Tekmedi không khớp với bệnh nhân.";

        /// <summary>
        ///     The not found patient code
        /// </summary>
        public const string NotFoundPatientCode = "Không tìm thấy thông tin của mã bệnh nhân.";

        /// <summary>
        ///     The not found clinic
        /// </summary>
        public const string NotFoundClinic = "Bệnh nhân chưa được đăng ký khám.";

        /// <summary>
        ///     The holded clinic
        /// </summary>
        public const string HoldedClinic = "Công khám này đã được tạm ứng.";

        /// <summary>
        ///     The not found temporary patient code
        /// </summary>
        public const string NotFoundTempPatientCode = "Mã bệnh nhân tạm không tồn tại.";

        /// <summary>
        ///     The not found card number mapping with patient
        /// </summary>
        public const string NotFoundCardNumberMappingWithPatient =
            "Không tìm thấy thông tin bệnh nhân tương ứng với thẻ.";

        /// <summary>
        ///     The not use card number
        /// </summary>
        public const string NotUseCardNumber = "Thẻ tekmedi chưa được sử dụng.";

        /// <summary>
        ///     The not hold clinic
        /// </summary>
        public const string NotHoldClinic = "CLS này chưa được tạm ứng.";

        /// <summary>
        ///     The paid clinic
        /// </summary>
        public const string PaidClinic = "CLS này đã được tất toán.";

        /// <summary>
        ///     The not found queue number
        /// </summary>
        public const string NotFoundQueueNumber = "Không tìm thấy số thứ tự trong phòng này.";

        /// <summary>
        ///     The existed queue number
        /// </summary>
        public const string ExistedQueueNumber = "Số thứ tự này đã được thêm vào danh sách.";

        /// <summary>
        ///     The finished queue number temporary
        /// </summary>
        public const string FinishedQueueNumberTemp = "Số thứ tự này đã kết thúc.";

        /// <summary>
        ///     The cancel clinic success message
        /// </summary>
        public const string CancelClinicSuccessMessage = "Hủy thành công.";

        /// <summary>
        ///     The not correctly table code
        /// </summary>
        public const string NotCorrectlyTableCode = "Bệnh nhân đăng ký sai quầy nhận thuốc.";

        /// <summary>
        ///     The not found finally clinic
        /// </summary>
        public const string NotFoundFinallyClinic = "Không tìm thấy dữ liệu tất toán";

        /// <summary>
        ///     The not found table
        /// </summary>
        public const string NotFoundTable = "Không tìm thấy quầy";

        /// <summary>
        ///     The not found document
        /// </summary>
        public const string NotFoundDocument = "Không có dữ liệu để tải lên";

        /// <summary>
        ///     The not found employee code
        /// </summary>
        public const string NotFoundEmployeeCode = "Mã nhân viên không tại";

        /// <summary>
        ///     The cancel clinic success message
        /// </summary>
        public const string CancelledFinallyInformationData =
            "Không tìm thấy chi phí tất toán. Hủy các chi phí tạm ứng thành công.";

        /// <summary>
        ///     The cancelled transaction
        /// </summary>
        public const string CancelledTransaction = "Hủy giao dịch.";

        /// <summary>
        ///     The registered code is paid
        /// </summary>
        public const string RegisteredCodeIsPaid = "Số tiếp nhận đã được tất toán.";

        /// <summary>
        ///     The not statisfy condition to cancel
        /// </summary>
        public const string NotStatisfyConditionToCancel = "Giao dịch không đủ điều kiển để hủy.";

        /// <summary>
        ///     The not statisfy hold condition to cancel
        /// </summary>
        public const string NotStatisfyHoldConditionToCancel =
            "Tồn tại ít nhất một dịch vụ không thuộc trạng thái hold.";

        /// <summary>
        ///     The not statisfy no finish condition to cancel
        /// </summary>
        public const string NotStatisfyNoFinishConditionToCancel = "Tồn tại ít nhất một dịch vụ đã thực hiện.";

        /// <summary>
        ///     The nagative price
        /// </summary>
        public const string NagativePrice = "Số tiền phải là số dương";

        /// <summary>
        ///     The zero price
        /// </summary>
        public const string ZeroPrice = "Số dư của bệnh nhân là không. Vui lòng nạp tiền trước khi thanh toán.";

        /// <summary>
        ///     The patient registered tekmedi card
        /// </summary>
        public const string PatientRegisteredTekmediCard = "Bệnh nhân đã phát thẻ";

        /// <summary>
        ///     The invalid card number
        /// </summary>
        public const string InvalidCardNumber = "Mã thẻ không hợp lệ";

        /// <summary>
        ///     The registered tekmedi card
        /// </summary>
        public const string RegisteredTekmediCard = "Thẻ đã được gán cho bệnh nhân khác";

        /// <summary>
        ///     The not found history
        /// </summary>
        public const string NotFoundHistory = "Không tìm thấy lịch sử";

        /// <summary>
        ///     The cancelled history
        /// </summary>
        public const string CancelledHistory = "Giao dịch đã được hủy";

        /// <summary>
        ///     The condition withdraw
        /// </summary>
        public const string ConditionWithdraw = "Không thể rút số tiền lớn hơn số tiền trong thẻ";

        /// <summary>
        ///     The not found new patient
        /// </summary>
        public const string NotFoundNewPatient = "Đã hết số thứ tự trong phòng này.";

        /// <summary>
        ///     The not found clinic list
        /// </summary>
        public const string NotFoundClinicList = "Không tìm thấy dữ liệu.";

        /// <summary>
        ///     The not found paiding
        /// </summary>
        public const string NotFoundPaiding = "Bệnh nhân không có hóa đơn nào cần thanh toán.";

        /// <summary>
        ///     The not found paiding
        /// </summary>
        public const string NotFoundHistoryInfo = "Không tìm thấy thông tin đăng ký tại bệnh viện.";

        public const string NotFoundRegisteredHistory = "Không tìm thấy hóa đơn cần thanh toán.";

        /// <summary>
        ///     Limit sync paid waiting
        /// </summary>
        public const string LimitSyncPaidWaiting = "Không thể đồng bộ hơn {0} ngày.";

        /// <summary>
        ///     The minimum balance
        /// </summary>
        public const string MinBalance = "Số tiền còn lại trong thẻ tối thiểu là {0}.";

        /// <summary>
        ///     The not found transaction identifier
        /// </summary>
        public const string NotFoundTransactionId = "Không tìm thấy mã giao dịch.";

        /// <summary>
        ///     The not found reception number
        /// </summary>
        public const string NotFoundReceptionNumber = "Không tìm thấy số tiếp nhận.";

        /// <summary>
        ///     The not found clinic data
        /// </summary>
        public const string NotFoundClinicData = "Không tìm thấy dữ liệu công khám.";

        /// <summary>
        ///     The refund clinic success message
        /// </summary>
        public const string RefundClinicSuccessMessage = "Hoàn tiền thành công.";

        /// <summary>
        ///     The refund transaction success message
        /// </summary>
        public const string RefundTransactionSuccessMessage = "Hoàn giao dịch thành công.";

        /// <summary>
        ///     The not found paiding waiting
        /// </summary>
        public const string NotFoundPaidingWaiting = "Không tìm thấy";

        /// <summary>
        ///     The not found store code
        /// </summary>
        public const string NotFoundStoreCode = "Không tìm thấy quầy";

        /// <summary>
        ///     The not found card number
        /// </summary>
        public const string InCorrectlyAccountBalance =
            "Vui lòng thanh toán nợ trước khi thực hiện thao tác tiếp theo.";

        /// <summary>
        ///     The not found card number
        /// </summary>
        public const string ErrorTransaction = "Giao dịch bị lỗi.";

        /// <summary>
        ///     The not yet register bank account
        /// </summary>
        public const string NotYetRegisterBankAccount = "Bệnh nhân chưa đăng ký thẻ ngân hàng";

        /// <summary>
        ///     The not found linked bank account
        /// </summary>
        public const string NotFoundLinkedBankAccount = "Tài khoản ngân hàng chưa liên kết thẻ";

        /// <summary>
        ///     The create token failed message
        /// </summary>
        public const string CreateTokenFailedMessage = "Xảy ra lỗi khi tạo token";

        /// <summary>
        ///     The wrong phone or password
        /// </summary>
        public const string WrongPhoneOrPassword = "Số điện thoại hoặc mật khẩu không đúng.";

        /// <summary>
        ///     The identity card number is registered bank
        /// </summary>
        public const string IdentityCardNumberIsRegisteredBank = "CMND này đã được đăng ký.";

        /// <summary>
        ///     The not found registered bank account
        /// </summary>
        public const string NotFoundRegisteredBankAccount = "Tài khoản ngân hàng chưa đăng ký";

        /// <summary>
        ///     The patient linked bank account
        /// </summary>
        public const string PatientLinkedBankAccount = "Tài khoản này đã được đăng ký với bệnh nhân này";

        /// <summary>
        ///     The not found identity card nubmber
        /// </summary>
        public const string NotFoundIdentityCardNumber = "CMND chưa được đăng ký";

        /// <summary>
        ///     The transaction is paid
        /// </summary>
        public const string TransactionIsPaid = "Giao dịch đã thanh toán";

        /// <summary>
        ///     The not found device
        /// </summary>
        public const string NotFoundDevice = "Không tìm thấy device";

        /// <summary>
        ///     The not linked hospital and bank
        /// </summary>
        public const string NotLinkedHospitalAndBank = "Thẻ này chưa được liên kết với mã bệnh nhân ở BV";

        /// <summary>
        ///     The not active bank account
        /// </summary>
        public const string NotActiveBankAccount = "Thẻ này chưa được kích hoạt";

        /// <summary>
        ///     The authorization bank
        /// </summary>
        public const string AuthorizationBank = "Đang chờ xác nhận OTP";

        /// <summary>
        ///     The not authorization success
        /// </summary>
        public const string NotAuthorizationSuccess = "Xác thực không thành công";

        /// <summary>
        ///     The update failed his
        /// </summary>
        public const string UpdateFailedHIS = "Cập nhật HIS thất bại";

        /// <summary>
        ///     The wrong phone or password
        /// </summary>
        public const string NotFoundUserNameOrPhone = "Số điện thoại hoặc mật khẩu không đúng.";

        /// <summary>
        ///     The invalid qr code
        /// </summary>
        public const string InvalidQRCode = "Mã QR không hợp lệ.";

        /// <summary>
        ///     The not found extra transaction
        /// </summary>
        public const string NotFoundExtraTransaction = "Không tìm thấy giao dịch thanh toán.";

        /// <summary>
        ///     The patient had exist queue number
        /// </summary>
        public const string PatientHadExistQueueNumber = "Bệnh nhân đã có số thứ tự trong phòng này.";

        /// <summary>
        ///     The invalid time remove queue
        /// </summary>
        public const string InvalidTimeRemoveQueue = "Thời gian xóa số thứ tự không chính xác.";

        /// <summary>
        ///     The verify code faild
        /// </summary>
        public const string VerifyCodeFaild = "Mã xác nhận không chính xác.";

        /// <summary>
        ///     The not found extend value
        /// </summary>
        public const string NotFoundExtendValue = "Mã phòng không tồn tại.";

        /// <summary>
        ///     The invalid format email
        /// </summary>
        public const string InvalidFormatEmail = "Địa chỉ email không đúng định dạng.";

        /// <summary>
        ///     The not found email setting
        /// </summary>
        public const string NotFoundEmailSetting = "Không tìm thấy cài đặt email.";

        /// <summary>
        ///     The invalid mail type
        /// </summary>
        public const string InvalidMailType = "Loại hình gửi mail không chính xác.";

        /// <summary>
        ///     The table not exist
        /// </summary>
        public const string TableNotExist = "Không tồn tại bàn này";

        /// <summary>
        ///     The patient has not taken number
        /// </summary>
        public const string PatientHasNotTakenNumber = "Bệnh nhân này chưa lấy số";

        /// <summary>
        ///     The queue number is not turn
        /// </summary>
        public const string QueueNumberIsNotTurn = "Số thứ tự chưa đến lượt";

        /// <summary>
        ///     The invalid amount
        /// </summary>
        public const string InvalidAmount = "Số tiền phải lớn hơn 0.";

        /// <summary>
        ///     The not found service
        /// </summary>
        public const string NotFoundService = "Không tìm thấy mã dịch vụ {0}.";

        /// <summary>
        ///     The not found patient with code
        /// </summary>
        public const string NotFoundPatientWithCode = "Không tìm thấy bệnh nhân có mã {0}.";

        /// <summary>
        ///     The invalid examination type
        /// </summary>
        public const string InvalidExaminationType = "Loại hình bệnh nhân không đúng.";

        /// <summary>
        ///     The not found doctor
        /// </summary>
        public const string NotFoundDoctor = "Mã bác sĩ không tồn tại.";

        /// <summary>
        ///     The invalid format datetime
        /// </summary>
        public const string InvalidFormatDatetime = "Định dạng ngày giờ không đúng.";

        /// <summary>
        ///     The unknow error
        /// </summary>
        public const string UnknowError = "Lỗi không xác định.";

        /// <summary>
        ///     The not found phone number
        /// </summary>
        public const string NotFoundPhoneNumber = "Không tìm thấy thông tin bệnh nhân với số điện thoại này.";

        /// <summary>
        ///     The not found queue number register
        /// </summary>
        public const string NotFoundQueueNumberRegister = "Không tìm thấy số thứ tự";

        /// <summary>
        ///     The not found hospital code
        /// </summary>
        public const string NotFoundHospitalCode = "Không tìm thấy mã bệnh viện";

        /// <summary>
        ///     The invalid phone number
        /// </summary>
        public const string InvalidPhoneNumber = "Số điện thoại không hợp lệ.";

        /// <summary>
        ///     The patient has registerd
        /// </summary>
        public const string PatientHasRegisterd = "Bệnh nhân đã đăng ký số thứ tự ở bệnh viện này.";

        /// <summary>
        ///     The invalid registered date
        /// </summary>
        public const string InvalidRegisteredDate = "Ngày đăng ký khám phải lớn hơn ngày hiện tại.";

        /// <summary>
        ///     The can not update temporary patient
        /// </summary>
        public const string CanNotUpdateTempPatient = "Không thể cập nhật thông tin, vì ngày đăng ký khám đã quá hạn.";

        /// <summary>
        ///     The not found pharmacy
        /// </summary>
        public const string NotFoundPharmacy = "Mã thuốc không tồn tại.";

        /// <summary>
        ///     The not found medicine
        /// </summary>
        public const string NotFoundMedicine = "Mã dược không tồn tại.";

        /// <summary>
        ///     The not found extend value
        /// </summary>
        public const string NotFoundListValue = "Không tìm thấy dữ liệu.";

        /// <summary>
        ///     The not found list value type
        /// </summary>
        public const string NotFoundListValueType = "Không tìm thấy dữ liệu.";

        /// <summary>
        ///     The invalid next call time
        /// </summary>
        public const string InvalidNextCallTime = "Chưa đủ thời gian cho lần gọi tiếp theo.";

        /// <summary>
        ///     The patient has been called into the room
        /// </summary>
        public const string PatientHasBeenCalledIntoTheRoom = "Bệnh nhân này đã được gọi vào phòng";

        /// <summary>
        ///     The table type incorrect
        /// </summary>
        public const string TableTypeIncorrect = "Loại bàn không đúng";

        /// <summary>
        ///     The not finished reception number yet
        /// </summary>
        public const string NotFinishedReceptionNumberYet = "Bệnh nhân chưa kết thúc lượt khám.";

        /// <summary>
        ///     The not found clinic result
        /// </summary>
        public const string NotFoundClinicResult = "Bệnh nhân chưa có kết quả cận lâm sàng";

        /// <summary>
        ///     The not enough clinic result
        /// </summary>
        public const string NotEnoughClinicResult = "Bệnh nhân chưa có đủ kết quả cận lâm sàng";

        /// <summary>
        ///     The not yet clinic
        /// </summary>
        public const string NotYetClinic = "Bệnh nhân chưa được chỉ định cận lâm sàng";

        /// <summary>
        ///     The paid clinic
        /// </summary>
        public const string RefundClinic = "CLS này đã được hoàn.";

        /// <summary>
        ///     The not found cancel clinic list
        /// </summary>
        public const string NotFoundCancelClinicList = "Không tìm danh sách dịch vụ";

        /// <summary>
        ///     The clinic not yet result
        /// </summary>
        public const string ClinicNotYetResult = "Cận lâm sàng chưa có kết quả {0}";

        /// <summary>
        ///     The ip is map table
        /// </summary>
        public const string IpIsMapTable = "Địa chỉ Ip đã được liên kết với quầy khác.";

        /// <summary>
        ///     The not found department service
        /// </summary>
        public const string NotFoundDepartmentService = "Không tìm thấy dữ liệu.";

        /// <summary>
        ///     The not found file
        /// </summary>
        public const string NotFoundFile = "Không nhận được file, vui lòng thử lại.";

        /// <summary>
        ///     The template import not match
        /// </summary>
        public const string TemplateImportNotMatch = "Vui lòng sử dụng đúng mẫu import.";

        /// <summary>
        ///     The template is empty
        /// </summary>
        public const string TemplateIsEmpty = "File import không có dữ liệu, vui lòng thử lại.";

        /// <summary>
        ///     The exsited department service
        /// </summary>
        public const string ExsitedDepartmentService = "Phòng đã tồn tại dịch vụ này.";

        /// <summary>
        ///     The not found department
        /// </summary>
        public const string NotFoundExamination = "Không tìm thấy phòng chỉ định.";

        /// <summary>
        ///     The not found room
        /// </summary>
        public const string NotFoundRoom = "Không tìm thấy phòng thực hiện.";

        /// <summary>
        ///     The not found file
        /// </summary>
        public const string NotFoundSetting = "Không nhận tìm thấy cài đặt.";

        /// <summary>
        ///     Queue number not yet called into the room
        /// </summary>
        public const string QueueNumberNotYetCalledIntoTheRoom = "Bệnh nhân chưa được gọi vào phòng.";

        /// <summary>
        ///     The invalid examination type
        /// </summary>
        public const string NotYetConfigDevice = "Thiết bị chưa được thiết lập.";

        /// <summary>
        ///     The patient has not taken number
        /// </summary>
        public const string PatientHasNotCorrectTable = "Bệnh nhân tiếp đón sai quầy.";

        /// <summary>
        ///     The not found department
        /// </summary>
        public const string NotFoundExaminationDetail = "Không tìm hồ sơ.";

        /// <summary>
        ///     The can not update temporary patient
        /// </summary>
        public const string EmptyWaitingList = "Không còn bệnh nhân chờ.";

        /// <summary>
        ///     The can not update temporary patient
        /// </summary>
        public const string EmptyPriorityWaitingList = "Không còn bệnh nhân ưu tiên chờ.";

        /// <summary>
        ///     The not found paiding
        /// </summary>
        public const string NotFoundRegisteredCode = "Không tìm thấy thông tin lịch sử khám.";

        /// <summary>
        ///     The not found paiding
        /// </summary>
        public const string NotSupportIdentityCardNumber =
            "Không hỗ trợ quét CCCD. Vui lòng sử dụng đơn thuốc hoặc phiếu chỉ định.";

        public const string NotSupportInsuranceNumber =
            "Không hỗ trợ quét thẻ BHYT. Vui lòng sử dụng hoặc phiếu chỉ định.";

        /// <summary>
        ///     The authorization bank
        /// </summary>
        public const string LimitNumberOfCallingPatient =
            "Mỗi lần gọi tối đa 5 bệnh nhân. Vui lòng kiểm tra lại cấu hình.";

        public const string NotFoundReExam = "Đã có phiếu khám trong ngày, xin qua cửa tiếp đón/ hoặc lấy số tiếp đón";

        public const string NotFoundPatient =
            "Không tìm thấy mã hồ sơ hoặc mã hồ sơ không hợp lệ. Vui lòng kiểm tra lại thông tin.";

        public const string NotFoundReExamCalendar =
            "Không tìm thấy lịch tái khám, xin qua cửa tiếp đón/ hoặc lấy số tiếp đón";

        public const string NotFoundPrescription = "Không tìm thấy toa thuốc";

        public const string NotConfigDevice =
            "Thiết bị đang cấu hình thời gian sai. \n Vui lòng kiểm tra lại thời gian thiết bị theo các bước sau: \n Bước 1: Truy cập vào Cài đặt => Chọn mục Quản lý chung \n Chọn mục Thời gian => Để bật tính năng cài đặt thời gian tự động bạn gạt thanh ngang sang phải tại mục Thời gian tự động";

        public const string NotYetRegisteredExam =
            "Không tìm thấy hồ sơ. \n Bệnh nhân vui lòng lấy số thứ tự tiếp đón để vào quầy đăng ký khám.";

        public const string CanNotRegisterGroup =
            "Thẻ BHYT/CCCD bị lỗi, xin qua cửa tiếp đón/ hoặc lấy số tiếp đón để đăng ký";

        /// <summary>
        ///     The authorization bank
        /// </summary>
        public const string NotFoundListService = "Không tìm thấy dịch vụ, vui lòng kiểm tra lại.";

        /// <summary>
        ///     The not found department
        /// </summary>
        public const string NotFoundDepartment = "Không tìm thấy phòng.";

        /// <summary>
        ///     The not found department
        /// </summary>
        public const string NotFoundGroupDepartment = "Không tìm thấy nhóm phòng.";

        /// <summary>
        ///     The not found department
        /// </summary>
        public const string NotFoundVirtualDepartment = "Không tìm thấy phòng trong nhóm.";

        public const string NotFoundRecallNumber = "Không tìm thấy số thứ tự gọi lại.";

        /// <summary>
        ///     The condition cancel payment
        /// </summary>
        public const string ConditionCancelPayment = "Số tiền hủy lớn hơn số tiền hiện có trong thẻ";

        public const string FinishedReceptionNumber = "Mã điều trị đã tất toán.";

        public const string NotFinishedReceptionNumber = "Mã điều trị chưa tất toán.";

        public const string NotFoundFinishedTransaction = "Không tìm thấy giao dịch đã tất toán.";

        public const string NotFoundTekmediCard = "Bệnh nhân chưa được cấp thẻ TEKMEDI.";

        public const string NotFoundInvoiceNo = "Không tìm thấy hóa đơn.";

        public const string DeviceCodeAlreadyExist = "Mã thiết bị đã tồn tại";

        /// <summary>
        ///     The api not available
        /// </summary>
        public const string ApiAvailable = "Api chưa hoạt động";

        /// <summary>
        ///     The patient has not been called into the room
        /// </summary>
        public const string PatientHasNotBeenCalledIntoTheRoom = "Bệnh nhân này chưa được gọi.";

        /// <summary>
        ///     Register Failed
        /// </summary>
        public const string RegisterFailed = "Đăng ký thất bại.";

        public const string NotFoundUsageType = "Không tìm thấy loại sử dụng.";

        /// <summary>
        ///     The not found service
        /// </summary>
        public const string NotFoundServiceInArea = "Bệnh nhân không có dịch vụ ở khu này.";

        /// <summary>
        ///     The not found service
        /// </summary>
        public const string PatientHaveNotClinicResult = "Bệnh nhân chưa có kết quả cận lâm sàng.";

        /// <summary>
        ///     The template is empty
        /// </summary>
        public const string NotFoundDataToExport = "Không có dữ liệu để xuất file.";

        /// <summary>
        ///     The not found service
        /// </summary>
        public const string CanNotChangeIsFinished = "Số thứ tự đã kết thúc, không thể thay đổi trạng thái.";

        /// <summary>
        ///     The not found service information
        /// </summary>
        public const string NotFoundServiceInformation = "Không tìm thấy thông tin dịch vụ !";

        /// <summary>
        ///     The not hold clinic
        /// </summary>
        public const string NotFinishPayment =
            "Dịch vụ chưa được thanh toán. Vui lòng thanh toán trước khi thực hiện dịch vụ!";

        /// <summary>
        ///     The not hold clinic
        /// </summary>
        public const string AlrealdyFinished = "Tất cả dịch vụ đã được thực hiện!";

        /// <summary>
        ///     The department of group request is empty
        /// </summary>
        public const string DepartmentOfGroupRequestEmpty = "Danh sách phòng không được để trống.";

        /// <summary>
        ///     The not found service
        /// </summary>
        public const string NotFoundServiceInDepartment = "Không tìm thấy dịch vụ thực hiện ở khu vực này!";

        // <summary>
        /// The user not permission operation
        /// </summary>
        public const string UserNotPermissionOperation = "Bạn không có quyền thực hiện thao tác này!";

        /// <summary>
        ///     The condition cancel payment
        /// </summary>
        public const string NotEnoughLostPayment = "Số tiền trong thẻ dưới 50.000 VNĐ";

        public const string PleaseFillInPatientAndRegisteredCode = "Xin nhập vào mã bệnh nhân hoặc mã điều trị.";

        public const string NotFoundTransactionNumberConfig = "Không tìm thấy cấu hình số biên lai.";

        /// <summary>
        ///     The time slot not yet result
        /// </summary>
        public const string TimeSlotAlreadyFull = "Khung thời gian đăng ký đã được đặt hết.";

        /// <summary>
        ///     The time slot not yet result
        /// </summary>
        public const string NotFoundTimeSlot = "Khung giờ khám bệnh không tồn tại.";

        /// <summary>
        ///     The switch board not yet result
        /// </summary>
        public const string NotFoundSwitchBoard = "Tổng đài không tồn tại hoặc đã ngừng hoạt động.";

        /// <summary>
        ///     The setting department not yet result
        /// </summary>
        public const string NotFoundSettingDepartment = "Không tìm thấy cấu hình phòng khám!";

        /// <summary>
        ///     The time slot duplicate
        /// </summary>
        public const string TimeSlotDuplicate = "Khung giờ khám bệnh bị trùng nhau!.";

        /// <summary>
        ///     The time slot error
        /// </summary>
        public const string TimeSlotErorr = "Khung thời gian cài đặt không hợp lệ.";

        /// <summary>
        ///     The register date future
        /// </summary>
        public const string RegisterDateFuture = "Ngày đăng ký phải sau ngày hiện tại {0} ngày!.";

        /// <summary>
        ///     The Switch Board Not Permission
        /// </summary>
        public const string SwitchBoardNotPermission = "Tổng đài không có quyền đăng ký cho phòng khám này!.";

        /// <summary>
        ///     The department setting
        /// </summary>
        public const string DepartmentHaveSetting = "Phòng khám này đã được cấu hình!.";

        /// <summary>
        ///     The booking coode
        /// </summary>
        public const string NotFoundBookingCode = "Mã hẹn không tồn tại!.";

        /// <summary>
        ///     The time on times
        /// </summary>
        public const string TimeOnTimes = "Thời gian trên một lần khám không hợp lệ.";

        /// <summary>
        ///     The not found user Id
        /// </summary>
        public const string NotFoundUserId = "Không tìm thấy ID Tài khoản.";

        /// <summary>
        ///     The Not found data sync
        /// </summary>
        public const string NotFoundDataSync = "Dữ liệu ngày {0} đã được đồng bộ hết!";

        /// <summary>
        ///     The number used
        /// </summary>
        public const string NumberUsed = "Số thứ tự {0} đã được sử dụng!";

        /// <summary>
        ///     The registerd date
        /// </summary>
        public const string RegisterdDate = "Ngày {0} đã đăng ký khám chuyên khoa này rồi!";

        public const string ErrorObjectType = "Đối tượng bệnh nhân không đúng.";

        /// <summary>
        ///     The account not belong switch board
        /// </summary>
        public const string AccountNotBelongSwitchBoard = "Tài khoản không có tổng đài trực thuộc!";

        /// <summary>
        ///     The not found file template
        /// </summary>
        public const string NotFoundFileTemplate = "Không tìm thấy tệp mẫu!";

        /// <summary>
        ///     The notFound address
        /// </summary>
        public const string NotFoundAddress = "Không tìm thấy địa chỉ!";

        /// <summary>
        ///     The invalue param query
        /// </summary>
        public const string InvalueParamQuery = "Tham số truy vấn không hợp lệ!";

        /// <summary>
        ///     The invalue param query
        /// </summary>
        public const string DepartmentSettingHeterogeneous = "Cấu hình thời gian hoạt động các phòng không đồng nhất!";

        /// <summary>
        ///     The number not empty
        /// </summary>
        public const string NumberNotEmpty = "Số thứ tự không được để trống!";

        /// <summary>
        ///     The number not empty
        /// </summary>
        public const string SumNumberInvalid = "Tổng STT không đúng!.";

        /// <summary>
        ///     The department number error
        /// </summary>
        public const string DepartmentNumberError = "Phòng: {0} số thứ tự lớn hơn cấu hình phòng khám!";

        /// <summary>
        ///     The department number on times error
        /// </summary>
        public const string DepartmentNumberOnTimesError =
            "Phòng: {0} số thứ tự trên khung thời gian lớn hơn cấu hình phòng khám!";

        #region User

        /// <summary>
        ///     The invalue param query
        /// </summary>
        public const string NotFoundUserWithId = "Không tìm thấy tài khoản với id {0}!";

        /// <summary>
        ///     The invalue param query
        /// </summary>
        public const string NotFoundRoleWithId = "Không tìm thấy Role với id {0}!";

        /// <summary>
        ///     The invalue param query
        /// </summary>
        public const string NotFoundPermissionWithId = "Không tìm thấy Permission với id {0}!";

        /// <summary>
        ///     The user name or password invalid
        /// </summary>
        public const string UserNameOrPasswordInvalid = "Tài khoản hoặc mật khẩu không hợp lệ!";

        /// <summary>
        ///     The not found user with token
        /// </summary>
        public const string NotFoundUserWithToken = "Không tìm thấy tài khoản!";

        /// <summary>
        ///     The token expires
        /// </summary>
        public const string TokenExpires = "Token đã hết hạn!";

        public const string NotFoundGroup = "Không tìm thấy nhóm";

        public const string NotFoundDepartmentGroup = "Không tìm thấy nhóm phòng khám";

        public const string NotFoundDepartments = "Không tìm thấy danh sách phòng khám phù hợp";

        public const string NotFoundDepartmentCode = "Không tìm thấy phòng khám";

        /// <summary>
        ///     The unknow error
        /// </summary>
        public const string SignatureInvalid = "Chữ ký không hợp lệ";

        #endregion

        #region

        /// <summary>
        ///     The department group code exist
        /// </summary>
        public const string GroupCodeExist = "Mã nhóm phòng ban đã tồn tại.";

        /// The department group do not exists
        /// </summary>
        public const string GroupDoNotExists = "Nhóm không tồn tại.";

        /// <summary>
        ///     The department group request is empty
        /// </summary>
        public const string GroupRequestEmpty = "Mã và tên nhóm không được để trống.";

        /// <summary>
        ///     The not found list vaccine
        /// </summary>
        public const string CodeAlreadyExistButNotActive =
            "Mã phòng ban {0} đã dừng hoạt động, vui lòng cập nhật lại trạng thái hoạt động!";

        /// <summary>
        ///     The not found list vaccine
        /// </summary>
        public const string CodeAlreadyExist = "Mã phòng ban {0} đã tồn tại!";

        /// The department group do not exists
        /// </summary>
        public const string DepartmentGroupDoNotExists = "Nhóm phòng không tồn tại.";

        /// <summary>
        ///     The department group request is empty
        /// </summary>
        public const string DepartmentGroupRequestEmpty = "Mã và tên nhóm không được để trống.";

        /// <summary>
        ///     The department group code exist
        /// </summary>
        public const string DepartmentGroupCodeExist = "Mã nhóm đã tồn tại.";

        /// <summary>
        ///     The not found list value type
        /// </summary>
        public const string ServiceOfDepartmentEmpty = "Danh sách dịch vụ của phòng ban không được để trống.";

        #endregion
    }

    /// <summary>
    ///     Class ErrorMessages.
    /// </summary>
    public static class Messages
    {
        /// <summary>
        ///     The not enough balance message
        /// </summary>
        public const string Success = "Thành công.";

        /// <summary>
        ///     The waiting
        /// </summary>
        public const string Waiting = "Đang xử lý.";

        /// <summary>
        ///     The new
        /// </summary>
        public const string New = "Mới.";

        /// <summary>
        ///     The approved
        /// </summary>
        public const string Approved = "Thanh toán thành công.";

        /// <summary>
        ///     The approved
        /// </summary>
        public const string Failed = "Có lỗi xảy ra. Vui lòng thử lại.";
    }

    /// <summary>
    /// </summary>
    public static class MessagesCode
    {
        /// <summary>
        ///     The not found patient with code
        /// </summary>
        public const string NotFoundPatientWithCode = "NotFoundPatientWithCode";

        /// <summary>
        ///     The invalid amount
        /// </summary>
        public const string InvalidAmount = "InvalidAmount";

        /// <summary>
        ///     The not found medicine
        /// </summary>
        public const string NotFoundMedicine = "NotFoundMedicine";

        /// <summary>
        ///     The not found service
        /// </summary>
        public const string NotFoundService = "NotFoundService";

        /// <summary>
        ///     The not enough balance
        /// </summary>
        public const string NotEnoughBalance = "NotEnoughBalanceMessage";

        /// <summary>
        ///     The not found card number
        /// </summary>
        public const string NotFoundCardNumber = "NotFoundCardNumber";

        /// <summary>
        ///     The have not provided card number
        /// </summary>
        public const string HaveNotProvidedCardNumber = "HaveNotProvidedCardNumber";

        /// <summary>
        ///     The table not exist
        /// </summary>
        public const string TableNotExist = "TableNotExist";

        /// <summary>
        ///     The patient has not taken number
        /// </summary>
        public const string PatientHasNotTakenNumber = "PatientHasNotTakenNumber";

        /// <summary>
        ///     The finished queue number temporary
        /// </summary>
        public const string FinishedQueueNumberTemp = "FinishedQueueNumberTemp";

        /// <summary>
        ///     The queue number is not turn
        /// </summary>
        public const string QueueNumberIsNotTurn = "QueueNumberIsNotTurn";

        /// <summary>
        ///     The invalid examination type
        /// </summary>
        public const string InvalidExaminationType = "InvalidExaminationType";

        /// <summary>
        ///     The not found doctor
        /// </summary>
        public const string NotFoundDoctor = "NotFoundDoctor";

        /// <summary>
        ///     The invalid format datetime
        /// </summary>
        public const string InvalidFormatDatetime = "InvalidFormatDatetime";

        /// <summary>
        ///     The unknow error
        /// </summary>
        public const string UnknowError = "9999";

        /// <summary>
        ///     The table not exist
        /// </summary>
        public const string DeviceNotExist = "DeviceNotExist";
    }
}