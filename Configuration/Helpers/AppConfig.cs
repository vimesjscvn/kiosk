using Core.Config.Configs;
using Core.Config.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Serilog;

namespace Core.Config.Helpers
{
    public static class AppConfig
    {
        public const string SmsKey = "SMS";
        public const string HospitalKey = "HOSPITAL";
        public const string ApiKey = "API";
        public const string ExternalKey = "EXTERNAL";
        public const string InsuranceKey = "INSURANCE";
        public const string GroupDeptKey = "GROUPDEPT";
        public const string CronJobKey = "CRONJOB";
        public const string BackgroundJobKey = "BACKGROUNDJOB";
        public const string EncryptingKey = "ENCRYPTING";

        public static Dictionary<string, string> Configurations { get; private set; } = new Dictionary<string, string>();

        public static void LoadConfigurations(Dictionary<string, string> configurations)
        {
            Configurations = configurations;
        }

        public static string GetConfiguration(string key)
        {
            return Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
        }

        public static T GetConfiguration<T>(string key)
        {
            var name = typeof(T).Name;
            var keyz = RemoveConfigLabel(name);
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<T>(data);
            }

            return default;
        }

        public static HospitalConfig Hospital()
        {
            string key = HospitalKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<HospitalConfig>(data);
            }

            return null;
        }

        public static HospitalSettings LoadHospital(HospitalSettings hospitalSettings)
        {
            try
            {
                string key = HospitalKey.ToUpper();
                var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
                if (data != null)
                {
                    var config = JsonConvert.DeserializeObject<HospitalConfig>(data);
                    hospitalSettings.Hospital = config;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }

            return hospitalSettings;
        }

        public static ApiConfig App()
        {
            string key = ApiKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<ApiConfig>(data);
            }

            return null;
        }

        public static ExternalConfig External()
        {
            string key = ExternalKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<ExternalConfig>(data);
            }

            return null;
        }

        public static ExternalSettings LoadExternal(ExternalSettings externalSettings)
        {
            try
            {
                string key = ExternalKey.ToUpper();
                var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
                if (data != null)
                {
                    var config = JsonConvert.DeserializeObject<ExternalConfig>(data);
                    externalSettings.External = config;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }

            return externalSettings;
        }

        public static EncryptingConfig Encrypting()
        {
            string key = EncryptingKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<EncryptingConfig>(data);
            }

            return null;
        }

        public static EncryptingSettings LoadEncrypting(EncryptingSettings encryptingSettings)
        {
            try
            {
                string key = EncryptingKey.ToUpper();
                var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
                if (data != null)
                {
                    var config = JsonConvert.DeserializeObject<EncryptingConfig>(data);
                    encryptingSettings.Encrypting = config;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }

            return encryptingSettings;
        }

        public static BackgroundJobConfig BackgroundJob()
        {
            string key = BackgroundJobKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<BackgroundJobConfig>(data);
            }

            return null;
        }

        public static BackgroundJobSettings LoadBackgroundJob(BackgroundJobSettings backgroundJobSettings)
        {
            try
            {
                string key = BackgroundJobKey.ToUpper();
                var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
                if (data != null)
                {
                    var config = JsonConvert.DeserializeObject<BackgroundJobConfig>(data);
                    backgroundJobSettings.BackgroundJob = config;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }

            return backgroundJobSettings;
        }

        public static CronJobConfig CronJob()
        {
            string key = CronJobKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<CronJobConfig>(data);
            }

            return null;
        }

        public static GroupDeptConfig GroupDept()
        {
            string key = GroupDeptKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<GroupDeptConfig>(data);
            }

            return null;
        }

        public static GroupDeptSettings LoadGroupDept(GroupDeptSettings groupDeptSettings)
        {
            try
            {
                string key = GroupDeptKey.ToUpper();
                var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
                if (data != null)
                {
                    var config = JsonConvert.DeserializeObject<GroupDeptConfig>(data);
                    groupDeptSettings.GroupDept = config;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }

            return groupDeptSettings;
        }

        public static InsuranceConfig Insurance()
        {
            string key = InsuranceKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<InsuranceConfig>(data);
            }

            return null;
        }

        public static InsuranceSettings LoadInsurance(InsuranceSettings insuranceSettings)
        {
            try
            {
                string key = InsuranceKey.ToUpper();
                var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
                if (data != null)
                {
                    var config = JsonConvert.DeserializeObject<InsuranceConfig>(data);
                    insuranceSettings.Insurance = config;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }

            return insuranceSettings;
        }

        public static SmsConfig Sms()
        {
            string key = SmsKey.ToUpper();
            var data = Configurations.TryGetValue(key.ToUpper(), out var value) ? value : null;
            if (data != null)
            {
                return JsonConvert.DeserializeObject<SmsConfig>(data);
            }

            return null;
        }

        private static string RemoveConfigLabel(string input)
        {
            const string label = "Config";
            if (input.EndsWith(label, StringComparison.OrdinalIgnoreCase))
            {
                return input.Substring(0, input.Length - label.Length);
            }
            return input;
        }
    }
}
