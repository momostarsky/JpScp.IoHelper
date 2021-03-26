using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace JpScp.ScpWrapper
{
    public class PgDbPersist :IDbPersist
    {


        private readonly ILogger<PgDbPersist> _logger;
        
        
        public PgDbPersist(ILogger<PgDbPersist> log)
        {
            _logger = log;
        }
        
        public void Save()
        {
             _logger.LogInformation("Save To Pg DB");
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}