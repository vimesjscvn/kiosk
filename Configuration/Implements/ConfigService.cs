using Core.Config.Interfaces;
using Core.Config.Models;
using CS.Common.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Config.Implements
{
    public class ConfigService : IConfigService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ConfigService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<Dictionary<string, string>> GetConfigurationsAsync(Applications applicationId)
        {
            Dictionary<string, string> configs = new Dictionary<string, string>();
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<BaseApplicationDbContext>();
                    configs = await context.Configs.Where(c => c.ApplicationId == applicationId).ToDictionaryAsync(c => c.Key, c => c.Value);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }

            return configs;
        }
    }
}
