using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Unity;

namespace JpScp.ScpWrapper
{
    public class StoreScp :IScpSevice
    {
        private readonly ILogger<StoreScp> _logger;

        private readonly IDbPersist db;

 

        public StoreScp(ILogger<StoreScp> logger ,IDbPersist dbPersist )
        {
            _logger = logger;
            db = dbPersist;

        }
 
        
         
        public void Start()
        {
            _logger.LogInformation("Start ....");
            db.Save();
            
        }

        public void Stop()
        {
            Console.WriteLine("Stop ....");
        }

        public void Cancel()
        {
            Console.WriteLine("Cancel ....");
           
        }
    }
}