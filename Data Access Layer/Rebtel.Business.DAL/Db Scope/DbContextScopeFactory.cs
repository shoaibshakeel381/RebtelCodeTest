using System;
using System.Data;

namespace Rebtel.Business.DAL.Infrastructure
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        public IDbContextScope Create(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting)
        {
            return new DbContextScope(
                joiningOption: joiningOption,
                isolationLevel: null);
        }

        public IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new DbContextScope(
                joiningOption: DbContextScopeOption.ForceCreateNew,
                isolationLevel: isolationLevel);
        }

        public IDisposable SuppressAmbientContext()
        {
            return new AmbientContextSuppressor();
        }
    }
}