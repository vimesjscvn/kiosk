namespace CS.VM.CheckInModel.Requests
{
    public class GetTableQueueRequest
    {
        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        public int Limit { get; set; }
    }

    public class GetAllTableQueueRequest
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

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string Code { get; set; }
    }

    public class GetAllTableQueueRequest_V02 : GetAllTableQueueRequest
    {
        /// <summary>
        ///     Gets or sets the hospital area.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        public string AreaCode { get; set; }
    }
}