using CS.Base.ViewModels;
using Newtonsoft.Json;

namespace DepartmentGroup.Domain.Models
{
    public class GroupViewModel : BaseViewModelExtended
    {
        public int? DisplayOrder { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsSystem { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }
    }

    public class GroupViewModelLimit : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string GroupDeptCode { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("name")]
        public string GroupDeptName { get; set; }
    }
}