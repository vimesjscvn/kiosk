using System;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.Requests
{
    public class RevertOrderNumberRequest
    {
        [Required] public string RoomVirtualCode { get; set; }

        [Required] public string RoomActiveCode { get; set; }

        [Required] public int Number { get; set; }

        [Required] public int PatientType { get; set; }

        [Required] public Guid PatientId { get; set; }
    }

    public class RevertOrderNumberNormalDepartmentRequest
    {
        [Required] public string Room { get; set; }

        [Required] public int Number { get; set; }

        [Required] public int PatientType { get; set; }

        [Required] public Guid PatientId { get; set; }
    }
}