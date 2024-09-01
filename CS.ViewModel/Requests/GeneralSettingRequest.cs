using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CS.VM.Requests
{
    public class GeneralSettingRequest
    {
        /// <summary>
        ///     Gets or sets the logo.
        /// </summary>
        /// <value>
        ///     The logo.
        /// </value>
        public IFormFile Logo { get; set; }

        /// <summary>
        ///     Gets or sets the background.
        /// </summary>
        /// <value>
        ///     The background.
        /// </value>
        public IFormFile Background { get; set; }

        /// <summary>
        ///     Gets or sets the bamnner.
        /// </summary>
        /// <value>
        ///     The bamnner.
        /// </value>
        public IFormFile Banner { get; set; }

        /// <summary>
        ///     Gets or sets the hospital name vietnamese.
        /// </summary>
        /// <value>
        ///     The hospital name vietnamese.
        /// </value>
        [Required]
        public string HospitalNameVietnamese { get; set; }

        /// <summary>
        ///     Gets or sets the hospital name english.
        /// </summary>
        /// <value>
        ///     The hospital name english.
        /// </value>
        [Required]
        public string HospitalNameEnglish { get; set; }

        /// <summary>
        ///     Gets or sets the hospital slogan.
        /// </summary>
        /// <value>
        ///     The hospital slogan.
        /// </value>
        [Required]
        public string HospitalSlogan { get; set; }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [Required]
        public string HospitalCode { get; set; }
    }
}