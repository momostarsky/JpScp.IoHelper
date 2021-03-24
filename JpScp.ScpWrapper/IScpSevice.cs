namespace JpScp.ScpWrapper
{
    public enum ServiceState
    {
        None = 0,
        Runing = 1
         
        
    }
    
    public interface IScpSevice
    {
        void Start();

        void Stop();

        void Cancel();
        
        
    }
}