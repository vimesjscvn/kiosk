namespace CS.VM.CheckInModel.Requests
{
    public class GetAllCPSQueueRequest
    {
        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        public int Limit { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string DepartmentCode { get; set; }
    }
}