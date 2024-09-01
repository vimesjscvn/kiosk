namespace CS.VM.Requests
{
    public class GetTableRequest : DataTableParameters
    {
    }

    public class GetAllTableByDepartmentCodeRequest
    {
        public string DepartmentCode { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }
}