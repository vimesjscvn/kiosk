using System;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Common.Services
{
    public interface IServiceLocator : IDisposable
    {
        IServiceScope CreateScope();
        T Get<T>();
    }
}