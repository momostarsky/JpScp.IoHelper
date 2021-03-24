using System;

namespace JpScp.ScpWrapper
{
    public class StoreScp :IScpSevice
    {
        public void Start()
        {
            Console.WriteLine("Start ....");
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