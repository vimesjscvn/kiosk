using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    public class UserProfileViewModel
    {
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "email")] public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")] public string Phone { get; set; }

        [JsonProperty(PropertyName = "token")] public string Token { get; set; }

        [JsonProperty(PropertyName = "token_exp")]
        public DateTime? TokenExp { get; set; }

        [JsonProperty(PropertyName = "last_login")]
        public DateTime? LastLogin { get; set; }

        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "sex")] public int? Sex { get; set; }

        [JsonProperty(PropertyName = "birthdate")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty(PropertyName = "title")] public Guid? Title { get; set; }

        [JsonProperty(PropertyName = "list_titles")]
        public List<ListValueViewModel> ListTitles { get; set; }

        [JsonProperty(PropertyName = "position")]
        public Guid? Position { get; set; }

        [JsonProperty(PropertyName = "list_positions")]
        public List<ListValueViewModel> ListPositions { get; set; }

        [JsonProperty(PropertyName = "is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "code")] public string Code { get; set; }
    }
}