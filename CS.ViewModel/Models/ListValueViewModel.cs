using System;
using CS.Base.ViewModels;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    public class ListValueViewModel : BaseViewModelExtended
    {
        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        [JsonProperty("list_value_type_id")]
        public Guid ListValueTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the display order.
        /// </summary>
        /// <value>The display order.</value>
        [JsonProperty("display_order")]
        public int? DisplayOrder { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        [JsonProperty("is_system")]
        public bool IsSystem { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        [JsonProperty("is_checked")]
        public bool IsChecked { get; set; }

        /// <summary>
        ///     Gets or sets the type of the service.
        /// </summary>
        /// <value>
        ///     The type of the service.
        [JsonProperty("service_type")]
        /// </value>
        public ServiceType ServiceType { get; set; }

        /// <summary>
        ///     Gets or sets the department type.
        /// </summary>
        /// <value>
        ///     The department type.
        /// </value>
        [JsonProperty("department_type")]
        public string DepartmentType { get; set; }
    }

    public class ListValueViewModelLimit : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}