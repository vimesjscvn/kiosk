using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("transaction_number_configs", Schema = "IHM")]
    public class TransactionNumberConfig
    {
        public static string BookTypeTatToan = "TT";
        public static string BookTypeTamUng = "TU";
        public static string BookTypeHoanUng = "HU";
        public static string PatientTypeBaoHiem = "BH";
        public static string PatientTypeDichVu = "DV";
        public static string PatientTypeTamUng = "TU";
        public static string PatientTypeHoanUng = "HU";

        public static List<string> BookTypes = new List<string>() { BookTypeTamUng, BookTypeTatToan, BookTypeHoanUng };
        public static List<string> PatientTypes = new List<string>() { PatientTypeBaoHiem, PatientTypeDichVu, PatientTypeTamUng, PatientTypeHoanUng };
        public static List<string> PatientTypesForTatToan = new List<string> { PatientTypeDichVu, PatientTypeBaoHiem };

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("serial_no")]
        public string SerialNo { get; set; }

        [Column("recv_no")]
        public int RecvNo { get; set; }

        [Column("book_no")]
        public string BookNo { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("patient_type")]
        public string PatientType { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        public TransactionNumberConfig()
        {
        }

        public TransactionNumberConfig(
            Guid id,
            string serialNo,
            string bookNo,
            int recvNo,
            bool isActive,
            string type,
            string patientType,
            Guid userId)
        {
            Id = id;
            SerialNo = serialNo;
            BookNo = bookNo;
            RecvNo = recvNo;
            IsActive = isActive;
            Type = type;
            PatientType = patientType;
            UserId = userId;
        }

        public static TransactionNumberConfig NewForAdd(
            string serialNo,
            string bookNo,
            string type,
            string patientType,
            int recvNo,
            Guid userId)
        {
            if (string.IsNullOrEmpty(serialNo))
            {
                throw new Exception("Serial không được để rỗng");
            }

            if (string.IsNullOrEmpty(bookNo))
            {
                throw new Exception("Số sổ không được để rỗng");
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new Exception("Loại không được để rỗng");
            }

            if (string.IsNullOrEmpty(patientType))
            {
                throw new Exception("Loại bệnh nhân không được để rỗng");
            }

            if (BookTypes.Contains(type) == false)
            {
                throw new Exception("Loại không đúng định dạng");
            }

            if (PatientTypes.Contains(patientType) == false)
            {
                throw new Exception("Loại bệnh nhân không đúng định dạng");
            }

            var id = Guid.NewGuid();
            bool isActive = false;

            return new TransactionNumberConfig(id, serialNo, bookNo, recvNo, isActive, type, patientType, userId);
        }

        public void Update(string serialNo, string bookNo, string type, string patientType, bool isActive, int recvNo)
        {
            SerialNo = serialNo;
            BookNo = bookNo;
            Type = type;
            PatientType = patientType;
            IsActive = isActive;
            RecvNo = recvNo;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
