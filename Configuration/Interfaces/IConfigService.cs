using CS.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Config.Interfaces
{
    public interface IConfigService
    {
        Task<Dictionary<string, string>> GetConfigurationsAsync(Applications applicationid);
    }
}
