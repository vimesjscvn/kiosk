using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="UoW.IService{CS.EF.Models.Category, Core.Common.UoW.IRepository{CS.EF.Models.Category}}" />
    public interface ICategoryService
    {
        /// <summary>
        ///     Gets the calendar by date.
        /// </summary>
        /// <param name="request">The get calendar by date request.</param>
        /// <returns></returns>
        Task<List<CategoryViewModel>> GetAll();
    }

    public class CategoryViewModel
    {
        [JsonProperty("service_id")] public string ServiceId { get; set; }

        [JsonProperty("service_name")] public string ServiceName { get; set; }

        [JsonProperty("service_type_id")] public string ServiceTypeId { get; set; }

        [JsonProperty("service_type_name")] public string ServiceTypeName { get; set; }

        [JsonProperty("unit")] public string Unit { get; set; }

        [JsonProperty("advanced_price")] public string AdvancedPrice { get; set; }

        [JsonProperty("insurance_price")] public string InsurancePrice { get; set; }

        [JsonProperty("vip_price")] public string VipPrice { get; set; }
    }
}