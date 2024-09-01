using System;
using System.Collections.Generic;

namespace CS.VM.Responses
{
    public class GetPatientServiceResponse
    {
        public class ListService
        {
            public string ServiceCode { get; set; }
            public string ServiceName { get; set; }
        }

        public class ListServiceWithDepartment
        {
            public string DepartmentCode { get; set; }
            public string DepartmentName { get; set; }
            public List<ListService> Services { get; set; }
        }

        public class ResultListService
        {
            public string RegisteredCode { get; set; }
            public string PatientType { get; set; }
            public DateTime RegisteredDate { get; set; }
            public List<ListServiceWithDepartment> Data { get; set; }
        }
    }
}