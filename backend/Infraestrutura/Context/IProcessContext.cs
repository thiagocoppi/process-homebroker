using System;
using System.Data;

namespace Infraestrutura.Context
{
    public interface IProcessContext : IDisposable
    {
        IDbConnection GetConnection();
    }
}