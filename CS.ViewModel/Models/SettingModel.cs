using System.Collections.Generic;

namespace CS.VM.Models
{
    public class BaseSetting
    {
        public string Key { get; set; }
        public SettingModel Value { get; set; }
    }

    public class CreateOrUpdateSettingRequest
    {
        public string Key { get; set; }
        public SettingValueModel OptionHospital { get; set; }
        public SettingValueModel OptionColor { get; set; }
        public SettingValueModel OptionColorByPriority { get; set; }
        public SettingValueModel OptionBackground { get; set; }
        public SettingValueModel OptionsFont { get; set; }
        public SettingValueModel OptionsSL { get; set; }
        public SettingValueModel OptionsSizeFont { get; set; }
        public SettingValueModel OptionsStartBanner { get; set; }
        public SettingValueModel OptionsTimeBanner { get; set; }
        public SettingValueModel LogosUrl { get; set; }
        public SettingValueModel OptionsFooter { get; set; }
    }

    public class GetAllSettingResponse
    {
        public List<BaseSetting> Settings { get; set; }
    }

    public class SettingModel
    {
        public List<SettingValueModel> OptionHospital { get; set; }
        public List<SettingValueModel> OptionColor { get; set; }
        public List<SettingValueModel> OptionColorByPriority { get; set; }
        public List<SettingValueModel> OptionBackground { get; set; }
        public List<SettingValueModel> OptionsFont { get; set; }
        public List<SettingValueModel> OptionsSL { get; set; }
        public List<SettingValueModel> OptionsSizeFont { get; set; }
        public List<SettingValueModel> OptionsStartBanner { get; set; }
        public List<SettingValueModel> OptionsTimeBanner { get; set; }
        public List<SettingValueModel> LogosUrl { get; set; }
        public List<SettingValueModel> OptionsFooter { get; set; }
    }

    public class SettingValueModel
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }

    public class SettingViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}